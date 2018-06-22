using MVC_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Helper.Controllers
{
    public class AttributeEncodeController : Controller
    {
        // GET: AttributeEncode
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AttributeEncode()
        {

            Personel personel = new Personel();
            personel.Ad = "Şeref Çarık";
            return View(personel);
        }
    }
}