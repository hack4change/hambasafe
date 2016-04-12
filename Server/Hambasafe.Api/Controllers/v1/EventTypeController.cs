﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hambasafe.Api.Models.v1;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Services;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Hambasafe.Api.Controllers.v1
{
    [Route("v1/[controller]")]
    public class EventTypeController
    {
        private readonly IEventTypeService _eventTypeService;
        private readonly IMapper _mapper;
        public EventTypeController(IEventTypeService eventTypeService, IMapper mapper)
        {
            _eventTypeService = eventTypeService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("event-types"), HttpGet]
        public async Task<List<EventTypeModel>> GetEventTypes()
        {
            var eventTypes = await _eventTypeService.FindAll();

            return _mapper.Map<List<EventTypeModel>>(eventTypes);
        }
    }
}
