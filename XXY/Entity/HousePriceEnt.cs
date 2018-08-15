using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HousePriceEnt
    {
        public int ID { get; set; }
        public int HouseID { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 首付
        /// </summary>
        public decimal FirstPrice { get; set; }
        /// <summary>
        /// 系统配置，支付方式
        /// </summary>
        public int PaymentMethod { get; set; }
    }
}
