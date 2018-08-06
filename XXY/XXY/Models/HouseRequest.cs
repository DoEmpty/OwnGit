using System;
using System.Collections.Generic;
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
    }
}