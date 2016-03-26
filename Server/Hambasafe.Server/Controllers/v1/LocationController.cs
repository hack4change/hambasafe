using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using Hambasafe.DataAccess.Entities;
using Hambasafe.Server.Models.v1;
using AutoMapper;
using System.Collections.Generic;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class LocationController : ApiControllerBase
    {
        IMapper Mapper;
        public LocationController(IConfigurationService configuration, ITableStorageService tableStorage, IMapper mapper) :
            base(configuration, tableStorage)
        {
            Mapper = mapper;
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("locations"), HttpGet]
        public async Task<HttpResponseMessage> GetAllLocations()
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                var locations = Mapper.Map<List<EventLocation>, List<EventLocationModel>>(dataContext.EventLocations.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, locations);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("locations-by-suburb"), HttpGet]
        public async Task<HttpResponseMessage> GetLocationsBySuburb(string suburb)
        {
            try
            {
                var dataContext = new HambasafeDataContext();

                var locations = Mapper.Map<List<EventLocation>, List<EventLocationModel>>(dataContext.EventLocations
                                          .Where(el => el.Suburb.ToLower() == suburb.ToLower())
                                          .ToList());

                return Request.CreateResponse(HttpStatusCode.OK, locations);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("location"), HttpGet]
        public async Task<HttpResponseMessage> GetLocation(int id)
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                return Request.CreateResponse(HttpStatusCode.OK, dataContext.EventLocations.ToList()
                                                                                           .Where(l => l.Id == id));
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
