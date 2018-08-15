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
        public static HouseEnt QueryHouseByID(int houseID)
        {
            var sql = @"select a.ID,a.Community,a.Type,a.FloorType,a.Direction,a.DecorateType,a.AreaId,a.Age,a.CreateUserType,a.CreateTime,a.ContactMobile,a.Memo,
    b.ID,b.Name,c.ID,c.TotalPrice,c.FirstPrice,d.ID,d.LivingroomCount,d.BedroomCount,d.KitchenCount,d.BathroomCount,e.ID,e.image
    from house as a
    inner join area as b
    on a.AreaId=b.ID
    left join houseprice as c
    on a.ID=c.HouseID
    left join houseroom as d
    on a.ID=d.HouseID
    left join houseimage as e
    on a.ID=e.HouseID
    where a.HouseID=@HouseID;";
            return DBHelper.Conn.Query<HouseEnt, AreaEnt, HousePriceEnt, HouseRoomEnt, HouseImageEnt, HouseEnt>(
               sql,
               (house, area, price, room, image) =>
               {
                   house.HouseArea = area;
                   house.HousePrice = price;
                   house.HouseRoom = room;
                   return house;
               },
               new { HouseID = houseID },
               null, true).FirstOrDefault();
        }

        public static List<HouseEnt> QueryHousesByAreaID(int areaId, int pageStart, int pageEnd)
        {
            var sql = @"select a.ID,a.Community,a.Type,a.FloorType,a.Direction,a.DecorateType,a.AreaId,a.Age,a.CreateUserType,a.CreateTime,a.ContactMobile,a.Memo,
    b.ID,b.Name,c.ID,c.TotalPrice,c.FirstPrice,d.ID,d.LivingroomCount,d.BedroomCount,d.KitchenCount,d.BathroomCount,e.ID,e.image
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
            DBHelper.Conn.Query<HouseEnt, AreaEnt, HousePriceEnt, HouseRoomEnt, HouseImageEnt, HouseEnt>(
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
                null, true);
            return houses.Values.ToList();
        }

        public static int AddHouse(HouseEnt houseEnt)
        {
            var sql = @"insert into house(AreaID,Community,Type,FloorType,Direction,DecorateType,Area,Age,CreateUserType,CreateUserID,CreateTime,ContactMobile,Memo)
values(@AreaID,@Community,@Type,@FloorType,@Direction,@DecorateType,@Area,@Age,@CreateUserType,@CreateUserID,@CreateTime,@ContactMobile,@Memo);
select @@IDENTITY;";
            return DBHelper.Conn.ExecuteScalar<int>(sql,
                new
                {
                    houseEnt.AreaId,
                    houseEnt.Community,
                    houseEnt.Type,
                    houseEnt.FloorType,
                    houseEnt.Direction,
                    houseEnt.DecorateType,
                    houseEnt.Area,
                    houseEnt.Age,
                    houseEnt.CreateUserType,
                    houseEnt.CreateUserID,
                    houseEnt.CreateTime,
                    houseEnt.ContactMobile,
                    houseEnt.Memo
                });
        }

        public static int AddHousePrice(HousePriceEnt priceEnt)
        {
            var sql = @"insert into houseprice(HouseID,TotalPrice,FirstPrice)
values(@HouseID,@TotalPrice,@FirstPrice);";
            return DBHelper.Conn.Execute(sql, new { HouseID = priceEnt.HouseID, TotalPrice = priceEnt.TotalPrice, FirstPrice = priceEnt.FirstPrice });
        }

        public static int AddHouseImage(List<HouseImageEnt> images)
        {
            var sql = @"insert into houseimage(HouseID,Image,IsDefault)
values(@HouseID,@Image,@IsDefault);";
            return DBHelper.Conn.Execute(sql, images);
        }

        public static int AddHouseRoom(HouseRoomEnt roomEnt)
        {
            var sql = @"insert into houseroom(HouseID,LivingroomCount,BedroomCount,KitchenCount,BathroomCount)
values(@HouseID,@LivingroomCount,@BedroomCount,@KitchenCount,@BathroomCount);";
            return DBHelper.Conn.Execute(sql, roomEnt);
        }
    }
}
