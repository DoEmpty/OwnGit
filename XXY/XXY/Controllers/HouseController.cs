using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XXY.Business;
using XXY.Models;

namespace XXY.Controllers
{
    /// <summary>
    /// 房屋信息
    /// </summary>
    [Route("House/{Action}")]
    public class HouseController : ApiController
    {
        /// <summary>
        /// 获取房屋信息
        /// </summary>
        /// <returns></returns>
        public ModelResult Get(HouseRequest request)
        {
            return new HouseBus().GetPagedAreaHouses(request);
        }
    }
}
