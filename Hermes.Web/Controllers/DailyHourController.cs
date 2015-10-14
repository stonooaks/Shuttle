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
    public class DailyHourController : Controller
    {
        private HermesContext db = new HermesContext();

        // GET: /DailyHour/
        public ActionResult Index()
        {
            var dailyhours = db.DailyHours.Include(d => d.Vehicle);
            return View(dailyhours.ToList());
        }

        // GET: /DailyHour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyHour dailyhour = db.DailyHours.Find(id);
            if (dailyhour == null)
            {
                return HttpNotFound();
            }
            return View(dailyhour);
        }

        // GET: /DailyHour/Create
        public ActionResult Create()
        {
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name");
            return View();
        }

        // POST: /DailyHour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Day,Miles,VehicleId")] DailyHour dailyhour)
        {
            if (ModelState.IsValid)
            {
                db.DailyHours.Add(dailyhour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name", dailyhour.VehicleId);
            return View(dailyhour);
        }

        // GET: /DailyHour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyHour dailyhour = db.DailyHours.Find(id);
            if (dailyhour == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name", dailyhour.VehicleId);
            return View(dailyhour);
        }

        // POST: /DailyHour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Day,Miles,VehicleId")] DailyHour dailyhour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyhour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name", dailyhour.VehicleId);
            return View(dailyhour);
        }

        // GET: /DailyHour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyHour dailyhour = db.DailyHours.Find(id);
            if (dailyhour == null)
            {
                return HttpNotFound();
            }
            return View(dailyhour);
        }

        // POST: /DailyHour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DailyHour dailyhour = db.DailyHours.Find(id);
            db.DailyHours.Remove(dailyhour);
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
