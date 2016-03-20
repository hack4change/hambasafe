using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Entities = Hambasafe.DataAccess.Entities;

namespace Hambasafe.Server.Models.v1
{
    [RoutePrefix("v1")]
    public class EventModel
    {
        public EventModel(Entities.Event dbEvent)
        {
            EventId = dbEvent.EventId;
            Name = dbEvent.Name;
            Description = dbEvent.Description;
            EventType = new EventTypeModel(dbEvent.EventType);
            EventDateTimeStart = dbEvent.DateTimeStart;
            EventDateTimeEnd = dbEvent.DateTimeEnd;
            Attributes = dbEvent.Attributes;
            WaitMins = dbEvent.MaxWaitingMinutes;
            PublicEvent = dbEvent.IsPublic;
        }

        public EventModel()
        {
        }

        public int EventId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public EventTypeModel EventType { get; set; }

        public DateTime EventDateTimeStart { get; set; }

        public DateTime? EventDateTimeEnd { get; set; }

        public object Attributes { get; set; }

        public int WaitMins { get; set; }

        public bool? PublicEvent { get; set; }
    }
}