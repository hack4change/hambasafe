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
        private int _suburbID;
        private string _name;
        private GeoCoordinate _coord;
        private ProvinceModel _province;
        private string _postalCode;

        public SuburbModel()
        {
            
        }

        public SuburbModel(Entities.Suburb suburb)
        {
            _suburbID = suburb.SuburbId;
            _name = suburb.Name;
            _coord = new GeoCoordinate(suburb.Latitude, suburb.Longitude);
            _postalCode = suburb.PostalCode;
            _province = new ProvinceModel(suburb.Province);
        }

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