using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XXY.Models
{
    /// <summary>
    /// 广告请求实体
    /// </summary>
    public class AdRequest:ModelRequest
    {
        /// <summary>
        /// 位置
        /// </summary>
        public int? Position { get; set; }
    }
}