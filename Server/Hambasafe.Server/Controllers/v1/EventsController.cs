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

        /// <summary>
        /// Not implemented
        /// </summary>
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
                    Description = eventModel.Description,
                    DateTimeStart = eventModel.EventDateTimeStart,
                    DateTimeEnd = eventModel.EventDateTimeEnd,
                    IsPublic = eventModel.PublicEvent,
                    MaxWaitingMinutes = eventModel.WaitMins,
                    StartEventLocationId = eventModel.StartLocation.EventLocationId,
                    EndEventLocationId = eventModel.EndLocation == null ? (int?)null : eventModel.EndLocation.EventLocationId,
                    OwnerUserId = eventModel.OwnerUser.UserId,
                    Attributes = eventModel.Attributes,
                    DateCreated = DateTime.Now
                };

                dataContext.Events.Add(eventEntity);
                dataContext.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, new EventModel(eventEntity));
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
                var context = new HambasafeDataContext();

                var entities = context.Events
                                      .Include("EventType")
                                      .Include("EventLocation")
                                      .Include("EventLocation1")
                                      .ToArray();

                var events = entities.Select(e => new EventModel(e));

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
                var context = new HambasafeDataContext();

                var userIds = context.Users.Where(a => a.FirstNames.ToUpper().Contains(attendeename.ToUpper()) ||
                                                       a.LastName.ToUpper().Contains(attendeename.ToUpper()))
                                        .Select(e => e.UserId)
                                        .ToArray();

                var events = context.Attendances.Where(a => userIds.Contains(a.UserId))
                                                .Select(a => new EventModel(a.Event))
                                                .ToArray();
                                
                return Request.CreateResponse(HttpStatusCode.OK, events);
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
                var context = new HambasafeDataContext();

                var events = context.Events.Where(a => 
                    a.EventLocation.Suburb.Name.ToUpper().Contains(suburbname.ToUpper())).Select(a => new EventModel(a))
                                                .ToArray();

                return Request.CreateResponse(HttpStatusCode.OK, events);
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
                var context = new HambasafeDataContext();

                var events = context.Events.Where(a =>
                    a.EventLocation.Suburb.SuburbId == suburbid).Select(a => new EventModel(a))
                                                .ToArray();

                return Request.CreateResponse(HttpStatusCode.OK, events);
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
                var context = new HambasafeDataContext();

                var suburbIds = context.Suburbs.Where(a => GetDistance(latitude, longitude, a.Latitude, a.Longitude) <= radius)
                                        .Select(e => e.SuburbId)
                                        .ToArray();

                var events = context.Events.Where(a => suburbIds.Contains(
                    a.EventLocation.Suburb.SuburbId)).Select(a => new EventModel(a))
                                                .ToArray();

                return Request.CreateResponse(HttpStatusCode.OK, events);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        public double GetDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            GeoCoordinate coord1 = new GeoCoordinate(latitude1, longitude1);
            GeoCoordinate coord2 = new GeoCoordinate(latitude2, longitude2);

            return coord1.GetDistanceTo(coord2);
        }
    }
}
