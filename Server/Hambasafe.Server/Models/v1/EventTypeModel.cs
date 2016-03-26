using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Entities = Hambasafe.DataAccess.Entities;

namespace Hambasafe.Server.Models.v1
{
    [RoutePrefix("v1")]
    public class EventTypeModel
    {
        public EventTypeModel(Entities.EventType dbEventType)
        {
            EventTypeId = dbEventType.Id;
            Name = dbEventType.Name;
            Description = dbEventType.Description;
        }

        public EventTypeModel()
        {

        }

        public int EventTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}