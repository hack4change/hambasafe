﻿using System;
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

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class EventTypeController : ApiControllerBase
    {
        public EventTypeController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("event-types"), HttpGet]
        public async Task<HttpResponseMessage> GetEventTypes()
        {
            HambasafeDataContext context = new HambasafeDataContext();
            try
            {
                var eventTypes =  context.EventTypes.ToList().Select(et => new EventTypeModel(et));

                return Request.CreateResponse(HttpStatusCode.OK, eventTypes);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
