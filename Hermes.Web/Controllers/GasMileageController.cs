using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hermes.Data.Models;

namespace Hermes.Web.Controllers
{
    public class GasMileageController : Controller
    {
        private HermesContext db = new HermesContext();

        // GET: /GasMileage/
        public ActionResult Index()
        {
            var gasmileages = db.GasMileages.Include(g => g.Vehicle);
            return View(gasmileages.ToList());
        }

        // GET: /GasMileage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasMileage gasmileage = db.GasMileages.Find(id);
            if (gasmileage == null)
            {
                return HttpNotFound();
            }
            return View(gasmileage);
        }

        // GET: /GasMileage/Create
        public ActionResult Create()
        {
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name");
            return View();
        }

        // POST: /GasMileage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Date,Mileage,Gallons,VehicleId")] GasMileage gasmileage)
        {
            if (ModelState.IsValid)
            {
                db.GasMileages.Add(gasmileage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name", gasmileage.VehicleId);
            return View(gasmileage);
        }

        // GET: /GasMileage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasMileage gasmileage = db.GasMileages.Find(id);
            if (gasmileage == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name", gasmileage.VehicleId);
            return View(gasmileage);
        }

        // POST: /GasMileage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Date,Mileage,Gallons,VehicleId")] GasMileage gasmileage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasmileage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name", gasmileage.VehicleId);
            return View(gasmileage);
        }

        // GET: /GasMileage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasMileage gasmileage = db.GasMileages.Find(id);
            if (gasmileage == null)
            {
                return HttpNotFound();
            }
            return View(gasmileage);
        }

        // POST: /GasMileage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GasMileage gasmileage = db.GasMileages.Find(id);
            db.GasMileages.Remove(gasmileage);
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
