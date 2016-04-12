﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Microsoft.Data.Entity;

namespace Hambasafe.Services.Services
{
    public interface IEventService
    {
        Task<List<Event>> FindAll();
        Task<Event> FindById(int id);
        Task<int> Add(Event @event);
    }

    public class EventService : IEventService
    {
        private readonly IRepository<Event> _repository;

        public EventService(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public Task<List<Event>> FindAll()
        {
            return _repository.FindAll()
                             .Include(e => e.OwnerUser)
                             .Include(e => e.EventType)
                             .Include(e => e.StartLocation)
                             .Include(e => e.EndLocation)
                             .ToListAsync();
        }

        public Task<Event> FindById(int id)
        {
            return Repository.FindAll(e => e.Id == id)
                             .Include(e => e.OwnerUser)
                             .Include(e => e.EventType)
                             .Include(e => e.StartLocation)
                             .Include(e => e.EndLocation)
                             .FirstOrDefaultAsync();
        }

        public Task<int> Add(Event @event)
        {
            return Repository.Add(@event);
        }
    }
}
