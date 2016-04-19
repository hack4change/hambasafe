using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [AllowAnonymous]
        [Route("create-event"), HttpPost]
        public async Task<int> CreateEvent([FromBody]EventModel eventModel)
        {
            ValidateEventModel(eventModel);

            var eventEntity = _mapper.Map<Event>(eventModel);

            return await _eventService.Add(eventEntity);
        }

        [AllowAnonymous]
        [Route("event"), HttpGet]
        public async Task<EventModel> GetEvent([FromQuery]int id)
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

        [AllowAnonymous]
        [Route("events-by-suburb"), HttpGet]
        public async Task<List<EventModel>> GetEventsBySuburb([FromQuery]string suburb)
        {
            ValidateSuburb(suburb);

            var events = await _eventService.FindBySuburb(suburb);

            return _mapper.Map<List<Event>, List<EventModel>>(events);
        }

        [AllowAnonymous]
        [Route("events-by-coordinates"), HttpGet]
        public async Task<List<EventModel>> GetEventsByCoordinates([FromQuery]double latitude, [FromQuery]double longitude, [FromQuery]double distance)
        {
            ValidateCoordinates(latitude, longitude, distance);

            var events = await _eventService.FindByCoordinates(latitude, longitude, distance);

            return _mapper.Map<List<Event>, List<EventModel>>(events);
        }

        private static void ValidateEventModel(EventModel eventModel)
        {
            if (eventModel == null)
            {
                throw new ValidationException($"Invalid data for {nameof(eventModel)}");
            }

            if (eventModel.EventType == null)
            {
                throw new ValidationException("Event Type is required");
            }

            if (eventModel.StartLocation == null)
            {
                throw new ValidationException("Start Location is required");
            }

            if (eventModel.EndLocation == null)
            {
                throw new ValidationException("End Location is required");
            }

            if (eventModel.OwnerUser == null)
            {
                throw new ValidationException("Owner User is required");
            }
        }

        private static void ValidateSuburb(string suburb)
        {
            if (string.IsNullOrEmpty(suburb))
            {
                throw new ValidationException($"Parameter {nameof(suburb)} is required");
            }
        }

        private static void ValidateCoordinates(double latitude, double longitude, double distance)
        {
            if (latitude < -90 || latitude > 90)
            {
                throw new ValidationException($"Parameter {nameof(latitude)} is invalid - must be between -90 and 90");
            }

            if (longitude < -180 || longitude > 180)
            {
                throw new ValidationException($"Parameter {nameof(longitude)} is required - must be between -180 and 180");
            }

            if (distance <= default(double))
            {
                throw new ValidationException($"Parameter {nameof(distance)} is required");
            }
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

        //private double GetDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        //{
        //    GeoCoordinate coord1 = new GeoCoordinate(latitude1, longitude1);
        //    GeoCoordinate coord2 = new GeoCoordinate(latitude2, longitude2);

        //    return coord1.GetDistanceTo(coord2);
        //}
    }
}
