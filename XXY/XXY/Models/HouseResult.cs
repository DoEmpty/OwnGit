using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XXY.Models
{
    /// <summary>
    /// 房屋信息响应实体
    /// </summary>
    public class HouseResult
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 所在地区
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string Community { get; set; }
        /// <summary>
        /// 系统配置，房屋类别
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 系统配置，楼层类别
        /// </summary>
        public string FloorType { get; set; }
        /// <summary>
        /// 朝向
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// 系统配置，装修类别
        /// </summary>
        public string DecorateType { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public decimal Area { get; set; }
        /// <summary>
        /// 楼龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 系统配置，创建人类别
        /// </summary>
        public string CreateUserType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactMobile { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 首付价格
        /// </summary>
        public decimal FirstPrice { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 图片信息
        /// </summary>
        public string[] Images { get; set; }
        /// <summary>
        /// 格局
        /// </summary>
        public string Layout { get; set; }
    }
}