using ParameterTemp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ParameterTemp.Filters
{
    public class ModelFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var result = new ModelResult { Msg = string.Join("\r\n", actionContext.ModelState.Values.Select(x => string.Join("\r\n", x.Errors.Select(y => y.ErrorMessage)))), Status = System.Net.HttpStatusCode.BadRequest };
                actionContext.Response = actionContext.Request.CreateResponse(result);
            }
        }
    }
}