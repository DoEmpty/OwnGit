﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HouseEnt
    {
        public int ID { get; set; }
        /// <summary>
        /// 地区ID
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 社区
        /// </summary>
        public string Community { get; set; }
        /// <summary>
        /// 系统配置，房屋类别
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 系统配置，楼层类别
        /// </summary>
        public int FloorType { get; set; }
        /// <summary>
        /// 朝向
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// 系统配置，装修类别
        /// </summary>
        public int DecorateType { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public int Area { get; set; }
        /// <summary>
        /// 楼龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 默认图片
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 系统配置，创建人类别
        /// </summary>
        public int CreateUserType { get; set; }
        public int CreateUserID { get; set; }
        public DateTime CreateTime { get; set; }
        public string ContactMobile { get; set; }
        public string Memo { get; set; }

        public string AreaName { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal FirstRate { get; set; }
        public int LivingroomCount { get; set; }
        public int BedroomCount { get; set; }
        public int KitchenCount { get; set; }
        public int BathroomCount { get; set; }
    }
}