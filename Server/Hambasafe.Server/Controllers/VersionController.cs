using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;

//using Hambasafe.Server.Services.Configuration;
//using Hambasafe.Server.Services.TableStorage;

namespace Hambasafe.Server.Controllers
{
    public class VersionController : ApiControllerBase
    {

        public VersionController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        /// <summary>
        /// Use this api point to determine the latest version url for endpoints
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("versionurl"), HttpGet]
        public async Task<HttpResponseMessage> GetVersionUrl()
        {
            try
            {
                var version = $"v{GetType().Assembly.GetName().Version.Major}";

                return Request.CreateResponse(HttpStatusCode.OK, version);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
