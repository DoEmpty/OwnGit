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
            result.Data = houseEntList.Select(x => new HouseResponse
            {
                Age = x.Age,
                AreaName = x.AreaName,
                Area = x.Area,
                Community = x.Community,
                ContactMobile = x.ContactMobile,
                CreateTime = x.CreateTime,
                CreateUserType = Utils.SystemConfigs.First(y => y.ID == x.CreateUserType).DisplayName,
                DecorateType = Utils.SystemConfigs.First(y => y.ID == x.DecorateType).DisplayName,
                Direction = x.Direction,
                FirstPrice = x.TotalPrice * x.FirstRate,
                TotalPrice = x.TotalPrice,
                FloorType = Utils.SystemConfigs.First(y => y.ID == x.FloorType).DisplayName,
                ID = x.ID,
                DefaultImage = x.Image,
                Layout = $"{x.BedroomCount}室{x.LivingroomCount}厅{x.KitchenCount}厨{x.BathroomCount}卫",
                Memo = x.Memo,
                Type = Utils.SystemConfigs.First(y => y.ID == x.Type).DisplayName
            });
            return result;
        }
    }
}