using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hambasafe.Api.Models.v1;
using Hambasafe.Services.Services;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Hambasafe.Api.Controllers.v1
{
    [Route("v1/[controller]")]
    public class LocationController
    {
        private readonly IEventLocationService _eventLocationService;
        private readonly IMapper _mapper;

        public LocationController(IEventLocationService eventLocationService, IMapper mapper)
        {
            _eventLocationService = eventLocationService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("locations"), HttpGet]
        public async Task<List<EventLocationModel>> GetLocations()
        {
            var eventLocations = await _eventLocationService.FindAll();

            return _mapper.Map<List<EventLocationModel>>(eventLocations);
        }

        [AllowAnonymous]
        [Route("locations-by-suburb"), HttpGet]
        public async Task<List<EventLocationModel>> GetLocationsBySuburb([FromQuery]string suburb)
        {
            var eventLocations = await _eventLocationService.FindBySuburb(suburb);

            return _mapper.Map<List<EventLocationModel>>(eventLocations);
        }

        [AllowAnonymous]
        [Route("location"), HttpGet]
        public async Task<EventLocationModel> GetLocation([FromQuery]int id)
        {
            var eventLocation = await _eventLocationService.FindById(id);

            return _mapper.Map<EventLocationModel>(eventLocation);
        }
    }
}
