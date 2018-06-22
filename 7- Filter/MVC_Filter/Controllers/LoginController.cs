using MVC_Filter.Models; 
using System.Web.Mvc;

namespace MVC_Filter.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User user)
        {
            if (user.UserName != "" && user.Password != "")
            {
                HttpContext.Session.Add("login", user);
                return RedirectToAction("About", "Home");
            }
            return RedirectToAction("Index");
        }
    }
}