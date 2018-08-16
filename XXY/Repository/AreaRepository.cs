using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AreaRepository
    {
        public static List<AreaEnt> GetAreasByParentID(int parentId)
        {
            string sql = @"select ID,ParentID,Name from area where ParentID=@ParentID;";
            return DBHelper.Conn.Query<AreaEnt>(sql,new { ParentID = parentId }).ToList();
        }
    }
}
