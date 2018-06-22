using MVC_Ajax.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace MVC_Ajax.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities _northwindService;
        public ProductController()
        {
            _northwindService = new NorthwindEntities();
        }
        // GET: Porduct
        public ActionResult Index()
        {
            List<Product> products = _northwindService.Products.Take(5).ToList();
            return View(products);
        }

        public PartialViewResult ProductDetail(int? id)
        {
            Product product = _northwindService.Products.Find(id);
            Thread.Sleep(5000);
            return PartialView("_ProductDetailsPartial", product);
        }
    }
}