using MySql.Data.MySqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository
{
    public class DBHelper
    {
        public static MySqlConnection Conn = new MySqlConnection(System.Configuration.ConfigurationManager.AppSettings["Conn"]);
    }
}
