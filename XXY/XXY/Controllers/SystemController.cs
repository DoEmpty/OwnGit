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
    public class SystemController : ApiController
    {
        public ModelResult GetSysteConfig(SystemRequest request)
        {
            return new SystemBus().GetSystemConfigs(request);
        }
    }
}
