﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XXY.Models
{
    /// <summary>
    /// 房屋信息请求实体
    /// </summary>
    public class HouseRequest:ModelRequest
    {
        /// <summary>
        /// 区域ID
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string Community { get; set; }
        /// <summary>
        /// 房产性质
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        public int FloorType { get; set; }
        /// <summary>
        /// 朝向
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// 装修
        /// </summary>
        public int DecorateType { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public decimal Area { get; set; }
        /// <summary>
        /// 楼龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 创建人类型
        /// </summary>
        public int CreateUserType { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateUserID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactMobile { get; set; }
        /// <summary>
        /// 房产备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 房屋价格
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 房屋首付
        /// </summary>
        public decimal FirstPrice { get; set; }
        /// <summary>
        /// 房屋图片
        /// </summary>
        public string[] HouseImages { get; set; }
        /// <summary>
        /// 客厅数量
        /// </summary>
        public int LivingroomCount { get; set; }
        /// <summary>
        /// 卧室数量
        /// </summary>
        public int BedroomCount { get; set; }
        /// <summary>
        /// 厨房数量
        /// </summary>
        public int KitchenCount { get; set; }
        /// <summary>
        /// 卫生间数量
        /// </summary>
        public int BathroomCount { get; set; }
    }
}