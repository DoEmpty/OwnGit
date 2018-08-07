using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SystemConfigRepository
    {
        public static List<SystemConfigEnt> QueryAllSystemConfigs()
        {
            var sql = "select ID,Name,DisplayName,Value,IsDefault from systemconfig;";
            return DBHelper.Conn.Query<SystemConfigEnt>(sql).AsList();
        }
    }
}
