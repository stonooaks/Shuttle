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
    public class TripTypeController : Controller
    {
        private HermesContext db = new HermesContext();

        // GET: /TripType/
        public ActionResult Index()
        {
            var triptypes = db.TripTypes;
            return View(triptypes.ToList());
        }

        // GET: /TripType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripType triptype = db.TripTypes.Find(id);
            if (triptype == null)
            {
                return HttpNotFound();
            }
            return View(triptype);
        }

        // GET: /TripType/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: /TripType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Description,VehicleId")] TripType triptype)
        {
            if (ModelState.IsValid)
            {
                db.TripTypes.Add(triptype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(triptype);
        }

        // GET: /TripType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripType triptype = db.TripTypes.Find(id);
            if (triptype == null)
            {
                return HttpNotFound();
            }
            return View(triptype);
        }

        // POST: /TripType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description")] TripType triptype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(triptype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name");
            return View(triptype);
        }

        // GET: /TripType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripType triptype = db.TripTypes.Find(id);
            if (triptype == null)
            {
                return HttpNotFound();
            }
            return View(triptype);
        }

        // POST: /TripType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TripType triptype = db.TripTypes.Find(id);
            db.TripTypes.Remove(triptype);
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
