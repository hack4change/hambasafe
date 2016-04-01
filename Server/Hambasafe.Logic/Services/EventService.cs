﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hambasafe.Logic.Services
{

    public interface IEventService
    {

        Task<List<Event>> FindAll();
        Task<Event> FindById(int id);
    }
    public class EventService : IEventService
    {
        IRepository<Event> Repository;
        public EventService(IRepository<Event> repository)
        {
            Repository = repository;
        }
        public Task<List<Event>> FindAll()
        {
            return Repository.FindAll()
                .Include(e => e.OwnerUser)
                .Include(e => e.EventType)
                .Include(e => e.StartLocation)
                .Include(e => e.EndLocation).ToListAsync();
        }
        public Task<Event> FindById(int id)
        {
            return Repository.First(i => i.Id == id);
        }
    }
}
