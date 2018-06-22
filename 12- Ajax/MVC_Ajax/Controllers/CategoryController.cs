using MVC_Ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace MVC_Ajax.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities _northwindService;
        public CategoryController()
        {
            _northwindService = new NorthwindEntities();
        }
        // GET: User
        public ActionResult Index()
        {
            List<Category> categories = _northwindService.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public JsonResult Create(Category category)
        {
            Thread.Sleep(3000);
            JsonResultModel jr = new JsonResultModel();
            if (category.CategoryName == null)
            {
                jr.IsSuccess = false;
                jr.UserMessage = "Kategori Adı Boş Geçilemez";
            }
            else
            {
                try
                {
                    _northwindService.Categories.Add(category);
                    _northwindService.SaveChanges();

                    jr.IsSuccess = true;
                    jr.UserMessage = "Kategori Başarıyla Eklendi";
                }
                catch (Exception)
                {
                    jr.IsSuccess = false;
                    jr.UserMessage = "Kayıt İşlemi Hatası";
                }
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        } 
        public PartialViewResult GetProducts(int? id)
        {
            System.Threading.Thread.Sleep(3000);
            Category category = _northwindService.Categories.Find(id);
            return PartialView("_ProductPartial", category);
        }
    }
}