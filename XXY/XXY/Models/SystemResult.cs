using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XXY.Models
{
    /// <summary>
    /// 系统配置响应实体
    /// </summary>
    public class SystemResult
    {
        /// <summary>
        /// 集合
        /// </summary>
        public List<SystemResult> SystemConfigs { get; set; }
        /// <summary>
        /// 配置Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 配置Value
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 展示名称
        /// </summary>
        public string DisplayName { get; set; }
    }
}