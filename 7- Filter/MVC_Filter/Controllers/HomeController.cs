using MVC_Filter.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace MVC_Filter.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }
        [MustBeLoggedIn("Admin")]
        public ActionResult About()
        {
            return View();
        }


    }
}