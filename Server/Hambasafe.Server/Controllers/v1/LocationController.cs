using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using Hambasafe.DataAccess.Entities;

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
        [Route("locations"), HttpGet]
        public async Task<HttpResponseMessage> GetAllLocations()
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                return Request.CreateResponse(HttpStatusCode.OK, dataContext.EventLocations.ToArray());
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }     

        [AllowAnonymous]
        [Route("locationsbysuburb"), HttpGet]
        public async Task<HttpResponseMessage> GetLocationsBySuburb(int suburbId)
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                return Request.CreateResponse(HttpStatusCode.OK, dataContext.EventLocations.Where(l=>l.SuburbId==suburbId).ToArray());
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("location"), HttpGet]
        public async Task<HttpResponseMessage> GetLocation(int id)
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                return Request.CreateResponse(HttpStatusCode.OK, dataContext.EventLocations.Where(l => l.EventLocationId == id).ToArray());
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
