using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using Hambasafe.Server.Models.v1;
using Hambasafe.DataAccess.Entities;

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
        [Route("create-event"), HttpPost]
        public async Task<HttpResponseMessage> CreateEvent(EventModel eventModel)
        {
            try
            {
                var dataContext = new HambasafeDataContext();

                var eventEntity = new Event()
                {
                    Name = eventModel.Name,
                    
                };

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("event"), HttpGet]
        public async Task<HttpResponseMessage> GetEvent(int id)
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                var evnt = dataContext.Events.ToList().Where(e => e.EventId == id)
                                                      .Select(e => new EventModel(e))
                                                      .First();

                return Request.CreateResponse(HttpStatusCode.OK, evnt);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("events"), HttpGet]
        public async Task<HttpResponseMessage> GetEvents()
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                var events = dataContext.Events.ToList().Select(e => new EventModel(e));

                return Request.CreateResponse(HttpStatusCode.OK, events);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("events-by-user"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsByUser(int userid)
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                var events = dataContext.Events.ToList().Where(e => e.OwnerUserId == userid).Select(e => new EventModel(e));

                return Request.CreateResponse(HttpStatusCode.OK, events);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events-by-attendee"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsByAttendee(int attendeeid)
        {
            try
            {
                //TODO implement
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events-by-attendee"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsByAttendeeName(string attendeename)
        {
            try
            {
                //TODO implement
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events-by-suburb"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsBySuburb(string suburbname)
        {
            try
            {
                //TODO implement
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events-by-suburb"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsBySuburb(int suburbid)
        {
            try
            {
                //TODO implement
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("events-by-coordinates"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsByCoordinates(double latitude, double longitude, int radius)
        {
            try
            {
                HambasafeDataContext context = new HambasafeDataContext();

                //TODO implement
                //var matchingLocations = context.Location

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
