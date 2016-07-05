using System.Collections.Generic;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hambasafe.Services.Services
{
    public interface IEventTypeService
    {
        Task<List<EventType>> FindAll();
        Task<EventType> FindById(int id);
    }

    public class EventTypeService : IEventTypeService
    {
        private readonly IRepository<EventType> _repository;

        public EventTypeService(IRepository<EventType> repository)
        {
            _repository = repository;
        }

        public async Task<List<EventType>> FindAll()
        {
            return await _repository.FindAll().ToListAsync();
        }

        public async Task<EventType> FindById(int id)
        {
            return await _repository.First(et => et.Id == id);
        }
    }
}
