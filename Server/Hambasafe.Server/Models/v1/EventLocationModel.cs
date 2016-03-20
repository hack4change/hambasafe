using Entities = Hambasafe.DataAccess.Entities;

namespace Hambasafe.Server.Models.v1
{
    public class EventLocationModel
    {
        public EventLocationModel()
        { }

        public EventLocationModel(Entities.EventLocation location)
        {
            EventLocationId = location.EventLocationId;
            Country = location.Country;
            Province = location.Province;
            Suburb = location.Suburb;
            PostCode = location.PostCode;
            Address = location.Address;
            Latitude = location.Latitude;
            Longitude = location.Longitude;
        }

        public int EventLocationId { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}