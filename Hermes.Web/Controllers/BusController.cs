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
    public class BusController : Controller
    {
        private HermesContext db = new HermesContext();

        // GET: /Bus/
        public ActionResult Index()
        {
            var buses = db.Buses.Include(b => b.BusTime).Include(b => b.Driver).Include(b => b.Guest).Include(b => b.Intersection).Include(b => b.Kiawah).Include(b => b.RouteStop).Include(b => b.TripType);
            return View(buses.ToList());
        }

        // GET: /Bus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // GET: /Bus/Create
        public ActionResult Create()
        {
            ViewBag.BusTimeId = new SelectList(db.BusTimes, "Id", "StopLocation");
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name");
            ViewBag.GuestId = new SelectList(db.Guests, "Id", "Name");
            ViewBag.StopsId = new SelectList(db.Intersections, "Id", "Name");
            ViewBag.Kiawah_Id = new SelectList(db.Kiawahs, "Id", "Name");
            ViewBag.StopsId = new SelectList(db.RouteStops, "Id", "Id");
            ViewBag.TripTypeId = new SelectList(db.TripTypes, "Id", "Name");
            return View();
        }

        // POST: /Bus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StopsId,TripTypeId,Kiawah_Id,DriverId,BusTimeId,Date,GuestId")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Buses.Add(bus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusTimeId = new SelectList(db.BusTimes, "Id", "StopLocation", bus.BusTimeId);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", bus.DriverId);
            ViewBag.GuestId = new SelectList(db.Guests, "Id", "Name", bus.GuestId);
            ViewBag.StopsId = new SelectList(db.Intersections, "Id", "Name", bus.StopsId);
            ViewBag.Kiawah_Id = new SelectList(db.Kiawahs, "Id", "Name", bus.Kiawah_Id);
            ViewBag.StopsId = new SelectList(db.RouteStops, "Id", "Id", bus.StopsId);
            ViewBag.TripTypeId = new SelectList(db.TripTypes, "Id", "Name", bus.TripTypeId);
            return View(bus);
        }

        // GET: /Bus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusTimeId = new SelectList(db.BusTimes, "Id", "StopLocation", bus.BusTimeId);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", bus.DriverId);
            ViewBag.GuestId = new SelectList(db.Guests, "Id", "Name", bus.GuestId);
            ViewBag.StopsId = new SelectList(db.Intersections, "Id", "Name", bus.StopsId);
            ViewBag.Kiawah_Id = new SelectList(db.Kiawahs, "Id", "Name", bus.Kiawah_Id);
            ViewBag.StopsId = new SelectList(db.RouteStops, "Id", "Id", bus.StopsId);
            ViewBag.TripTypeId = new SelectList(db.TripTypes, "Id", "Name", bus.TripTypeId);
            return View(bus);
        }

        // POST: /Bus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StopsId,TripTypeId,Kiawah_Id,DriverId,BusTimeId,Date,GuestId")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusTimeId = new SelectList(db.BusTimes, "Id", "StopLocation", bus.BusTimeId);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", bus.DriverId);
            ViewBag.GuestId = new SelectList(db.Guests, "Id", "Name", bus.GuestId);
            ViewBag.StopsId = new SelectList(db.Intersections, "Id", "Name", bus.StopsId);
            ViewBag.Kiawah_Id = new SelectList(db.Kiawahs, "Id", "Name", bus.Kiawah_Id);
            ViewBag.StopsId = new SelectList(db.RouteStops, "Id", "Id", bus.StopsId);
            ViewBag.TripTypeId = new SelectList(db.TripTypes, "Id", "Name", bus.TripTypeId);
            return View(bus);
        }

        // GET: /Bus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: /Bus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bus bus = db.Buses.Find(id);
            db.Buses.Remove(bus);
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
