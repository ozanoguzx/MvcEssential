using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Area.Areas.Product.Controllers
{
    public class HomeController : Controller
    {
        // GET: Product/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}