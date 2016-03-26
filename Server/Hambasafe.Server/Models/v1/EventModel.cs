using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Entities = Hambasafe.DataAccess.Entities;

namespace Hambasafe.Server.Models.v1
{
    public class EventModel
    {
        public EventModel(Entities.Event dbEvent)
        {
            Id = dbEvent.Id;
            Name = dbEvent.Name;
            Description = dbEvent.Description;
            EventType = dbEvent.EventType == null ? null : new EventTypeModel(dbEvent.EventType);
            EventDateTimeStart = dbEvent.DateTimeStart;
            EventDateTimeEnd = dbEvent.DateTimeEnd;
            Attributes = dbEvent.Attributes;
            WaitMins = dbEvent.MaxWaitingMinutes;
            PublicEvent = dbEvent.IsPublic;
            StartLocation = dbEvent.StartEventLocation == null ? null : new EventLocationModel(dbEvent.StartEventLocation);
            EndLocation = dbEvent.EndEventLocation == null ? null : new EventLocationModel(dbEvent.EndEventLocation);
            //    OwnerUser = dbEvent.User == null ? null : new UserModel(dbEvent.User);
        }

        public EventModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public EventTypeModel EventType { get; set; }

        public DateTime EventDateTimeStart { get; set; }

        public DateTime? EventDateTimeEnd { get; set; }

        public string Attributes { get; set; }

        public short WaitMins { get; set; }

        public bool? PublicEvent { get; set; }

        public EventLocationModel StartLocation { get; set; }

        public EventLocationModel EndLocation { get; set; }

        public UserModel OwnerUser { get; set; }
    }
}