using MVC_JsonResult.Models.Context;
using MVC_JsonResult.Models.Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC_JsonResult.Controllers
{
    public class TownsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Towns
        public ActionResult Index()
        {
            var towns = db.Towns.Include(t => t.District);
            return View(towns.ToList());
        }

        // GET: Towns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Town town = db.Towns.Find(id);
            if (town == null)
            {
                return HttpNotFound();
            }
            return View(town);
        }

        // GET: Towns/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName");
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TownId,TownName,DistrictId")] Town town)
        {
            if (ModelState.IsValid)
            {
                db.Towns.Add(town);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", town.DistrictId);
            return View(town);
        }

        // GET: Towns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Town town = db.Towns.Find(id);
            if (town == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", town.DistrictId);
            return View(town);
        }

        // POST: Towns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TownId,TownName,DistrictId")] Town town)
        {
            if (ModelState.IsValid)
            {
                db.Entry(town).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", town.DistrictId);
            return View(town);
        }

        // GET: Towns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Town town = db.Towns.Find(id);
            if (town == null)
            {
                return HttpNotFound();
            }
            return View(town);
        }

        // POST: Towns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Town town = db.Towns.Find(id);
            db.Towns.Remove(town);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
