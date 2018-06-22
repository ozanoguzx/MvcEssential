using MVC_Cookie.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Cookie.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Request.Cookies["login"] != null)
            {
                HttpCookie user = Request.Cookies["login"];
                UserVM vm = new UserVM();
                vm.UserName = user["userName"];
                vm.Password = user["password"];
                return View(vm);
            }

            // Cookie silinsede input'lar dolu gelmekte, geçici çözüm
            // else
            // {
            //    UserVM vm = new UserVM();
            //    vm.UserName = " ";
            //    vm.Password = ""; 
            //    return View(vm);
            // }
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserVM vm)
        {
            if (vm.Remember)
            {
                HttpCookie cerez = new HttpCookie("login");
                cerez.Values.Add("userName", vm.UserName);
                cerez.Values.Add("password", vm.Password);

                // Expires : Cookie istemci bilgisayar üzerinde ne kadar süre tutulacağını belirtir. Genellikle DateTime nesnesinin Add metotları kullanılır.
                cerez.Expires = DateTime.Now.AddDays(15);

                // Domain verilmesi durumunda oluşturulan cookie sadce bu domain altında çalışacaktır.
                // cerez.Domain = "kurumsal.bilgeadam.com";

                // Path oluşuturulması durumunda, oluşturulan Cookie bu klasör içerisinde yer alacaktır.
                // cerez.Path = "/Student"; 

                Response.Cookies.Add(cerez);
                return RedirectToAction("Index");
            }
           
                // Login Code Here
                return RedirectToAction("Index");
            
        }
        public ActionResult ClearCookie()
        {
            if (Request.Cookies.AllKeys.Contains("login"))
            {
                HttpCookie cookie = Request.Cookies["login"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index");
        }

        public ActionResult LoginJQuery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginJQuery(UserVM vm)
        {
            return View();
        }
    }
}