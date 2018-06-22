using MVC_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Helper.Controllers
{

    public class ActionController : Controller
    {
        //
        // GET: /Action/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Action()
        {
            return View();
        }

        public PartialViewResult _PartialAction()
        {
            return PartialView();
        }
        public PartialViewResult _PartialActionRouteValue(int id)
        {
            List<Sehirler> sehirler = new List<Sehirler>()
            {
                new Sehirler{ID=1,SehirAdi="Ankara"},
                new Sehirler{ID=2,SehirAdi="İstanbul"},
                new Sehirler{ID=3,SehirAdi="Eskişehir"},
                new Sehirler{ID=4,SehirAdi="İzmir"}
            };

            return PartialView(sehirler.Where(x => x.ID == id).FirstOrDefault());
        }
    }
}
