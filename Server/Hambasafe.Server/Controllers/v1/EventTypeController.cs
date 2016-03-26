using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using Hambasafe.DataAccess.Entities;
using Hambasafe.Server.Models.v1;
using AutoMapper;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class EventTypeController : ApiControllerBase
    {
        IMapper Mapper;
        public EventTypeController(IConfigurationService configuration, ITableStorageService tableStorage, IMapper mapper) :
            base(configuration, tableStorage)
        {
            Mapper = mapper;
        }


        [AllowAnonymous]
        [Route("event-types"), HttpGet]
        public async Task<HttpResponseMessage> GetEventTypes()
        {
            HambasafeDataContext context = new HambasafeDataContext();
            try
            {
                var eventTypes = Mapper.Map<List<EventType>, List<EventTypeModel>>(context.EventTypes.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, eventTypes);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
