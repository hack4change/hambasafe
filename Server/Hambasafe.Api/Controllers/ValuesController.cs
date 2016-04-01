using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hambasafe.Api.Models.v1;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace Hambasafe.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController
    {
        private readonly EventService _eventRepository;
        private readonly IMapper _mapper;

        public ValuesController(EventService eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<EventModel>> Get()
        {
          
            var events = await _eventRepository.FindAll();
            return _mapper.Map<List<Event>, List<EventModel>>(events);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
