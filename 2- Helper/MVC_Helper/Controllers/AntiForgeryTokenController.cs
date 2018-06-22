using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Helper.Controllers
{
    public class AntiForgeryTokenController : Controller
    {
        // GET: AntiForgeryToken
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AntiForgeryToken()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AntiForgeryToken(string name)
        {
            return View();
        }
    }
}