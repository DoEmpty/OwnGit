using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HouseRepository
    {
        public static List<HouseEnt> QueryHousesByAreaID(int areaId,int pageStart, int pageEnd)
        {
            var sql = @"select a.ID,b.Name as AreaName,a.Community,a.Type,a.FloorType,a.Direction,a.DecorateType,a.AreaId,a.Age,a.CreateUserType,a.CreateTime,a.ContactMobile,a.Memo,
    c.TotalPrice,c.FirstRate,d.LivingroomCount,d.BedroomCount,d.KitchenCount,d.BathroomCount,e.image
    from house as a
    inner join area as b
    on a.AreaId=b.ID
    left join houseprice as c
    on a.ID=c.HouseID
    left join houseroom as d
    on a.ID=d.HouseID
    left join houseimage as e
    on a.ID=e.HouseID and e.IsDefault
    where a.AreaID=@AreaID
    order by a.ID desc 
    limit @PageStart,@PageEnd";
            var houses = DBHelper<HouseEnt>.Query(sql, new { AreaID = areaId, PageStart = pageStart, PageEnd = pageEnd });
            return houses;
        }
    }
}
