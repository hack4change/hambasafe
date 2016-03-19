using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using Hambasafe.Server.Models;
using System.Device.Location;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class EventsController : ApiControllerBase
    {
        public EventsController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        [AllowAnonymous]
        [Route("event"), HttpPost]
        public async Task<HttpResponseMessage> NewEvent(EventModel newEvent)
        {
            try
            {
               //TODO add this 

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events{id:int}"), HttpGet]
        public async Task<HttpResponseMessage> GetEvent(int id)
        {
            try
            {
                EventModel event1 = new EventModel()
                {
                    Name = "Event 1",
                    Description = "Event 1 Description",
                    EventType = new EventTypeModel() { Name = "Run", Description = "Go for a nice run" },
                    EventDateTimeStart = DateTime.Now.Date.AddHours(14),
                    EventDateTimeEnd = DateTime.Now.Date.AddHours(16),
                    PublicEvent = true,
                    Distance = 4,
                    WaitMins = 5,
                    StartAddressLines = new List<string>() { "100 Main Rd" },
                    StartSuburb = new SuburbModel() { Name = "Claremont", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },
                    EndAddressLines = new List<string>() { "100 Main Rd" },
                    EndSuburb = new SuburbModel() { Name = "Claremont", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },

                };

                return Request.CreateResponse(HttpStatusCode.OK, event1);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events{userid:int}"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsByCreator(int userid)
        {
            try
            {
                EventModel event1 = new EventModel()
                {
                    Name = "Event 1",
                    Description = "Event 1 Description",
                    EventType = new EventTypeModel() { Name = "Run", Description = "Go for a nice run" },
                    EventDateTimeStart = DateTime.Now.Date.AddHours(14),
                    EventDateTimeEnd = DateTime.Now.Date.AddHours(16),
                    PublicEvent = true,
                    Distance = 4,
                    WaitMins = 5,
                    StartAddressLines = new List<string>() { "100 Main Rd" },
                    StartSuburb = new SuburbModel() { Name = "Claremont", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },
                    EndAddressLines = new List<string>() { "100 Main Rd" },
                    EndSuburb = new SuburbModel() { Name = "Claremont", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },

                };

                return Request.CreateResponse(HttpStatusCode.OK, event1);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events{attendeeid:int}"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsByAttendee(int userid)
        {
            try
            {
                EventModel event1 = new EventModel()
                {
                    Name = "Event 1",
                    Description = "Event 1 Description",
                    EventType = new EventTypeModel() { Name = "Run", Description = "Go for a nice run" },
                    EventDateTimeStart = DateTime.Now.Date.AddHours(14),
                    EventDateTimeEnd = DateTime.Now.Date.AddHours(16),
                    PublicEvent = true,
                    Distance = 4,
                    WaitMins = 5,
                    StartAddressLines = new List<string>() { "100 Main Rd" },
                    StartSuburb = new SuburbModel() { Name = "Claremont", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },
                    EndAddressLines = new List<string>() { "100 Main Rd" },
                    EndSuburb = new SuburbModel() { Name = "Claremont", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },

                };

                return Request.CreateResponse(HttpStatusCode.OK, event1);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events/all"), HttpGet]
        public async Task<HttpResponseMessage> GetEvents()
        {
            try
            {
                EventModel event1 = new EventModel()
                {
                    Name = "Event 1",
                    Description = "Event 1 Description",
                    EventType = new EventTypeModel() { Name = "Run", Description = "Go for a nice run" },
                    EventDateTimeStart = DateTime.Now.Date.AddHours(14),
                    EventDateTimeEnd = DateTime.Now.Date.AddHours(16),
                    PublicEvent = true,
                    Distance = 4,
                    WaitMins = 5,
                    StartAddressLines = new List<string>() { "100 Main Rd" },
                    StartSuburb = new SuburbModel() { Name = "Claremont", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },
                    EndAddressLines = new List<string>() { "100 Main Rd" },
                    EndSuburb = new SuburbModel() { Name = "Claremont", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },

                };
                Models.EventModel event2 = new Models.EventModel()
                {
                    Name = "Event 2",
                    Description = "Event 2 Description",
                    EventType = new Models.EventTypeModel() { Name = "Run", Description = "Go for a nice run" },
                    EventDateTimeStart = DateTime.Now.Date.AddHours(14),
                    EventDateTimeEnd = DateTime.Now.Date.AddHours(16),
                    PublicEvent = true,
                    Distance = 4,
                    WaitMins = 5,
                    StartAddressLines = new List<string>() { "cnr Klipper Rd and Main Rd" },
                    StartSuburb = new Models.SuburbModel() { Name = "Newlands", City = new Models.CityModel() { Name = "Cape Town", Province = new Models.ProvinceModel() { Name = "Western Cape" } } },
                    EndAddressLines = new List<string>() { "cnr Woolsack Rd and Main Rd" },
                    EndSuburb = new Models.SuburbModel() { Name = "Rondebosch", City = new Models.CityModel() { Name = "Cape Town", Province = new Models.ProvinceModel() { Name = "Western Cape" } } }

                };
                var dummyEvents = new[]
                {
                    event1,
                    event2
                };

                return Request.CreateResponse(HttpStatusCode.OK, dummyEvents);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events{suburb:string}"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsSuburb(SuburbModel suburb)
        {
            try
            {
                EventModel event1 = new EventModel()
                {
                    Name = "Event 1",
                    Description = "Event 1 Description",
                    EventType = new EventTypeModel() { Name = "Run", Description = "Go for a nice run" },
                    EventDateTimeStart = DateTime.Now.Date.AddHours(14),
                    EventDateTimeEnd = DateTime.Now.Date.AddHours(16),
                    PublicEvent = true,
                    Distance = 4,
                    WaitMins = 5,
                    StartAddressLines = new List<string>() { "100 Main Rd" },
                    StartSuburb = new SuburbModel() { Name = "Newlands", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },
                    EndAddressLines = new List<string>() { "100 Main Rd" },
                    EndSuburb = new SuburbModel() { Name = "Claremont", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },

                };
                Models.EventModel event2 = new Models.EventModel()
                {
                    Name = "Event 2",
                    Description = "Event 2 Description",
                    EventType = new Models.EventTypeModel() { Name = "Run", Description = "Go for a nice run" },
                    EventDateTimeStart = DateTime.Now.Date.AddHours(14),
                    EventDateTimeEnd = DateTime.Now.Date.AddHours(16),
                    PublicEvent = true,
                    Distance = 4,
                    WaitMins = 5,
                    StartAddressLines = new List<string>() { "cnr Klipper Rd and Main Rd" },
                    StartSuburb = new Models.SuburbModel() { Name = "Newlands", City = new Models.CityModel() { Name = "Cape Town", Province = new Models.ProvinceModel() { Name = "Western Cape" } } },
                    EndAddressLines = new List<string>() { "cnr Woolsack Rd and Main Rd" },
                    EndSuburb = new Models.SuburbModel() { Name = "Rondebosch", City = new Models.CityModel() { Name = "Cape Town", Province = new Models.ProvinceModel() { Name = "Western Cape" } } }

                };

                var dummyEvents = new[]
                {
                    event1,
                    event2
                };
                return Request.CreateResponse(HttpStatusCode.OK, dummyEvents);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events{longitude:double,latitude:double,radius:int}"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsGPS(double latitude, double longitude, int radius)
        {
            try
            {
                EventModel event1 = new EventModel()
                {
                    Name = "Event 1",
                    Description = "Event 1 Description",
                    EventType = new EventTypeModel() { Name = "Run", Description = "Go for a nice run" },
                    EventDateTimeStart = DateTime.Now.Date.AddHours(14),
                    EventDateTimeEnd = DateTime.Now.Date.AddHours(16),
                    PublicEvent = true,
                    Distance = 4,
                    WaitMins = 5,
                    StartAddressLines = new List<string>() { "100 Main Rd" },
                    StartSuburb = new SuburbModel() { Name = "Newlands", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },
                    EndAddressLines = new List<string>() { "100 Main Rd" },
                    EndSuburb = new SuburbModel() { Name = "Claremont", City = new CityModel() { Name = "Cape Town", Province = new ProvinceModel() { Name = "Western Cape" } } },

                };
                Models.EventModel event2 = new Models.EventModel()
                {
                    Name = "Event 2",
                    Description = "Event 2 Description",
                    EventType = new Models.EventTypeModel() { Name = "Run", Description = "Go for a nice run" },
                    EventDateTimeStart = DateTime.Now.Date.AddHours(14),
                    EventDateTimeEnd = DateTime.Now.Date.AddHours(16),
                    PublicEvent = true,
                    Distance = 4,
                    WaitMins = 5,
                    StartAddressLines = new List<string>() { "cnr Klipper Rd and Main Rd" },
                    StartSuburb = new Models.SuburbModel() { Name = "Newlands", City = new Models.CityModel() { Name = "Cape Town", Province = new Models.ProvinceModel() { Name = "Western Cape" } } },
                    EndAddressLines = new List<string>() { "cnr Woolsack Rd and Main Rd" },
                    EndSuburb = new Models.SuburbModel() { Name = "Rondebosch", City = new Models.CityModel() { Name = "Cape Town", Province = new Models.ProvinceModel() { Name = "Western Cape" } } }

                };

                var dummyEvents = new[]
                {
                    event1,
                    event2
                };
                return Request.CreateResponse(HttpStatusCode.OK, dummyEvents);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
