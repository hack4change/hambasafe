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
        private int _eventTypeID;
        private string _name;
        private string _description;

        public EventTypeModel() { }

        public EventTypeModel(Entities.EventType dbEventType)
        {
            _eventTypeID = dbEventType.EventTypeId;
            _name = dbEventType.Name;
            _description = dbEventType.Description;
        }

        public int EventTypeID
        {
            get{ return _eventTypeID;}
            set{ _eventTypeID = value;} 
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}