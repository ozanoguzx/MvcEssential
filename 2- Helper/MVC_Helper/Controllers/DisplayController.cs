using MVC_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Helper.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Display()
        {
            Category cat = db.Categories.Find(1);
            // ViewDataDictionary<Category> list = new ViewDataDictionary<Category>(cat);
            return View(cat);
        }
    }
}