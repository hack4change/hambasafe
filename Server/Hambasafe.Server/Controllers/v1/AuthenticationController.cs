using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Models.v1;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1/authentication")]
    public class AuthenticationController : ApiControllerBase
    {
        public AuthenticationController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        [AllowAnonymous]
        [Route("register"), HttpGet]
        public async Task<HttpResponseMessage> Register()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
