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
        [HttpPost]
        public ModelResult GetHouse(HouseRequest request)
        {
            return new HouseBus().GetPagedAreaHouses(request);
        }

        /// <summary>
        /// 添加房屋信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ModelResult AddHouse(HouseRequest request)
        {
            var result = new ModelResult { Data = new HouseBus().AddHouse(request) };
            return result;
        }
    }
}
