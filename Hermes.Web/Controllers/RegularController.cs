using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hermes.Data.Models;
using System.Collections;
using System.Data.SqlClient;
using Hermes.Web.ViewModels;
using Hermes.ViewModels.Common;


namespace Hermes.Web.Controllers
{
    public class RegularController : Controller
    {
        private HermesContext db = new HermesContext();
        private int _HHID;
        private RegularViewModel vm;
        private List<string> AddAddressList = new List<string>();
        private VMFormats meth = new VMFormats();
        //private GoogleService gService = new GoogleService();
        
        

        //These are all the Index and Detail Actions
        #region Index/Detail Action
        // GET: /Regular/
        public ActionResult Index()
        {
            
            var regulars = db.Regulars.Include(r => r.Driver).Include(r => r.TripType);
            

            return View(regulars.ToList());
        }

        [HttpGet]
        public ActionResult Index(DateTime? selectedDateparam, int? HHID, int? memberId)
        {
            DateTime selectedDate = selectedDateparam != null ? selectedDateparam.Value : DateTime.Now;
            _HHID = HHID != null ? HHID.Value : 2;
            int MemberId = memberId != null ? memberId.Value : 2;
            //string shortselectedDate = selectedDate.ToShortDateString();
            ViewBag.Date = String.Format("{0:dddd  MMMM dd, yyyy}", selectedDate);
            ViewBag.HHID = _HHID;
            ViewBag.MemberId = MemberId;



            var regulars = db.Regulars
                .Where(x => x.Date == selectedDate)
                .Where(x => x.IsCancelled == false)
                .OrderBy(x=> x.PickupTime)
                .ToList();
                
            

            foreach (var regular in regulars) {

                regular.Count = regular.Members.Count() + regular.Guests.Count();
            }

            

            
            return View(regulars);
        }

        // GET: /Regular/Details/5
        public ActionResult Details(int? id)
        {
            int count = 0;
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regular regular = db.Regulars.Find(id);
            if (regular == null) {
                return HttpNotFound();
            }
            
            foreach (var item in regular.Members.ToList()) {

                count++;
                
            }

            foreach (var item in regular.Guests.ToList()) {
                count++;
            }

            ViewBag.Count = count;
            return View(regular);
        }

        #endregion


        //These are all the Create Actions
        #region Create Actions
        // GET: /Regular/Create
        public ActionResult Create(int HHID, DateTime Date, int MemberId)
        {
            RegularViewModel vm = new RegularViewModel();

            //Creates the data needed for the Create Form
            vm.HHID = HHID;
            vm.MemberId = MemberId;
            vm.Date = Date;
            ViewBag.MemberList = memberList(HHID, null);
            ViewBag.KiawahLocation = GetAddressList(HHID, null);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name");
            ViewBag.TripTypeId = new SelectList(db.TripTypes, "Id", "Name");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name");
            return View(vm);
        }
        
