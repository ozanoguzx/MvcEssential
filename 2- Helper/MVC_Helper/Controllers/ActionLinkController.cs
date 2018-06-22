using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Helper.Controllers
{
    public class ActionLinkController : Controller
    {
        // GET: ActionLink
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ActionLink()
        {
            return View();
        }
    }
}