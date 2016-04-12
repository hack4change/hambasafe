using System.Collections.Generic;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Microsoft.Data.Entity;

namespace Hambasafe.Services.Services
{
    public interface IUserService
    {
        Task<List<User>> FindAll();
        Task<User> FindById(int id);
        Task<List<User>> FindAllByUsername(string username);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<List<User>> FindAll()
        {
            return _repository.FindAll()
                              .ToListAsync();
        }

        public Task<List<User>> FindAllByUsername(string username)
        {
            //case matching is done by the db.
            return _repository.FindAll(a => a.FirstNames.Contains(username) || a.LastName.Contains(username))
                              .ToListAsync();
        }

        public Task<User> FindById(int id)
        {
            return _repository.First(u => u.Id == id);
        }
    }
}
