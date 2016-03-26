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

    public interface IEventService : IRepository<Event>
    {

    }
    public class EventService : EfRepository<Event>, IEventService
    {
        public EventService(DbContext dbContext)
            : base(dbContext)
        {

        }
        public override IQueryable<Event> FindAll(Expression<Func<Event, bool>> where = null)
        {
            return base.FindAll(where).Include(e => e.EventType)
                                      .Include(e => e.StartEventLocation)
                                      .Include(e => e.EndEventLocation);
        }
    }
}
