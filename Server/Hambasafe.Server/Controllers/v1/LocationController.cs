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
    public class LocationController : ApiControllerBase
    {
        public LocationController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        [AllowAnonymous]
        [Route("provinces"), HttpGet]
        public async Task<HttpResponseMessage> GetAllProvinces()
        {
            try
            {
                var dummyProvinces = new[]
                {
                    new { EventTypeId = 101, Name = "Recreational Walk", Description = "A recreational walk" },
                    new { EventTypeId = 102, Name = "Road Ride", Description = "A recreational road ride" }
                };

                return Request.CreateResponse(HttpStatusCode.OK, dummyProvinces);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }     

        [AllowAnonymous]
        [Route("suburbs"), HttpGet]
        public async Task<HttpResponseMessage> GetAllSuburbs()
        {
            try
            {
                var dummySuburbs = new[]
                {
                    new { Name = "Tokai", Coord = "40.748440, -73.984559", Province = "Western Cape" },
                    new { Name = "Greenpoint", Coord = "40.454440, -73.981249", Province = "Western Cape" }
                };

                return Request.CreateResponse(HttpStatusCode.OK, dummySuburbs);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("suburbsbyprovince"), HttpGet]
        public async Task<HttpResponseMessage> GetSuburbsInProvince(string province)
        {
            try
            {                               
                var dummySuburbs = new[]
                {
                    new { Name = "Tokai", Coord = "40.748440, -73.984559", Province = province },
                    new { Name = "Greenpoint", Coord = "40.454440, -73.981249", Province = province }
                };

                return Request.CreateResponse(HttpStatusCode.OK, dummySuburbs);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
