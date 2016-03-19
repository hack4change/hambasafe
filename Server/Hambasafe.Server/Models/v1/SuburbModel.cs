using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;
using System.Web.Http;

namespace Hambasafe.Server.Models
{
    [RoutePrefix("v1")]
    public class SuburbModel
    {
        private string _name;
        private GeoCoordinate _coord;
        private ProvinceModel _province;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public GeoCoordinate Coord
        {
            get { return _coord; }
            set { _coord = value; }
        }

        public ProvinceModel Province
        {
            get { return _province; }
            set { _province = value; }
        }
    }
}