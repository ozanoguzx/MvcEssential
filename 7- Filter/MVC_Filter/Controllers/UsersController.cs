using MVC_Filter.ActionFilter;
using MVC_Filter.Models;
using System.Web.Mvc;

namespace MVC_Filter.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(bool? result)
        {
            if (result.HasValue)
            {
                if (result.Value == true)
                    ViewBag.Result = new string[] { "Numarası Doğrulanmıştır", "alert-success" };
                else
                    ViewBag.Result = new string[] { "Numarası Geçerli Değil", "alert-danger" };
            }
            return View();
        }


        [
            HttpPost,
            CheckUser
        ]
        public ActionResult Create(User user)
        {

            return View();
        }
    }
}