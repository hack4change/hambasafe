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

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class EventTypeController : ApiControllerBase
    {
        public EventTypeController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        [AllowAnonymous]
        [Route("eventTypes"), HttpGet]
        public async Task<HttpResponseMessage> GetEventTypes()
        {
            try
            {
                var dummyEventTypes = new[]
                {
                    new { EventTypeId = 101, Name = "Recreational Walk", Description = "A recreational walk" },
                    new { EventTypeId = 102, Name = "Road Ride", Description = "A recreational road ride" }
                };

                return Request.CreateResponse(HttpStatusCode.OK, dummyEventTypes);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
