using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Area.Areas.Category.Controllers
{
    public class HomeController : Controller
    {
        // GET: Category/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}