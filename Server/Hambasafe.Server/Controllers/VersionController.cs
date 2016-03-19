using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        [HttpGet]
        public string Index()
        {
            string version = "";
            try
            {
                version = GetType().Assembly.GetName().Version.ToString();
            }
            catch (Exception error)
            {
                HandleError(error);
            }

            return version;
        }


    }
}
