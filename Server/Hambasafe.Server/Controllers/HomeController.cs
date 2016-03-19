using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hambasafe.Server.Controllers
{
    /// <summary>
    /// This Controller is purely here for an easy reference to existing api endpoints.
    /// http://localhost/help
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
