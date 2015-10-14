using Hermes.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hermes.Web.Controllers
{
    public class AllTripsController : Controller
    {

        HermesContext db = new HermesContext();
        //
        // GET: /AllTrips/
        public ActionResult Index()
        {
            var regulars = db.Regulars.ToList();
            return View(regulars);
        }

        #region Edit Actions
        // GET: /Regular/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regular regular = db.Regulars.Find(id);
            if (regular == null) {
                return HttpNotFound();
            }

            List<string> memberSelectedList = new List<string>();
            foreach (var member in regular.Members) {
                memberSelectedList.Add(member.Name);
            }

            string[] memberSelected = memberSelectedList.ToArray();

            ViewBag.HHID = regular.HHID;
            ViewBag.MemberList = memberList(regular.HHID, memberSelected);
            ViewBag.KiawahLocation = GetAddressList(regular.HHID, regular.KiawahLocation);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", regular.DriverId);
            ViewBag.TripTypeId = new SelectList(db.TripTypes, "Id", "Name", regular.TripTypeId);
            return View(regular);
        }

        // POST: /Regular/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TripTypeId,KiawahLocation,TripLocation,DriverId,Date,PickupTime,Officer_Name")] Regular regular, string[] Members)
        {




            if (ModelState.IsValid) {

                foreach (var item in Members) {

                    int intitem = Convert.ToInt32(item);
                    Member member = db.Members.Find(intitem);
                    regular.Members.Add(member);
                }
                db.Entry(regular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<string> memberSelectedList = new List<string>();
            foreach (var member in regular.Members) {
                memberSelectedList.Add(member.Name);
            }

            string[] memberSelected = memberSelectedList.ToArray();



            ViewBag.HHID = regular.HHID;
            ViewBag.MemberList = memberList(regular.HHID, memberSelected);
            ViewBag.KiawahLocation = GetAddressList(regular.HHID, regular.KiawahLocation);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", regular.DriverId);
            ViewBag.TripTypeId = new SelectList(db.TripTypes, "Id", "Name", regular.TripTypeId);
            return View(regular);
        }
        #endregion

        #region Delete Actions

        // GET: /Regular/Delete/5
        public ActionResult Delete(int? id, int memberId)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regular regular = db.Regulars.Find(id);
            if (regular == null) {
                return HttpNotFound();
            }
            return View(regular);
        }

        // POST: /Regular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Regular regular = db.Regulars.Find(id);

            DateTime selectedDateParam = regular.Date;
            int HHID = regular.HHID;

            foreach (var guest in regular.Guests.ToList()) {
                regular.Guests.Remove(guest);
            }

            foreach (var member in regular.Members.ToList()) {
                regular.Members.Remove(member);
            }

            foreach (var rtrip in regular.ReturnTrips.ToList()) {
                regular.ReturnTrips.Remove(rtrip);
            }

            foreach (var cart in regular.ShoppingCarts.ToList()) {
                regular.ShoppingCarts.Remove(cart);
            }
            db.Regulars.Remove(regular);
            db.SaveChanges();
            return RedirectToAction("Index", new { selectedDateParam });
        }

        #endregion

        #region Lists and Count
        /// <summary>
        /// This method populates a select list of Kiawah Address from
        /// the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="HHID"></param>
        /// <param name="selectedValues"></param>
        /// <returns></returns>
        private MultiSelectList memberList(int HHID, string[] selectedValues)
        {
            List<SelectListItem> mlist = new List<SelectListItem>();
            foreach (Member member in db.Members.Where(x => x.HouseholdId == HHID)) {

                mlist.Add(new SelectListItem
                {
                    Value = member.Id.ToString(),
                    Text = member.Name
                });
            }

            return new MultiSelectList(mlist, "Value", "Text", selectedValues);
        }

        private int CountGuests(int regularId)
        {
            Regular regular = db.Regulars.Find(regularId);
            int count = 0;

            foreach (var item in regular.Members) {
                count++;
            }
            return count;

        }
        #endregion
	}
}