using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Utils
    {
        private static List<SystemConfigEnt> systemConfigs;
        public static List<SystemConfigEnt> SystemConfigs
        {
            get
            {
                if (systemConfigs == null)
                {
                    systemConfigs = SystemConfigRepository.QueryAllSystemConfigs();                    
                }
                return systemConfigs;
            }
        }
    }
}
