using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Exceptions;
using Microsoft.AspNet.Http.Features;
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

        public async Task<List<Event>> FindAll()
        {
            return await _repository.FindAll()
                                    .Include(e => e.OwnerUser)
                                    .Include(e => e.EventType)
                                    .Include(e => e.StartLocation)
                                    .Include(e => e.EndLocation)
                                    .ToListAsync();
        }

        public async Task<Event> FindById(int id)
        {
            return await _repository.FindAll(e => e.Id == id)
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
                return await _repository.Add(@event);
            }
            catch (DbUpdateException ex)
            {
                throw new DataException("Error occured while adding an Event", ex.InnerException);
            }
        }
    }
}
