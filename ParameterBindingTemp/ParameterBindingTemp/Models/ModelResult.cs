using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ParameterTemp.Models
{
    /// <summary>
    /// 定义模型验证返回的实体
    /// </summary>
    public class ModelResult
    {
        public string Msg { get; set; }
        public HttpStatusCode  Status { get; set; }
        public object Data { get; set; }
    }
}