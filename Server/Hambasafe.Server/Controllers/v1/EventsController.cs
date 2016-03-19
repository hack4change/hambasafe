using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;

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
        [Route("events"), HttpGet]
        public async Task<HttpResponseMessage> GetEvents()
        {
            try
            {
                Models.EventModel event1 = new Models.EventModel()
                {
                    Name = "Event 1",
                    Description = "Event 1 Description",
                    EventType = new Models.EventTypeModel() { Name = "Run", Description = "Go for a nice run" },
                    EventDateTimeStart = DateTime.Now.Date.AddHours(14),
                    EventDateTimeEnd = DateTime.Now.Date.AddHours(16),
                    PublicEvent = true,
                    Distance = 4,
                    WaitMins = 5,
                    Suburb = new Models.SuburbModel() { Name = "Claremont", City = new Models.CityModel() { Name = "Cape Town", Province = new Models.ProvinceModel() { Name = "Western Cape" } } }

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
                    Suburb = new Models.SuburbModel() { Name = "Newlands", City = new Models.CityModel() { Name = "Cape Town", Province = new Models.ProvinceModel() { Name = "Western Cape" } } }

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