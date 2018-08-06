using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace XXY.Models
{
    /// <summary>
    /// 请求返回结果类
    /// </summary>
    public class ModelResult
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// Http状态值
        /// </summary>
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
}