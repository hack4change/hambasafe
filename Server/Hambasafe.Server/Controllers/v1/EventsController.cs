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
using System.Data.Entity;

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
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("create-event"), HttpPost]
        public async Task<HttpResponseMessage> CreateEvent(EventModel eventModel)
        {
            try
            {
                using (var dataContext = new HambasafeDataContext())
                {
                    EventLocation startLocation = InsertLocation(dataContext, eventModel.StartLocation);
                    EventLocation endLocation = null;
                    if (eventModel.EndLocation != null)
                    {
                        endLocation = InsertLocation(dataContext, eventModel.EndLocation);
                    }

                    var eventEntity = new Event()
                    {
                        //Name = eventModel.Name,
                        //Description = eventModel.Description,
                        //EventTypeId = eventModel.EventType.EventTypeId,
                        //DateTimeStart = eventModel.EventDateTimeStart,
                        //DateTimeEnd = eventModel.EventDateTimeEnd,
                        //IsPublic = eventModel.PublicEvent,
                        //MaxWaitingMinutes = eventModel.WaitMins,
                        //StartEventLocationId = startLocation.EventLocationId,
                       // EndEventLocationId = endLocation?.EventLocationId,
                        //OwnerUserId = eventModel.OwnerUser.UserId,
                        //Attributes = eventModel.Attributes,
                        //DateCreated = DateTime.Now
                    };

                    dataContext.Events.Add(eventEntity);
                    dataContext.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, new EventModel(eventEntity));
                }
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
            
                using (var context = new HambasafeDataContext())
                {



                    var entities = context.Events
                                          .Include(e => e.EventType)
                                          //.Include(e => e.EventLocation)
                                          //.Include(e => e.EventLocation1)
                                          .ToArray();

                    var events = entities.Select(e => new EventModel(e));

                    return Request.CreateResponse(HttpStatusCode.OK, events);
                }
        }

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
        [Route("events-by-attendee-id"), HttpGet]
        public async Task<HttpResponseMessage> GetEventsByAttendee(int attendeeid)
        {
            try
            {
                var context = new HambasafeDataContext();

                var events = context.Attendances.Where(a => a.UserId == attendeeid)
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
        [Route("events-by-attendee-name"), HttpGet]
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

        //[AllowAnonymous]
        //[Route("events-by-suburb"), HttpGet]
        //public async Task<HttpResponseMessage> GetEventsBySuburb(string suburbname)
        //{
        //    try
        //    {
        //        var context = new HambasafeDataContext();

        //        var events = context.Events.Where(a =>
        //            a.EventLocation.Suburb.ToUpper().Contains(suburbname.ToUpper())).Select(a => new EventModel(a))
        //                                        .ToArray();

        //        return Request.CreateResponse(HttpStatusCode.OK, events);
        //    }
        //    catch (Exception error)
        //    {
        //        return HandleError(error);
        //    }
        //}

        //[AllowAnonymous]
        //[Route("events-by-coordinates"), HttpGet]
        //public async Task<HttpResponseMessage> GetEventsByCoordinates(double latitude, double longitude, int radius)
        //{
        //    try
        //    {
        //        var context = new HambasafeDataContext();

        //        var locationids = context.EventLocations.Where(a => a.Latitude != null && a.Longitude != null && GetDistance(latitude, longitude, a.Latitude.Value, a.Longitude.Value) <= radius)
        //                                .Select(e => e.EventLocationId)
        //                                .ToArray();

        //        var events = context.Events.Where(a => locationids.Contains(
        //            a.EventLocation.EventLocationId)).Select(a => new EventModel(a))
        //                                        .ToArray();

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch (Exception error)
        //    {
        //        return HandleError(error);
        //    }
        //}

        private double GetDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            GeoCoordinate coord1 = new GeoCoordinate(latitude1, longitude1);
            GeoCoordinate coord2 = new GeoCoordinate(latitude2, longitude2);

            return coord1.GetDistanceTo(coord2);
        }

        private EventLocation InsertLocation(HambasafeDataContext dataContext, EventLocationModel locationModel)
        {
            var location = new EventLocation()
            {
                Address = locationModel.Address,
                Country = locationModel.Country,
                Latitude = locationModel.Latitude,
                Longitude = locationModel.Longitude,
                PostCode = locationModel.PostCode,
                Province = locationModel.Province,
                Suburb = locationModel.Suburb
            };
          //  dataContext.EventLocations.Add(location);
            dataContext.SaveChanges();

            return location;
        }
    }
}
