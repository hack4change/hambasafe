using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;
using System.Web.Http;
using Entities = Hambasafe.DataAccess.Entities;

namespace Hambasafe.Server.Models.v1
{
    [RoutePrefix("v1")]
    public class ProvinceModel
    {
        public ProvinceModel(Entities.Province province)
        {
            ProvinceId = province.ProvinceId;
            Name = province.Name;
            Country = new CountryModel(province.Country);
        }

        public ProvinceModel()
        {
        }

        public int ProvinceId { get; set; }

        public string Name { get; set; }

        public CountryModel Country { get; set; }

    }
}