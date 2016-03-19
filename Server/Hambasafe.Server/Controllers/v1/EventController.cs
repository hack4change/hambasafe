<<<<<<< HEAD
﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class EventsController : ApiControllerBase
    {
        public EventsController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        [AllowAnonymous]
        [Route("events"), HttpGet]
        public async Task<HttpResponseMessage> GetEvents()
        {
            try
            {
                var dummyEvents = new[]
                {
                    new { Id = 1, Name = "Event 1", Type="Trail Run" },
                    new { Id = 2, Name = "Event 2", Type="MTB" }
                };

                return Request.CreateResponse(HttpStatusCode.OK, dummyEvents);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("event"), HttpGet]
        public async Task<HttpResponseMessage> GetEvent(int id)
        {
            try
            {
                var dummyEvent = new{ Id = 1, Name = "Event 1", Type="Trail Run" };

                return Request.CreateResponse(HttpStatusCode.OK, dummyEvent);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
=======
﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class EventsController : ApiControllerBase
    {
        public EventsController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        [AllowAnonymous]
        [Route("events"), HttpGet]
        public async Task<HttpResponseMessage> GetEvents()
        {
            try
            {
                var dummyEvents = new[]
                {
                    new { Id = 1, Name = "Event 1", Type="Trail Run" },
                    new { Id = 2, Name = "Event 2", Type="MTB" }
                };

                return Request.CreateResponse(HttpStatusCode.OK, dummyEvents);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("event"), HttpGet]
        public async Task<HttpResponseMessage> GetEvent(int id)
        {
            try
            {
                var dummyEvent = new{ Id = 1, Name = "Event 1", Type="Trail Run" };

                return Request.CreateResponse(HttpStatusCode.OK, dummyEvent);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
>>>>>>> refs/remotes/origin/master
