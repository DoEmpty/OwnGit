using MySql.Data.MySqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DBHelper<T> where T:new()
    {
        public static MySqlConnection Conn = new MySqlConnection(System.Configuration.ConfigurationManager.AppSettings["Conn"]);

        public static bool Insert(string sql, object parameter)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                return false;
            }
            return Conn.Execute(sql, parameter) >0;
        }

        public static List<T> Query(string sql, object parameter)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                return null;
            }
            return Conn.Query<T>(sql, parameter).ToList();
        }
    }
}
