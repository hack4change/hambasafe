using System;
using Autofac;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Services;
using Hambasafe.Logic.UnitTests;
using Xunit;

namespace Hambasafe.Services.Tests.Services
{
    public class EventServiceTest : IClassFixture<EventDatabaseFixture>
    {
        private readonly IEventService _eventService;

        public EventServiceTest()
        {
            var container = Bootstrapper.Container;
            _eventService = container.Resolve<IEventService>();
        }

        [Fact]
        public async void FindAll()
        {
            var c = await _eventService.FindAll();
            Assert.Equal(c.Count, 2);
        }
        [Fact]
        public async void FindById()
        {
            var c = await _eventService.FindById(2);
            Assert.Equal(c.Id, 2);
        }


    }
    public class EventDatabaseFixture : IDisposable
    {
        private readonly IRepository<Event> _repository;
        private readonly Event[] _events = { new Event
            {
                Id = 1
            },
            new Event
            {
                Id = 2
            }};
        public EventDatabaseFixture()
        {

            _repository = Bootstrapper.Container.Resolve<IRepository<Event>>();
            _repository.AddRange(_events);

        }

        public void Dispose()
        {
            _repository.DeleteRange(_events);
        }

    }
}
