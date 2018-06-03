using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PhonemikeServer.Core
{
    public class CommonController : Controller
    {
        protected mJsonresult json = new mJsonresult();

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                json = new mJsonresult
                {
                    msg = context.Exception.GetBaseException().Message,
                    failCode = EFailCode.ServerError
                };
                context.ExceptionHandled = true;//异常已处理
                WriteJson(context, json);
                return;
            }

            if (!(context.Result is EmptyResult && json != null))
            {
                base.OnActionExecuted(context);
                return;
            }
            else
            {

                WriteJson(context, json);
            }
        }

        private void WriteJson(ActionExecutedContext context, mJsonresult jsonObj)
        {
            var str = json.ToJsonString();
            context.HttpContext.Response.WriteAsync(str);
        }
    }
}
