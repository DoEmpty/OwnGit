using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XXY.Models;

namespace XXY.Business
{
    public class HouseBus
    {
        public ModelResult GetPagedAreaHouses(HouseRequest request)
        {
            if (!request.PageIndex.HasValue)
            {
                request.PageIndex = 0;
            }
            if (!request.PageSize.HasValue)
            {
                request.PageSize = 24;
            }

            var houseEntList = HouseRepository.QueryHousesByAreaID(request.AreaID, request.PageStart, request.PageEnd);
            var result = new ModelResult();
            result.Data = houseEntList.Select(x => new HouseResult
            {
                Age = x.Age,
                AreaName = x.HouseArea.Name,
                Area = x.Area,
                Community = x.Community,
                ContactMobile = x.ContactMobile,
                CreateTime = x.CreateTime,
                CreateUserType = Utils.SystemConfigs.First(y => y.Value == x.CreateUserType).DisplayName,
                DecorateType = Utils.SystemConfigs.First(y => y.Value == x.DecorateType).DisplayName,
                Direction = x.Direction,
                FirstPrice = x.HousePrice.FirstPrice,
                TotalPrice = x.HousePrice.TotalPrice,
                FloorType = Utils.SystemConfigs.First(y => y.Value == x.FloorType).DisplayName,
                ID = x.ID,
                Images = x.HouseImages.Select(y => y.Image).ToArray(),
                Layout = $"{x.HouseRoom.BedroomCount}室{x.HouseRoom.LivingroomCount}厅{x.HouseRoom.KitchenCount}厨{x.HouseRoom.BathroomCount}卫",
                Memo = x.Memo,
                Type = Utils.SystemConfigs.First(y => y.Value == x.Type).DisplayName
            });
            return result;
        }

        public ModelResult AddHouse(HouseRequest request)
        {
            var houseEnt = new HouseEnt
            {
                AreaId = request.AreaID,
                Community = request.Community,
                Type = request.Type,
                FloorType = request.FloorType,
                Direction = request.Direction,
                DecorateType = request.DecorateType,
                Area = request.Area,
                Age = request.Age,
                CreateUserType = request.CreateUserType,
                CreateUserID = request.CreateUserID,
                CreateTime = request.CreateTime,
                ContactMobile = request.ContactMobile,
                Memo = request.Memo
            };
            houseEnt.ID = HouseRepository.AddHouse(houseEnt);

            var housePriceEnt = new HousePriceEnt
            {
                HouseID = houseEnt.ID,
                FirstPrice = request.FirstPrice,
                TotalPrice = request.TotalPrice
            };
            HouseRepository.AddHousePrice(housePriceEnt);

            var houseRoom = new HouseRoomEnt
            {
                HouseID = houseEnt.ID,
                BathroomCount = request.BathroomCount,
                BedroomCount = request.BedroomCount,
                KitchenCount = request.KitchenCount,
                LivingroomCount = request.LivingroomCount
            };
            HouseRepository.AddHouseRoom(houseRoom);

            var houseImages = request.HouseImages.Select(x => new HouseImageEnt { HouseID = houseEnt.ID, Image = x }).ToList();
            HouseRepository.AddHouseImage(houseImages);

            return new ModelResult {  Data=HouseRepository.QueryHouseByID(houseEnt.ID)};
        }
    }
}