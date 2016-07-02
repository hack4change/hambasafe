using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Microsoft.Data.Entity;

namespace Hambasafe.Services.Services
{
    public interface IEventLocationService
    {
        Task<List<EventLocation>> FindAll();
        Task<List<EventLocation>> FindBySuburb(string suburb);
        Task<List<EventLocation>> FindByCity(string city);
        Task<EventLocation> FindById(int id);
    }

    public class EventLocationService : IEventLocationService
    {
        private readonly IRepository<EventLocation> _repository;

        public EventLocationService(IRepository<EventLocation> repository)
        {
            _repository = repository;
        }

        public async Task<List<EventLocation>> FindAll()
        {
            return await _repository.FindAll().ToListAsync();
        }

        public async Task<List<EventLocation>> FindBySuburb(string suburb)
        {
            return await _repository.FindAll(el => el.Suburb.StartsWith(suburb, StringComparison.OrdinalIgnoreCase))
                                    .ToListAsync();
        }

        public async Task<List<EventLocation>> FindByCity(string city)
        {
            return await _repository.FindAll(el => el.City.StartsWith(city, StringComparison.OrdinalIgnoreCase))
                                    .ToListAsync();
        }

        public async Task<EventLocation> FindById(int id)
        {
            return await _repository.First(el => el.Id == id);
        }
    }
}
