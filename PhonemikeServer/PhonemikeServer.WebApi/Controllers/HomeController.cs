using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using PhonemikeServer.Core;
namespace PhonemikeServer.WebApi.Controllers
{
    public class HomeController : CommonController
    {
        // GET api/values
        [HttpGet]
        public void Index(string str = "")
        {
            json.msg = str;
            json.obj = new string[] { "value1", "value2" };
        }


        // GET api/values
        [HttpGet]
        public void Error(string str = "")
        {
            int a = 0;

            var c = 123 / a;
        }
        
    }
}
