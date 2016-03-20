using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using Hambasafe.Server.Models.v1;
using Entities = Hambasafe.DataAccess.Entities;

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
        [Route("createevent"), HttpPost]
        public async Task<HttpResponseMessage> CreateEvent(EventModel newEvent)
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

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("event"), HttpGet]
        public async Task<HttpResponseMessage> GetEvent(int id)
        {
            try
            {
                var dataContext = new Entities.HambasafeDataContext();
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
                var dataContext = new Entities.HambasafeDataContext();
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
        [Route("eventsbyuser"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsByUser(int userid)
        {
            try
            {
                var dataContext = new Entities.HambasafeDataContext();
                var events = dataContext.Events.ToList().Where(e => e.OwnerUserId == userid).Select(e => new EventModel(e));

                return Request.CreateResponse(HttpStatusCode.OK, events);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("eventsbyattendee"), HttpGet]
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
        [Route("eventsbyattendee"), HttpGet]
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
        [Route("eventsbysuburb"), HttpGet]
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
        [Route("eventsbysuburb"), HttpGet]
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
        [Route("eventsbycoordinates"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsByCoordinates(double latitude, double longitude, int radius)
        {
            try
            {
                Entities.HambasafeDataContext context = new Entities.HambasafeDataContext();

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
