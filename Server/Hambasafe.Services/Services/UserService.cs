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

    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }

        public Task<List<User>> FindAll()
        {
            return Repository.FindAll()
                             .ToListAsync();
        }

        public Task<List<User>> FindAllByUsername(string username)
        {
            //case matching is done by the db.
            return Repository.FindAll(a => a.FirstNames.Contains(username) || a.LastName.Contains(username))
                             .ToListAsync();
        }

        public Task<User> FindById(int id)
        {
            return Repository.First(u => u.Id == id);
        }
    }
}
