using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Session.Models;

namespace MVC_Session.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities _northwindService;

        public CategoryController()
        {
            _northwindService = new NorthwindEntities();
        }
        public ActionResult Index()
        {
            List<Category> cateogyrList = _northwindService.Categories.ToList();
             
            return View(cateogyrList);
        }
    }
}