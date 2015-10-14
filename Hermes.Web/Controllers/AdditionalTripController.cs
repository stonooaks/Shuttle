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
    public class AdditionalTripController : Controller
    {
        private HermesContext db = new HermesContext();

        // GET: /AdditionalTrip/
        public ActionResult Index()
        {
            var additionaltrips = db.AdditionalTrips.Include(a => a.Additional).Include(a => a.Regular);
            return View(additionaltrips.ToList());
        }

        // GET: /AdditionalTrip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalTrip additionaltrip = db.AdditionalTrips.Find(id);
            if (additionaltrip == null)
            {
                return HttpNotFound();
            }
            return View(additionaltrip);
        }

        // GET: /AdditionalTrip/Create
        public ActionResult Create(int regularId)
        {
            ViewBag.AdditionalId = new SelectList(db.Additionals, "Id", "Name");
            ViewBag.RegularId = regularId;
            return View();
        }

        // POST: /AdditionalTrip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,RegularId,AdditionalId,Number,Notes,Location")] AdditionalTrip additionaltrip)
        {

            int regularId = additionaltrip.RegularId;

            
               
            

            if (ModelState.IsValid)
            {   
                
                db.AdditionalTrips.Add(additionaltrip);
                db.SaveChanges();
                
                return RedirectToAction("Details", "Regular", new { id = regularId });
            }

            
            
            
            ViewBag.AdditionalId = new SelectList(db.Additionals, "Id", "Name", additionaltrip.AdditionalId);
            ViewBag.RegularId = additionaltrip.Id;
            return View(additionaltrip);
        }

        // GET: /AdditionalTrip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalTrip additionaltrip = db.AdditionalTrips.Find(id);
            if (additionaltrip == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdditionalId = new SelectList(db.Additionals, "Id", "Name", additionaltrip.AdditionalId);
            ViewBag.RegularId = new SelectList(db.Regulars, "Id", "KiawahLocation", additionaltrip.RegularId);
            return View(additionaltrip);
        }

        // POST: /AdditionalTrip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,RegularId,AdditionalId,Number")] AdditionalTrip additionaltrip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additionaltrip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdditionalId = new SelectList(db.Additionals, "Id", "Name", additionaltrip.AdditionalId);
            ViewBag.RegularId = new SelectList(db.Regulars, "Id", "KiawahLocation", additionaltrip.RegularId);
            return View(additionaltrip);
        }

        
        public ActionResult Delete(int id)
        {

            AdditionalTrip at = db.AdditionalTrips.Find(id);
            int regularId = at.RegularId;
            db.AdditionalTrips.Remove(at);
            db.SaveChanges();
            return RedirectToAction("Details", "Regular", new { id = regularId });
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
