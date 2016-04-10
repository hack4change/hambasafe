using System;
using System.Linq;
using Autofac;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Services;
using Hambasafe.Logic.UnitTests;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Hambasafe.Services.Tests.Services
{
    public class UserServiceTest : IClassFixture<DatabaseFixture>
    {
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            var container = Bootstrapper.Container;
            _userService = container.Resolve<IUserService>();
        }

        [Fact]
        public async void FindAll()
        {
            var c = await _userService.FindAll();
            Assert.Equal(c.Count, 2);
        }
        [Fact]
        public async void FindById()
        {
            var c = await _userService.FindById(2);
            Assert.Equal(c.Id, 2);
        }
        [Fact]
        public async void FindAllByUsernameFindFullFirstName()
        {
            var c = await _userService.FindAllByUsername("Test2");
            Assert.Equal(c.First().FirstNames, "Test2");
        }
        [Fact]
        public async void FindAllByUsernameFindPartialFirstName()
        {
            var c = await _userService.FindAllByUsername("Test");
            Assert.Equal(c.Count, 2);
        }
        [Fact]
        public async void FindAllByUsernameFullSurname()
        {
            var c = await _userService.FindAllByUsername("Sur2");
            Assert.Equal(c.First().LastName, "Sur2");
        }
        [Fact]
        public async void FindAllByUsernameFindPartialSurname()
        {
            var c = await _userService.FindAllByUsername("Sur");
            Assert.Equal(c.Count, 2);
        }

    }
    public class DatabaseFixture : IDisposable
    {
        private IRepository<User> _repository;
        private User[] _users = { new User
            {
                Id = 1,
                FirstNames = "Test",
                LastName = "Sur"
            },
            new User
            {
                Id = 2,
                FirstNames = "Test2",
                LastName = "Sur2"
            }};
        public DatabaseFixture()
        {

            _repository = Bootstrapper.Container.Resolve<IRepository<User>>();
            _repository.AddRange(_users);

        }

        public void Dispose()
        {
            _repository.DeleteRange(_users);
        }

    }
}
