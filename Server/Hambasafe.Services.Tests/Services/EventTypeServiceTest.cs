using System;
using Autofac;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Services;
using Hambasafe.Logic.UnitTests;
using Xunit;

namespace Hambasafe.Services.Tests.Services
{
    public class EventTypeServiceTest : IClassFixture<EventTypeDatabaseFixture>
    {
        private readonly IEventTypeService _eventTypeService;

        public EventTypeServiceTest()
        {
            var container = Bootstrapper.Container;
            _eventTypeService = container.Resolve<IEventTypeService>();
        }

        [Fact]
        public async void FindAll()
        {
            var c = await _eventTypeService.FindAll();
            Assert.Equal(c.Count, 2);
        }

        [Fact]
        public async void FindById()
        {
            var c = await _eventTypeService.FindById(2);
            Assert.Equal(c.Id, 2);
        }
    }

    public class EventTypeDatabaseFixture : IDisposable
    {
        private readonly IRepository<EventType> _repository;

        private readonly EventType[] _eventTypes =
        {
            new EventType
            {
                Id = 1
            },
            new EventType
            {
                Id = 2
            }
        };

        public EventTypeDatabaseFixture()
        {
            _repository = Bootstrapper.Container.Resolve<IRepository<EventType>>();
            _repository.AddRange(_eventTypes);
        }

        public void Dispose()
        {
            _repository.DeleteRange(_eventTypes);
        }
    }
}
