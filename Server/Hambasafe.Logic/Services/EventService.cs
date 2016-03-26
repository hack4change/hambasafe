using Hambasafe.DataAccess;
using Hambasafe.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using System.Linq.Expressions;

namespace Hambasafe.Logic.Services
{

    public interface IEventService 
    {
        
        Task<List<Event>> FindAll();
        Task<Event> FindById(int id);
    }
    public class EventService :  IEventService
    {
        IRepository<Event> Repository;
        public EventService(IRepository<Event> repository)
        {
            Repository = repository;
        }
        public Task<List<Event>> FindAll()
        {
            return  Repository.FindAll().Include(e => e.EventType)
                                      .Include(e => e.StartEventLocation)
                                      .Include(e => e.EndEventLocation).ToListAsync();
        }
        public Task<Event> FindById(int id)
        {
            return Repository.First(i=>i.Id== id);
        }
    }
}
