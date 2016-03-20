using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using Hambasafe.DataAccess.Entities;
using models = Hambasafe.Server.Models.v1;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class LocationController : ApiControllerBase
    {
        public LocationController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
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
                return Request.CreateResponse(HttpStatusCode.OK, dataContext.EventLocations.ToList().Select(l=>new models.EventLocation(l)));
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
        public async Task<HttpResponseMessage> GetLocationsBySuburb(int suburbId)
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                return Request.CreateResponse(HttpStatusCode.OK, dataContext.EventLocations.ToList()
                                                                            .Where(l=>l.SuburbId==suburbId));
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
                                                                                           .Where(l => l.EventLocationId == id));
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
