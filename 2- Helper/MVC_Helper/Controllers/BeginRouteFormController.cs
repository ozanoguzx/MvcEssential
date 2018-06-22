using MVC_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Helper.Controllers
{
    public class BeginRouteFormController : Controller
    {
        // GET: BeginRouteForm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BeginRouteForm()
        {
            RouteUrl link = new RouteUrl();
            link.RouteName = "DefaultDeneme";
            return View(link);
        }
    }
}