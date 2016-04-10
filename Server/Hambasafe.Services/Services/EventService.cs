using System.Collections.Generic;
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
    }

    public class EventService : ServiceBase<Event>, IEventService
    {
        public EventService(IRepository<Event> repository) : base(repository)
        {
        }

        public Task<List<Event>> FindAll()
        {
            return Repository.FindAll()
                             .Include(e => e.OwnerUser)
                             .Include(e => e.EventType)
                             .Include(e => e.StartLocation)
                             .Include(e => e.EndLocation)
                             .ToListAsync();
        }

        public Task<Event> FindById(int id)
        {
            return Repository.First(e => e.Id == id);
        }
    }
}
