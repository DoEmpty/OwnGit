using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AdRepository
    {
        public static List<AdvertisingEnt> GetAdvertisings()
        {
            string sql = @"select ID,Image,Position,Url from advertising order by CreateTime desc limit 8;";
            return DBHelper.Conn.Query<AdvertisingEnt>(sql).ToList();
        }
    }
}
