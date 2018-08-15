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
    /// 广告信息
    /// </summary>
    [Route("Adversiting/{Action}")]
    public class ADController : ApiController
    {
        /// <summary>
        /// 获取广告信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ModelResult GetAdversiting(HouseRequest request)
        {
            return new AdBus().GetAdvertsings(request);
        }
    }
}
