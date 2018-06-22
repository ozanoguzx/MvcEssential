using MVC_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Helper.Controllers
{
    public class TextBoxController : Controller
    {
        // GET: TextBox
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TextBox()
        {
            Personel p = new Personel();
            p.ID = 1;
            p.Ad = "Murat";
            p.Soyad = "Vuranok";
            p.Departman = "Yazılım";
            p.DogumTarihi = new DateTime(1982, 09, 29);
            return View(p);
        }

        public ActionResult TextBoxFor()
        {
            Personel p = new Personel();
            p.ID = 1;
            p.Ad = "Murat";
            p.Soyad = "Vuranok";
            p.Departman = "Yazılım";
            p.DogumTarihi = new DateTime(1982, 09, 29);
            return View(p);
        }
    }
}