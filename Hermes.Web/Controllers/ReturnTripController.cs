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
    public class ReturnTripController : Controller
    {
        private HermesContext db = new HermesContext();

        // GET: /ReturnTrip/
        public ActionResult Index()
        {
            var returntrips = db.ReturnTrips.Include(r => r.Regular);
            return View(returntrips.ToList());
        }

        // GET: /ReturnTrip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnTrip returntrip = db.ReturnTrips.Find(id);
            if (returntrip == null)
            {
                return HttpNotFound();
            }
            return View(returntrip);
        }

        // GET: /ReturnTrip/Create
        public ActionResult Create(int regularId, int HHID, DateTime Date)
        {
            ViewBag.HHID = HHID;
            ViewBag.Date = Date;
            ViewBag.RegularId = regularId;
            ViewBag.KiawahLocation = GetAddressList(HHID, null);
            return View();
        }

        // POST: /ReturnTrip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,RegularId,PickupTime,TripLocation,KiawahLocation")] ReturnTrip returntrip, DateTime selectedDateParam, int HHID)
        {

            int regularId = returntrip.RegularId;
            
            if (ModelState.IsValid)
            {
                db.ReturnTrips.Add(returntrip);
                db.SaveChanges();
                return RedirectToAction("Details", "Regular", new { id = regularId });
            }

            ViewBag.RegularId = new SelectList(db.Regulars, "Id", "KiawahLocation", returntrip.RegularId);
            return View(returntrip);
        }

        // GET: /ReturnTrip/Edit/5
        public ActionResult Edit(int? id, int regularId)
        {
            Regular regular = db.Regulars.Find(regularId);
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnTrip returntrip = db.ReturnTrips.Find(id);
            if (returntrip == null)
            {
                return HttpNotFound();
            }

            ViewBag.RegularId = regularId;
            ViewBag.KiawahLocation = GetAddressList(regular.HHID, returntrip.KiawahLocation );

            
            
            return View(returntrip);
        }

        // POST: /ReturnTrip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,RegularId,PickupTime,TripLocation,KiawahLocation")] ReturnTrip returntrip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returntrip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Regular", new {id = returntrip.RegularId });
            }
            ViewBag.RegularId = new SelectList(db.Regulars, "Id", "KiawahLocation", returntrip.RegularId);
            return View(returntrip);
        }

        // GET: /ReturnTrip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnTrip returntrip = db.ReturnTrips.Find(id);
            if (returntrip == null)
            {
                return HttpNotFound();
            }
            return View(returntrip);
        }

        // POST: /ReturnTrip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReturnTrip returntrip = db.ReturnTrips.Find(id);
            int regularId = returntrip.RegularId;
            db.ReturnTrips.Remove(returntrip);
            db.SaveChanges();
            return RedirectToAction("Details", "Regular", new { id = regularId});
        }

        private SelectList GetAddressList(int id, string selectedValue)
        {

            List<SelectListItem> AddressList = new List<SelectListItem>();
            var household = db.Households.Include(x => x.KiawahAddresses);

            foreach (Household h in household.Where(x => x.Id == id)) {

                foreach (KiawahAddress a in h.KiawahAddresses) {

                    AddressList.Add(new SelectListItem
                    {
                        Text = a.Address1.ToString(),
                        Value = a.Address1.ToString()

                    });
                }
            }

            foreach (var item in db.KiawahLocations) {

                AddressList.Add(new SelectListItem
                {
                    Text = item.Name.ToString(),
                    Value = item.Name.ToString()
                });
            }

            return new SelectList(AddressList, "Value", "Text", selectedValue);
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
