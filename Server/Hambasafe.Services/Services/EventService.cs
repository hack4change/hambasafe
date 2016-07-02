using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Exceptions;
using Hambasafe.Services.Helper;
using Microsoft.Data.Entity;

namespace Hambasafe.Services.Services
{
    public interface IEventService
    {
        Task<List<Event>> FindAll();
        Task<List<Event>> FindBySuburb(string suburb);
        Task<List<Event>> FindByCoordinates(double latitude, double longitude, double distance);
        Task<Event> FindById(int id);
        Task<int> Add(Event @event);
        Task<bool> DeleteById(int id);
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
                                         .Where(e => !e.IsDeleted.HasValue || e.IsDeleted.Value == false)
                                         .Include(e => e.OwnerUser)
                                         .Include(e => e.EventType)
                                         .Include(e => e.StartLocation)
                                         .Include(e => e.EndLocation)
                                         .ToListAsync();
        }

        public async Task<List<Event>> FindBySuburb(string suburb)
        {
            return await _eventRepository.FindAll(e => e.StartLocation.Suburb.StartsWith(suburb, StringComparison.OrdinalIgnoreCase))
                                         .Where(e => !e.IsDeleted.HasValue || e.IsDeleted.Value == false)
                                         .Include(e => e.OwnerUser)
                                         .Include(e => e.EventType)
                                         .Include(e => e.StartLocation)
                                         .Include(e => e.EndLocation)
                                         .ToListAsync();
        }

        public async Task<List<Event>> FindByCoordinates(double latitude, double longitude, double distance)
        {
            // Unfortunately DbGeography is not implemented in EF7 - will have to fetch all locations with coordinates and then manually calculate distance
            var locations = await _eventLocationRepository.FindAll(el => el.Latitude.HasValue && el.Longitude.HasValue)
                                                          .Select(el => new { el.Id, Latitude = el.Latitude.Value, Longitude = el.Longitude.Value })
                                                          .ToListAsync();

            var locationIds = locations.Where(l => DistanceCalculator.Distance(l.Latitude, l.Longitude, latitude, longitude) <= distance)
                                       .Select(l => l.Id)
                                       .ToList();

            return await _eventRepository.FindAll(e => locationIds.Contains(e.StartEventLocationId))
                                         .Where(e => !e.IsDeleted.HasValue || e.IsDeleted.Value == false)
                                         .Include(e => e.OwnerUser)
                                         .Include(e => e.EventType)
                                         .Include(e => e.StartLocation)
                                         .Include(e => e.EndLocation)
                                         .ToListAsync();
        }

        public async Task<Event> FindById(int id)
        {
            return await _eventRepository.FindAll(e => e.Id == id)
                                         .Where(e => !e.IsDeleted.HasValue || e.IsDeleted.Value == false)
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

                // If the IsDeleted has not been set, then set it to false
                @event.IsDeleted = @event.IsDeleted ?? false;

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

        public async Task<bool> DeleteById(int id)
        {
            // Find the event that matches the id
            var existingEvent = await _eventRepository.First(e => e.Id == id);

            if (existingEvent == null)
            {
                throw new DataException($"Cannot find event for id:{id}");
            }

            // Do not actually delete the event as we may want to do some historic auditing on associated data - simply mark it as deleted
            existingEvent.IsDeleted = true;

            var result = await _eventRepository.Update(existingEvent);

            if (result != 1)
            {
                throw new DataException($"Expected to delete 1 event, but instead deleted {result}");
            }

            return true;
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
