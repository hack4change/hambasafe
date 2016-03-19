﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Hambasafe.Server.Models
{
    [RoutePrefix("v1")]
    public class EventModel
    {
        private string _name;
        private string _description;
        private EventTypeModel _eventType;
        private DateTime _eventDateTimeStart;
        private DateTime? _eventDateTimeEnd;
        private List<string> _addressLines;
        private SuburbModel _suburb;
        private object _attributes;
        private double _distance;
        private int _waitMins;
        private bool _publicEvent;

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

        public EventTypeModel EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        public DateTime EventDateTimeStart
        {
            get { return _eventDateTimeStart; }
            set { _eventDateTimeStart = value; }
        }

        public DateTime? EventDateTimeEnd
        {
            get { return _eventDateTimeEnd; }
            set { _eventDateTimeEnd = value; }
        }

        public List<string> AddressLines
        {
            get { return _addressLines; }
            set { _addressLines = value; }
        }

        public SuburbModel Suburb
        {
            get { return _suburb; }
            set { _suburb = value; }
        }

        public object Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public int WaitMins
        {
            get { return _waitMins; }
            set { _waitMins = value; }
        }

        public bool PublicEvent
        {
            get { return _publicEvent; }
            set { _publicEvent = value; }
        }
    }
}