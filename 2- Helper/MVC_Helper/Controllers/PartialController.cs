using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Helper.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial()
        {
            return View();
        }
        public PartialViewResult _Partial()
        {
            return PartialView();
        }
        public PartialViewResult _PartialDictionary()
        {
            return PartialView();
        }
    }
}