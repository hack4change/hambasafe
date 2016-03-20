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
        private int _provinceID;
        private string _name;
        private CountryModel _country;

        public ProvinceModel()
        {

        }

        public ProvinceModel(Entities.Province province)
        {
            _provinceID = province.ProvinceId;
            _name = province.Name;
            _country = new CountryModel(province.Country);
        }

        public int ProvinceID
        {
            get { return _provinceID; }
            set { _provinceID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public CountryModel Country
        {
            get { return _country; }
            set { _country = value; }
        }

    }
}