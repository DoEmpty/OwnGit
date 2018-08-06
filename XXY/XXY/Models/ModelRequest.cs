using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XXY.Models
{
    /// <summary>
    /// 请求实体
    /// </summary>
    public class ModelRequest
    {
        /// <summary>
        /// 开始页索引
        /// </summary>
        public int? PageIndex { get; set; }
        /// <summary>
        /// 页数据条数
        /// </summary>
        public int? PageSize { get; set; }
        internal int PageStart
        {
            get
            {
                var index = PageIndex.HasValue ? PageIndex.Value : 0;
                var size = PageSize.HasValue ? PageSize.Value : 24;
                return index * size;
            }
        }
        internal int PageEnd
        {
            get
            {
                var index = PageIndex.HasValue ? PageIndex.Value : 0;
                var size = PageSize.HasValue ? PageSize.Value : 24;
                return index * size + size;
            }
        }
    }
}