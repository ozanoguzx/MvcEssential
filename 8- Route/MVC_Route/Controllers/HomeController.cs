using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Route.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }


        // Url de Controller/Action yazdığınızda burdaki Action Result çalışacaktır.
        [Route("Controller/Action")]
        public ActionResult Category()
        {
            return View();
        }
    }
}