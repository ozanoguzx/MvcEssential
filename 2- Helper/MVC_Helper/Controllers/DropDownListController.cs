using MVC_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Helper.Controllers
{
    public class DropDownListController : Controller
    {
        // GET: DropDownList
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DropDownList(Sehirler item)
        {
            List<Sehirler> sehirler = new List<Sehirler>()
            {
                new Sehirler{ID=1,SehirAdi="Ankara"},
                new Sehirler{ID=2,SehirAdi="İstanbul"},
                new Sehirler{ID=3,SehirAdi="Eskişehir"},
                new Sehirler{ID=4,SehirAdi="İzmir"}
            };

            ViewBag.SehirID = new SelectList(sehirler.ToList(), "ID", "SehirAdi");
            return View();
        }

        public ActionResult DropDownListFor()
        {
            List<Sehirler> sehirler = new List<Sehirler>()
            {
                new Sehirler{ID=1,SehirAdi="Ankara"},
                new Sehirler{ID=2,SehirAdi="İstanbul"},
                new Sehirler{ID=3,SehirAdi="Eskişehir"},
                new Sehirler{ID=4,SehirAdi="İzmir"}
            };

            Sehirler sehir = new Sehirler();
            sehir.ID = 1;
            sehir.SehirAdi = "Ankara";

            return View(sehir);
        }
    }
}