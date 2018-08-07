using Dapper;
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
            var sql = @"select a.ID,a.Community,a.Type,a.FloorType,a.Direction,a.DecorateType,a.AreaId,a.Age,a.CreateUserType,a.CreateTime,a.ContactMobile,a.Memo,
    b.ID,b.Name,c.ID,c.TotalPrice,c.FirstRate,d.ID,d.LivingroomCount,d.BedroomCount,d.KitchenCount,d.BathroomCount,e.ID,e.image
    from house as a
    inner join area as b
    on a.AreaId=b.ID
    left join houseprice as c
    on a.ID=c.HouseID
    left join houseroom as d
    on a.ID=d.HouseID
    left join houseimage as e
    on a.ID=e.HouseID
    where a.AreaID=@AreaID
    order by a.ID desc 
    limit @PageStart,@PageEnd";
            Dictionary<int, HouseEnt> houses = new Dictionary<int, HouseEnt>();
            DBHelper.Conn.Query<HouseEnt,AreaEnt,HousePriceEnt,HouseRoomEnt,HouseImageEnt,HouseEnt>(
                sql,
                (house, area, price, room, image) =>
                {
                    if (!houses.ContainsKey(house.ID))
                    {
                        house.HouseArea = area;
                        house.HousePrice = price;
                        house.HouseRoom = room;
                        houses.Add(house.ID, house);
                    }
                    houses[house.ID].HouseImages.Add(image);
                    return houses[house.ID];
                },
                new { AreaID = areaId, PageStart = pageStart, PageEnd = pageEnd },
                null,true);
            return houses.Values.ToList();
        }

        public int AddHouse(HouseEnt houseEnt)
        {
            var sql = "select @@IDENTITY;";
            return DBHelper.Conn.ExecuteScalar<int>(sql,null);
        }
    }
}
