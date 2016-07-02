using System;

namespace Hambasafe.Api.Models.v1
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EventTypeModel EventType { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime? DateTimeEnd { get; set; }
        public string Attributes { get; set; }
        public short MaxWaitingMinutes { get; set; }
        public bool? IsPublic { get; set; }
        public decimal? Distance { get; set; }
        public string Intensity { get; set; }
        public EventLocationModel StartLocation { get; set; }
        public EventLocationModel EndLocation { get; set; }
        public UserModel OwnerUser { get; set; }
    }
}