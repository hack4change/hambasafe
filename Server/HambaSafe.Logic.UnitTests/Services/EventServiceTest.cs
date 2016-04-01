using Hambasafe.DataAccess;
using Hambasafe.DataAccess.Entities;
using Hambasafe.Logic.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HambaSafe.Logic.UnitTests.Services
{
    public class EventServiceTest :IClassFixture<DatabaseFixture>
    {
        IEventService EventService { get; set; }
        public EventServiceTest()
        {
            var kernel = Bootstrapper.Kernel;
            EventService = kernel.Get<IEventService>();
          
        }
        [Fact]
        public async void FindAll()
        {
            var c = await EventService.FindAll();
            Assert.Equal(c.Count, 2);
        }
        [Fact]
        public async void FindById()
        {
            var c = await EventService.FindById(2);
            Assert.Equal(c.Id, 2);
        }
       

    }
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            var dbContext = new HambasafeDataContext();
            dbContext.Events.AddRange(new Event[] { new Event
            {
                Id = 1
            },
            new Event
            {
                Id = 2
            }});
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }

    }
}
