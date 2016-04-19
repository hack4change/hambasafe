﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Exceptions;
using Microsoft.Data.Entity;

namespace Hambasafe.Services.Services
{
    public interface IEventService
    {
        Task<List<Event>> FindAll();
        Task<List<Event>> FindBySuburb(string suburb);
        Task<List<Event>> FindByCoordinates(decimal latitude, decimal longitude, decimal distance);
        Task<Event> FindById(int id);
        Task<int> Add(Event @event);
    }

    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;
        private readonly IRepository<EventType> _eventTypeRepository;
        private readonly IRepository<EventLocation> _eventLocationRepository;
        private readonly IRepository<User> _userRepository;

        public EventService(IRepository<Event> eventRepository, IRepository<EventType> eventTypeRepository, IRepository<EventLocation> eventLocationRepository, IRepository<User> userRepository)
        {
            _eventRepository = eventRepository;
            _eventTypeRepository = eventTypeRepository;
            _eventLocationRepository = eventLocationRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Event>> FindAll()
        {
            return await _eventRepository.FindAll()
                                         .Include(e => e.OwnerUser)
                                         .Include(e => e.EventType)
                                         .Include(e => e.StartLocation)
                                         .Include(e => e.EndLocation)
                                         .ToListAsync();
        }

        public async Task<List<Event>> FindBySuburb(string suburb)
        {
            return await _eventRepository.FindAll(e => e.StartLocation.Suburb.Equals(suburb, StringComparison.OrdinalIgnoreCase)) 
                                         .Include(e => e.OwnerUser)
                                         .Include(e => e.EventType)
                                         .Include(e => e.StartLocation)
                                         .Include(e => e.EndLocation)
                                         .ToListAsync();
        }

        public async Task<List<Event>> FindByCoordinates(decimal latitude, decimal longitude, decimal distance)
        {
            // TODO : Wire up DbGeography specific coordinate search logic
            return await FindAll();

            ////var locationids = context.EventLocations.Where(a => a.Latitude != null && a.Longitude != null && GetDistance(latitude, longitude, a.Latitude.Value, a.Longitude.Value) <= radius)
            ////                            .Select(e => e.EventLocationId)
            ////                            .ToArray();

            ////var events = context.Events.Where(a => locationids.Contains(
            ////    a.EventLocation.EventLocationId)).Select(a => new EventModel(a))
            ////                                .ToArray();
        }

        public async Task<Event> FindById(int id)
        {
            return await _eventRepository.FindAll(e => e.Id == id)
                                         .Include(e => e.OwnerUser)
                                         .Include(e => e.EventType)
                                         .Include(e => e.StartLocation)
                                         .Include(e => e.EndLocation)
                                         .FirstOrDefaultAsync();
        }

        public async Task<int> Add(Event @event)
        {
            try
            {
                @event.EventTypeId = await GetEventTypeId(@event.EventTypeId, @event.EventType);
                @event.StartEventLocationId = await GetEventLocationId(@event.StartEventLocationId, @event.StartLocation);
                @event.EndEventLocationId = await GetEventLocationId(@event.EndEventLocationId, @event.EndLocation);
                @event.OwnerUserId = await GetUserId(@event.OwnerUserId, @event.OwnerUser);

                var result = await _eventRepository.Add(@event);

                if (result != 1)
                {
                    throw new DataException($"Expected to add 1 event, but instead added {result}");
                }

                return @event.Id;
            }
            catch (DbUpdateException ex)
            {
                throw new DataException("Error occured while adding an Event", ex.InnerException);
            }
        }

        private async Task<int> GetEventTypeId(int id, EventType eventType)
        {
            if (id > default(int))
            {
                return id;
            }

            if (eventType.Id > default(int))
            {
                return eventType.Id;
            }

            // Load event type by name if we do not have an Id
            var type = await _eventTypeRepository.First(et => et.Name.Equals(eventType.Name));
            if (type != null)
            {
                return type.Id;
            }
            else
            {
                throw new DataException($"Unknown EventType - {eventType.Name}");
            }
        }

        private async Task<int> GetEventLocationId(int id, EventLocation eventLocation)
        {
            if (id > default(int))
            {
                return id;
            }

            if (eventLocation.Id > default(int))
            {
                return eventLocation.Id;
            }

            // Load the event location by address and suburb if we do not have an Id
            var location = await _eventLocationRepository.First(el => el.Address.Equals(eventLocation.Address) && el.Suburb.Equals(eventLocation.Suburb));
            if (location != null)
            {
                return location.Id;
            }
            else
            {
                // If it does not exist, then create a new location
                await _eventLocationRepository.Add(eventLocation);

                return eventLocation.Id;
            }
        }

        private async Task<int> GetUserId(int id, User ownerUser)
        {
            if (id > default(int))
            {
                return id;
            }

            if (ownerUser.Id > default(int))
            {
                return ownerUser.Id;
            }

            // Load user by emailaddress if we do not have an Id
            var user = await _userRepository.First(et => et.EmailAddress.Equals(ownerUser.EmailAddress));
            if (user != null)
            {
                return user.Id;
            }
            else
            {
                throw new DataException($"Unknown User - {ownerUser.EmailAddress}");
            }
        }
    }
}
