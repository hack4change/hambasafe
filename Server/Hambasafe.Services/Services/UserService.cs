using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Hambasafe.Services.Services
{
    public interface IUserService
    {
        Task<List<User>> FindAll();
        Task<User> FindById(int id);
        Task<User> FindByUserName(string username);
        Task<List<User>> FindAllByName(string name);
        Task<int> Add(User user);
        Task<int> Update(User user);
        Task<int> SaveIdentification(UserIdentification userIdentification);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> FindAll()
        {
            return await _repository.FindAll()
                                    .ToListAsync();
        }

        public async Task<List<User>> FindAllByName(string name)
        {
            //case matching is done by the db.
            return await _repository.FindAll(u => u.FirstNames.Contains(name) || u.LastName.Contains(name))
                                    .ToListAsync();
        }

        public async Task<User> FindById(int id)
        {
            return await _repository.First(u => u.Id == id);
        }

        public async Task<User> FindByUserName(string username)
        {
            // Username in this case is email address
            return await _repository.First(u => u.EmailAddress.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<int> Add(User user)
        {
            try
            {
                // Validate that this user does not exist
                var userExists = await _repository.FindAll(u => u.Id == user.Id || u.EmailAddress.Equals(user.EmailAddress, StringComparison.OrdinalIgnoreCase))
                                                  .AnyAsync();

                if (userExists)
                {
                    return await Update(user);
                }

                user.DateCreated = DateTime.UtcNow;
                user.DateUpdated = DateTime.UtcNow;

                var result = await _repository.Add(user);

                if (result != 1)
                {
                    throw new DataException($"Expected to add 1 user, but instead added {result}");
                }

                return user.Id;
            }
            catch (DbUpdateException ex)
            {
                throw new DataException("Error occured while adding a User", ex.InnerException);
            }
        }

        public async Task<int> Update(User user)
        {
            try
            {
                var existingUser = await GetExistingUser(user);

                existingUser.MapUser(user);

                var result = await _repository.Update(existingUser);

                if (result != 1)
                {
                    throw new DataException($"Expected to update 1 user, but instead updated {result}");
                }

                return user.Id;
            }
            catch (DbUpdateException ex)
            {
                throw new DataException("Error occured while updating a User", ex.InnerException);
            }
        }

        public async Task<int> SaveIdentification(UserIdentification userIdentification)
        {
            try
            {
                var documentUrl = $"[DOCUMENTURL]/{userIdentification.Identifier}.{userIdentification.FileExtension.Replace(".", "")}";
                File.WriteAllBytes(documentUrl, userIdentification.ByteData);

                var user = await GetExistingUser(new User { Id = userIdentification.UserId });

                user.IdentityDocumentUrl = documentUrl;

                var result = await _repository.Update(user);

                if (result != 1)
                {
                    throw new DataException($"Expected to update 1 user, but instead updated {result}");
                }

                return user.Id;
            }
            catch (DbUpdateException ex)
            {
                throw new DataException("Error occured while saving identification", ex.InnerException);
            }
        }

        private async Task<User> GetExistingUser(User user)
        {
            var userFromId = await _repository.First(u => u.Id == user.Id);
            var userFromEmail = await _repository.First(u => u.EmailAddress.Equals(user.EmailAddress, StringComparison.OrdinalIgnoreCase));

            if (userFromId == null && userFromEmail == null)
            {
                throw new DataException($"Could not find user for {user.EmailAddress}");
            }

            // Validate if the userFromId exists, then the userFromEmail must have the same email address (cannot change to another's email)
            if (userFromId != null && userFromEmail != null &&
                !userFromId.EmailAddress.Equals(userFromEmail.EmailAddress, StringComparison.OrdinalIgnoreCase))
            {
                throw new DataException($"Email Address {user.EmailAddress} is already in use");
            }

            var existingUser = userFromId ?? userFromEmail;
            return existingUser;
        }
    }
}
