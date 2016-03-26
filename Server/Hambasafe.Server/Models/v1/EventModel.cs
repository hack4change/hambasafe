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
        

        public EventModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public EventTypeModel EventType { get; set; }

        public DateTime DateTimeStart { get; set; }

        public DateTime? DateTimeEnd { get; set; }

        public string Attributes { get; set; }

        public short WaitMins { get; set; }

        public bool? IsPublic { get; set; }

        public EventLocationModel StartLocation { get; set; }

        public EventLocationModel EndLocation { get; set; }

        public UserModel OwnerUser { get; set; }
    }
}