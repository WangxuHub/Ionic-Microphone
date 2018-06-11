using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhonemikeServer.Core
{
    public class NamespaceConstraint : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var dataTokenNamespace = (string)routeContext.RouteData.DataTokens.FirstOrDefault(dt => dt.Key == "Namespace").Value;
            var actionNamespace = ((ControllerActionDescriptor)action).MethodInfo.DeclaringType.Namespace;

            return dataTokenNamespace == actionNamespace;
        }

    }
    
    public class SampleActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}
