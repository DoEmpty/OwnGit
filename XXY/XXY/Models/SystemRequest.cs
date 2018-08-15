using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XXY.Models
{
    /// <summary>
    /// 系统配置请求实体
    /// </summary>
    public class SystemRequest:ModelRequest
    {
        /// <summary>
        /// 系统配置名称
        /// </summary>
        public string Name { get; set; }
    }
}