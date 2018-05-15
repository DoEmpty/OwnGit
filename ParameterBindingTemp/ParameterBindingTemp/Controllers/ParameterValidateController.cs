using ParameterTemp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParameterTemp.Controllers
{
    /// <summary>
    /// 对传入参数进行模型验证
    /// </summary>
    [Route("ParameterValidate/{Action}")]
    public class ParameterValidateController : ApiController
    {
        /// <summary>
        /// 1.增加模型验证
        /// 2.添加自定义过滤器，输出模型验证信息，利用webapi提供的ActionFilterAttribute的Action过滤器
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public ModelResult AddStudent(Student student)
        {
            return new ModelResult { Data = student, Msg = "Success", Status = HttpStatusCode.OK };
        }
    }
}
