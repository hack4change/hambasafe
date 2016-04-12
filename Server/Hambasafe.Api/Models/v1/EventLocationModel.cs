namespace Hambasafe.Api.Models.v1
{
    public class EventLocationModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}