        // POST: /Regular/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TripTypeId,Date,HHID,MemberId,KiawahLocation,OtherAddress,TripLocation,NonKiawahPickup,DriverId,VehicleId,PickupTime,OfficerName,Email,Phone,Notes")] RegularViewModel vm, string[] Members)
        {
            //If no members have been entered, the string array will return null.
            //To stop this, I have written initialized the array to allow it to be counted in the next
            //code segment.

            string otheraddress = vm.OtherAddress;
            if (vm.KiawahLocation == "Other") {
                vm.KiawahLocation = otheraddress;
            }

            Regular regular = new Regular()
            {
                TripTypeId = vm.TripTypeId,
                Date = vm.Date,
                HHID = vm.HHID,
                MemberId = vm.MemberId,
                KiawahLocation = vm.KiawahLocation,
                TripLocation = vm.TripLocation,
                NonKiawahPickup = vm.NonKiawahPickup,
                DriverId = vm.DriverId,
                VehicleId = vm.VehicleId,
                PickupTime = vm.PickupTime,
                OfficerName = vm.OfficerName,
                Email = vm.Email,
                Phone = vm.Phone,
                Notes = vm.Notes,
                otherAddress = vm.OtherAddress
            };

            if (Members == null) {
                Members = new string[] { };
            }

            //This checks to be sure the model is valid before creating it
            if (ModelState.IsValid) {

                //If there are Members that have been entered into the 
                //trip, this adds them to the object
                if (Members.Count() != 0) {
                    foreach (var item in Members) {

                        int intitem = Convert.ToInt32(item);
                        Member member = db.Members.Find(intitem);
                        regular.Members.Add(member);
                    }
                }

                
                //Recovers the id for the return trip
                int regularId = regular.Id;
                //regular.Count = meth.CountGuests(regularId);
                //regular.Cost = meth.calculateTripCost(regularId);

                db.Regulars.Add(regular);
                db.SaveChanges();

                Regular regularobject = db.Regulars.Find(regular.Id);
                int hhid = regular.HHID;
                return View("Details", regularobject);
            }

            //If the model is not valid, have them re-enter all the information
            
            ViewBag.MemberList = memberList(regular.HHID, null);
            ViewBag.KiawahLocation = GetAddressList(regular.HHID, null);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", regular.DriverId);
            ViewBag.TripTypeId = new SelectList(db.TripTypes, "Id", "Name", regular.TripTypeId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name", regular.VehicleId);
            return View(vm);
        }

        
        #endregion

        #region Edit Actions
        // GET: /Regular/Edit/5
        public ActionResult Edit(int? id)
        {
            //check to be sure that the id is not null
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //create the view model object and test to see if it is not null
            RegularViewModel vm = new RegularViewModel(id.Value);
            if (vm == null) {
                return HttpNotFound();
            }
            List<string> membersSelectedList = new List<string>();
            foreach (var member in vm.Members){
                membersSelectedList.Add(member.Id.ToString());
            }

            string[] selectedMembers = membersSelectedList.ToArray();        
            

            if (vm.OtherAddress != null) {
                vm.KiawahLocation = "Other";
            }
            ViewBag.MemberList = memberList(vm.HHID, selectedMembers);
            ViewBag.KiawahLocation = GetAddressList(vm.HHID, vm.KiawahLocation);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", vm.DriverId);
            ViewBag.TripTypeId = new SelectList(db.TripTypes, "Id", "Name", vm.TripTypeId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name", vm.VehicleId);
            return View(vm);
        }

        // POST: /Regular/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegularId,HHID,TripTypeId,KiawahLocation,otherAddress,TripLocation,NonKiawahPickup,MemberId,VehicleId,DriverId,Date,PickupTime,OfficerName,Email,Phone,Notes")] RegularViewModel vm, string[] Members)
        {

            //Set values to the parameters
            DateTime selectedDateParam = vm.Date;
            int HHID = vm.HHID;
            int memberId = vm.MemberId.Value;
            Regular regular = db.Regulars.Find(vm.RegularId);
            
            if (ModelState.IsValid) {

                string otheraddress = vm.OtherAddress;
                if (vm.KiawahLocation == "Other") {
                    vm.KiawahLocation = otheraddress;
                }
                

                regular.TripTypeId = vm.TripTypeId;
                regular.KiawahLocation = vm.KiawahLocation;
                regular.TripLocation = vm.TripLocation;
                regular.NonKiawahPickup = vm.NonKiawahPickup;
                regular.VehicleId = vm.VehicleId;
                regular.PickupTime = vm.PickupTime;
                regular.OfficerName = vm.OfficerName;
                regular.Email = vm.Email;
                regular.Phone = vm.Phone;
                regular.Notes = vm.Notes;
               
                
                if (Members == null) {
                    Members = new string[] { };
                }


                if (Members.Count() != 0) {
                    foreach (var item in Members) {

                        int intitem = Convert.ToInt32(item);
                        Member member = db.Members.Find(intitem);
                        regular.Members.Add(member);
                    }
                }

                //regular.Count = meth.CountGuests(regular.Id);
                //regular.Cost = meth.calculateTripCost(regular.Id);
                

                
                db.Entry(regular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Regular", new { Id = regular.Id});
            }

            List<string> memberSelectedList = new List<string>();
            foreach (var member in regular.Members) {
                memberSelectedList.Add(member.Name);
            }

            string[] memberSelected = memberSelectedList.ToArray();
                        
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Name");
            ViewBag.MemberList = memberList(regular.HHID, memberSelected);
            ViewBag.KiawahLocation = GetAddressList(regular.HHID, vm.KiawahLocation);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", vm.DriverId);
            ViewBag.TripTypeId = new SelectList(db.TripTypes, "Id", "Name", vm.TripTypeId);

            return View(vm);
        } 
        #endregion

        #region Delete Actions

        // GET: /Regular/Delete/5
        public ActionResult Delete(int? id )
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regular regular = db.Regulars.Find(id);
            if (regular == null) {
                return HttpNotFound();
            }
            return View(regular );
        }

        // POST: /Regular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Regular regular = db.Regulars.Find(id);

            DateTime selectedDateParam = regular.Date;
            int HHID = regular.HHID;
            ViewBag.Date = selectedDateParam;
            ViewBag.HHID = HHID;
            string email = regular.Email;
            int regulari = regular.Id;

            regular.IsCancelled = true;                        
            db.SaveChanges();
            return RedirectToAction("EmailView", "ShoppingCart", new { type = "cancel", email = email, regularId = regulari });
        } 

        #endregion

        #region Member Guest Actions

        [HttpGet]
        public ActionResult CreateMemberGuest(int tripId, int HHID)
        {
            ViewBag.MemberList = memberList(HHID, null);
            return View();
        }

        [HttpPost]
        public ActionResult CreateMemberGuest(string[] Members, int tripId)
        {
            

            return View("Index");
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

            //foreach household where it has the householdid provided
            foreach (Household h in household.Where(x => x.Id == id)) {

                //this foreach is looking for the kiawah lots that are owned by the 
                //household and adding them to a list
                foreach (KiawahAddress a in h.KiawahAddresses) {

                    AddressList.Add(new SelectListItem
                    {
                        Text = a.Address1.ToString(),
                        Value = a.Address1.ToString()

                    });
                }

                
            }

            //this foreach is adding all the other kiawah locations to that
            //list
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
        /// This methd generates a list of 
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
        private List<Member> Getmembers(int HHID){
        
            List<Member> members = new List<Member>();
            foreach (Member member in db.Members.Where(x => x.HouseholdId == HHID))
	        {
                members.Add(member);
		 
	        }
            return members;
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
