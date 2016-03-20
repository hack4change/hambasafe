using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hambasafe.DataAccess;

namespace Hambasafe.Server.Models.v1
{
    public class EventLocation
    {
        public EventLocation() { }
        public EventLocation(DataAccess.Entities.EventLocation location)
        {
            Id = location.EventLocationId;
            SuburbId = location.SuburbId;
            Address = location.Address;
            Latitude = location.Latitude;
            Longitude = location.Longitude;

        }

        public int? Id { get; set; }
        public int SuburbId { get; set; }
        public string Address { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
    }
}