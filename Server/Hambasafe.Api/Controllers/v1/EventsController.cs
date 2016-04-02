using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Hambasafe.Api.Models.v1;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Services;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Hambasafe.Api.Controllers.v1
{
    [Route("v1/[controller]")]
    public class EventsController
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        public EventsController(IEventService eventService, IMapper mapper)

        {
            _eventService = eventService;
            _mapper = mapper;
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("create-event"), HttpPost]
        public async Task<HttpStatusCode> CreateEvent(EventModel eventModel)
        {

            using (var dataContext = new HambasafeDataContext())
            {

                var eventEntity = _mapper.Map<Event>(eventModel);
                dataContext.Events.Add(eventEntity);
                await dataContext.SaveChangesAsync();

                return HttpStatusCode.OK;
            }

        }


        [AllowAnonymous]
        [Route("event"), HttpGet]
        public async Task<EventModel> GetEvent(int id)
        {
            var eventEntity = await _eventService.FindById(id);
            return _mapper.Map<EventModel>(eventEntity);
        }


        [AllowAnonymous]
        [Route("events"), HttpGet]
        public async Task<List<EventModel>> GetEvents()
        {
            var events = await _eventService.FindAll();
            return _mapper.Map<List<Event>, List<EventModel>>(events);

        }

        //[AllowAnonymous]
        //[Route("events-by-user"), HttpGet]
        //public async Task<HttpResponseMessage> GetEventsByUser(int userid)
        //{
        //    try
        //    {
        //        var dataContext = new HambasafeDataContext();
        //        var events = dataContext.Events.ToList().Where(e => e.OwnerUserId == userid).Select(e => new EventModel(e));

        //        return Request.CreateResponse(HttpStatusCode.OK, events);
        //    }
        //    catch (Exception error)
        //    {
        //        return HandleError(error);
        //    }
        //}

        //[AllowAnonymous]
        //[Route("events-by-attendee-id"), HttpGet]
        //public async Task<HttpResponseMessage> GetEventsByAttendee(int attendeeid)
        //{
        //    try
        //    {
        //        var context = new HambasafeDataContext();

        //        var events = context.Attendances.Where(a => a.UserId == attendeeid)
        //                                        .Select(a => new EventModel(a.Event))
        //                                        .ToArray();

        //        return Request.CreateResponse(HttpStatusCode.OK, events);
        //    }
        //    catch (Exception error)
        //    {
        //        return HandleError(error);
        //    }
        //}

        //[AllowAnonymous]
        //[Route("events-by-attendee-name"), HttpGet]
        //public async Task<HttpResponseMessage> GetEventsByAttendeeName(string attendeename)
        //{
        //    try
        //    {
        //        var context = new HambasafeDataContext();

        //        var userIds = context.Users.Where(a => a.FirstNames.ToUpper().Contains(attendeename.ToUpper()) ||
        //                                               a.LastName.ToUpper().Contains(attendeename.ToUpper()))
        //                                .Select(e => e.Id)
        //                                .ToArray();

        //        var events = context.Attendances.Where(a => userIds.Contains(a.UserId))
        //                                        .Select(a => new EventModel(a.Event))
        //                                        .ToArray();

        //        return Request.CreateResponse(HttpStatusCode.OK, events);
        //    }
        //    catch (Exception error)
        //    {
        //        return HandleError(error);
        //    }
        //}

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

        //private double GetDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        //{
        //    GeoCoordinate coord1 = new GeoCoordinate(latitude1, longitude1);
        //    GeoCoordinate coord2 = new GeoCoordinate(latitude2, longitude2);

        //    return coord1.GetDistanceTo(coord2);
        //}


    }
}
