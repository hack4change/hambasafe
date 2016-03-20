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
    public class SuburbModel
    {
        public SuburbModel(Entities.Suburb suburb)
        {
            SuburbId = suburb.SuburbId;
            Name = suburb.Name;
            Latitude = suburb.Latitude;
            Longitude = suburb.Longitude;
            PostalCode = suburb.PostalCode;
            Province = new ProvinceModel(suburb.Province);
        }

        public SuburbModel()
        {
        }

        public int SuburbId { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string PostalCode { get; set; }

        public ProvinceModel Province { get; set; }
    }
}