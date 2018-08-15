using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XXY.Models
{
    /// <summary>
    /// 图片上传请求实体
    /// </summary>
    public class ImageRequest
    {
        /// <summary>
        /// Base64格式
        /// </summary>
        public string Image { get; set; }
    }
}