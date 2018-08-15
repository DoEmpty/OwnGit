using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XXY.Models
{
    /// <summary>
    /// 广告响应实体
    /// </summary>
    public class AdResult
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 跳转地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public int Position { get; set; }
    }
}