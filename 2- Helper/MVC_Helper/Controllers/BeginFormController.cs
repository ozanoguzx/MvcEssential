using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Helper.Controllers
{
    public class BeginFormController : Controller
    {
        // GET: BeginForm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BeginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BeginForm(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult PostAction()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostAction(int? id)
        {
            return View();
        }
    }
}