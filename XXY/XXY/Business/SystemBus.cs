using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XXY.Models;

namespace XXY.Business
{
    public class SystemBus
    {
        public ModelResult GetSystemConfigs(SystemRequest request)
        {
            var list = SystemConfigRepository.QueryAllSystemConfigs();
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                list = list.Where(x => x.Name == request.Name).ToList();
            }
            return new ModelResult { Data = list };
        }
    }
}