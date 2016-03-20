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
        private int _eventID;
        private string _name;
        private string _description;
        private EventTypeModel _eventType;
        private DateTime _eventDateTimeStart;
        private DateTime? _eventDateTimeEnd;
        //private string _startAddress;
        //private SuburbModel _startSuburb;
        //private string _endAddress;
        //private SuburbModel _endSuburb;
        private object _attributes;
        private int _waitMins;
        private bool? _publicEvent;

        public EventModel()
        {

        }

        public EventModel(Entities.Event dbEvent)
        {
            _eventID = dbEvent.EventId;
            _name = dbEvent.Name;
            _description = dbEvent.Description;
            _eventType = new EventTypeModel(dbEvent.EventType);
            _eventDateTimeStart = dbEvent.DateTimeStart;
            _eventDateTimeEnd = dbEvent.DateTimeEnd;
            //_startAddress = dbEvent.Address;
            //_startSuburb = new SuburbModel(dbEvent.Suburb);
            //_endAddress = dbEvent.Address;
            //_endSuburb = new SuburbModel(dbEvent.Suburb);
            _attributes = dbEvent.Attributes;
            _waitMins = dbEvent.MaxWaitingMinutes;
            //_publicEvent = dbEvent.PublicEvent;
        }

        public int EventID
        {
            get { return _eventID; }
            set { _eventID = value; }
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

        //public string StartAddress
        //{
        //    get { return _startAddress; }
        //    set { _startAddress = value; }
        //}

        //public SuburbModel StartSuburb
        //{
        //    get { return _startSuburb; }
        //    set { _startSuburb = value; }
        //}

        //public string EndAddress
        //{
        //    get { return _endAddress; }
        //    set { _endAddress = value; }
        //}

        //public SuburbModel EndSuburb
        //{
        //    get { return _endSuburb; }
        //    set { _endSuburb = value; }
        //}

        public object Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        public int WaitMins
        {
            get { return _waitMins; }
            set { _waitMins = value; }
        }

        public bool? PublicEvent
        {
            get { return _publicEvent; }
            set { _publicEvent = value; }
        }
    }
}