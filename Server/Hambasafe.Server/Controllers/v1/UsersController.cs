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
    public class UsersController : ApiControllerBase
    {
        public UsersController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        [AllowAnonymous]
        [Route("users"), HttpGet]
        public async Task<HttpResponseMessage> GetUsers()
        {
            try
            {
                var dummyUsers = new[]
                {
                    new { Id = 1, Name = "Foo" },
                    new { Id = 2, Name = "Bar" }
                };

                return Request.CreateResponse(HttpStatusCode.OK, dummyUsers);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
