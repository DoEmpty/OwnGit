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
    /// 系统配置
    /// </summary>
    [Route("System/{Action}")]
    public class SystemController : ApiController
    {
        /// <summary>
        /// 获取配置项
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ModelResult GetSysteConfig(SystemRequest request)
        {
            return new SystemBus().GetSystemConfigs(request);
        }

        /// <summary>
        /// 根据父级地区获取所有子地区
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ModelResult GetChildAreas(AreaRequest request)
        {
            return new SystemBus().GetChildAreas(request);
        }
    }
}
