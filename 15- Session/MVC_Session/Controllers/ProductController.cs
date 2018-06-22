using MVC_Session.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Session.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities _northwindService;
        public ProductController()
        {
            _northwindService = new NorthwindEntities();
        }
        public ActionResult Index(int? id, int page = 1)
        {
            if (id == 0 || id == null)
            {
                return RedirectToAction("Index", "Category");
            }
            List<Product> productList = _northwindService.Products.Where(x => x.CategoryID == id).ToList();
            return View(productList.ToPagedList(page, 5));
        }
    }
}