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
        private int _countryID;
        private string _name;
        private string _code;

        public CountryModel()
        {

        }

        public CountryModel(Entities.Country country)
        {
            _countryID = country.CountryId;
            _name = country.Name;
            _code = country.Code;
        }

        public int CountryID
        {
            get { return _countryID; }
            set { _countryID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

    }
}