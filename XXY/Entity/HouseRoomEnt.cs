using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public  class HouseRoomEnt
    {
        public int ID { get; set; }
        public int HouseID { get; set; }
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
