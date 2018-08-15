using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XXY.Models;

namespace XXY.Business
{
    public class AdBus
    {
        public ModelResult GetAdvertsings(ModelRequest request)
        {
            var modelResult = new ModelResult();
            modelResult.Data = AdRepository.GetAdvertisings().
                Select(x => new AdResult
                {
                    ID = x.ID,
                    Image = x.Image,
                    Position = x.Position,
                    Url = x.Url
                });
            return modelResult;
        }
    }
}