using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Filters;
using XXY.Models;

namespace XXY.App_Start
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //重写基类的异常处理方法
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //1.返回调用方具体的异常信息
            HttpStatusCode errorCode;
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                errorCode = HttpStatusCode.NotImplemented;
            }
            else if (actionExecutedContext.Exception is TimeoutException)
            {
                errorCode = HttpStatusCode.RequestTimeout;
            }
            //.....这里可以根据项目需要返回到客户端特定的状态码。如果找不到相应的异常，统一返回服务端错误500
            else
            {
                errorCode = HttpStatusCode.InternalServerError;
            }

            actionExecutedContext.Response = new HttpResponseMessage
            {
                Content = new ObjectContent<ModelResult>
                (
                    new ModelResult
                    {
                        Code = "9999",
                        Msg = actionExecutedContext.Exception.Message,
                        Status = errorCode
                    },
                    new JsonMediaTypeFormatter(),
                    "application/json"
                )
            };
            base.OnException(actionExecutedContext);
        }
    }
}