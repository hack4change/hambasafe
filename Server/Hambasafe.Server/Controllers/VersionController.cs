using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hambasafe.Server.Controllers
{
    public class VersionController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }
    }
}
