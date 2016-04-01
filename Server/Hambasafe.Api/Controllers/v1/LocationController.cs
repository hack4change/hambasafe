using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Hambasafe.Api.Models.v1;
using Hambasafe.DataLayer.Entities;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Hambasafe.Api.Controllers.v1
{
    [Route("v1")]
    public class LocationController 
    {
        IMapper Mapper;
        public LocationController( IMapper mapper) 
        {
            Mapper = mapper;
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("locations"), HttpGet]
        public async Task<List<EventLocationModel>> GetAllLocations()
        {
            
                var dataContext = new HambasafeDataContext();
                var locations = Mapper.Map<List<EventLocation>, List<EventLocationModel>>(dataContext.EventLocations.ToList());
                return  locations;
            
         
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("locations-by-suburb"), HttpGet]
        public async Task<List<EventLocationModel>> GetLocationsBySuburb(string suburb)
        {
           
                var dataContext = new HambasafeDataContext();

                var locations = Mapper.Map<List<EventLocation>, List<EventLocationModel>>(dataContext.EventLocations
                                          .Where(el => el.Suburb.ToLower() == suburb.ToLower())
                                          .ToList());
                return  locations;
           
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("location"), HttpGet]
        public async Task<EventLocation> GetLocation(int id)
        {
                var dataContext = new HambasafeDataContext();
                return  dataContext.EventLocations.First(l => l.Id == id);
        }
    }
}
