using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AdvertisingEnt
    {
        public int ID { get; set; }
        /// <summary>
        /// 广告图 
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 广告位
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// 点击跳转地址
        /// </summary>
        public string Url { get; set; }
    }
}
