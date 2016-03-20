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
    public class CountryModel
    {
        public CountryModel(Entities.Country country)
        {
            CountryId = country.CountryId;
            Name = country.Name;
            Code = country.Code;
        }

        public CountryModel()
        {
        }

        public int CountryId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

    }
}