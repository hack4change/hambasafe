using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hambasafe.Api.Models.v1;
using Hambasafe.DataLayer.Entities;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Hambasafe.Api.Controllers.v1
{
    [Route("v1/[controller]")]
    public class EventTypeController
    {
        IMapper Mapper;
        public EventTypeController(IMapper mapper)
        {
            Mapper = mapper;
        }


        [AllowAnonymous]
        [Route("event-types"), HttpGet]
        public async Task<List<EventTypeModel>> GetEventTypes()
        {
            HambasafeDataContext context = new HambasafeDataContext();
            var eventTypes = Mapper.Map<List<EventType>, List<EventTypeModel>>(context.EventTypes.ToList());
            return eventTypes;


        }
    }
}
