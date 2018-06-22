using MVC_Grid.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Grid.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities _northwindService;
        public HomeController()
        {
            _northwindService = new NorthwindEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            List<Category> categories = _northwindService.Categories.ToList();
            return View(categories);
        }
    }
}