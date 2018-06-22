using System.Linq;
using System.Web.Mvc;

namespace MVC_Crud.Controllers
{
    using Models;
    using System.Data.Entity;
    using System.Net;

    public class ShippersController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        #region Index
        public ActionResult Index()
        {
            return View(db.Shippers.ToList());
        }
        #endregion

        #region Create
        public ActionResult Create() { return View(); }

        [HttpPost]
        public ActionResult Create(Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shipper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        #endregion

        #region Delete
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }
        [HttpPost]
        public ActionResult Edit(Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipper);
        } 
        #endregion
    }
}
