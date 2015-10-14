using Hermes.Data.Models;
using Hermes.Service;
using Hermes.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Hughes.Common;
using Hughes.Common.Logging;
using Hermes.ViewModels.MainViewModels;
using System.Diagnostics;

namespace Hermes.Web.Controllers
{
    /// <summary>
    /// Main page controller
    /// </summary>
    public class HomeController : Controller
    {


        #region Properties and Members
        
        /// <summary>
        /// Declare and Initialize Hermes Context
        /// </summary>
      HermesContext db = new HermesContext();
        SchedulerViewModel svm;
        //LogEventLog log = new LogEventLog();
        #endregion
        
        #region ActionResult Views
        
        /// <summary>
        /// This displays the index page
        /// </summary>
        /// <returns>returns the index view</returns>
        public ActionResult Index()
        {
#if DEBUG
            Trace.TraceInformation("Identify the account person");
#else
            log.Information(User.Identity.Name + " has logged in on " + DateTime.Now);
#endif
            

            
            

            return View();
        }

        /// <summary>
        /// Main Index page POST retrieves a search term and sends a member object to
        /// the results page
        /// </summary>
        /// <param name="searchTerm">searchTerm from autocomplete</param>
        /// <returns>results page with the member information</returns>
        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            var members = db.Members.ToList();
            
            foreach (var item in members) {

                if (item.Name == searchTerm) {
                    int id = item.Id;
                    ViewBag.householdId = item.HouseholdId;
                    ViewBag.MemberId = id;

                    Member member = db.Members.Find(id);
                    return View("Results", member);
                    

                }
                                
            }

            //log.Information("Invalid Member Assignment for Results Page", 80);
            return View("IndexFail");


        }

        /// <summary>
        /// Displays a results page
        /// </summary>
        /// <param name="id">Member ID</param>
        /// <returns>results view</returns>
        [HttpGet]
        public ActionResult Results(Member member)
        {
            //int householdId = 2;
            //foreach (var item in db.Members.Where(x => x.Id == member.Id)) {

            //    householdId = item.HouseholdId;


            //}


            if (member.Id == null) {

                return View("Index");
            }

            return View(db.Members.Find(member.Id));

        }  
        
        /// <summary>
        /// This opens up the reports view page
        /// </summary>
        /// <returns>Report View</returns>
        public ActionResult Reports()
        {
            return View();
        }
        #endregion

        #region Partial Views

        /// <summary>
        /// Depicts the Calendar
        /// </summary>
        /// <returns>View</returns>
        public ActionResult _Calendar()
        {
            return PartialView();
        }
        #endregion

        #region JsonResult Views

        /// <summary>
        /// This returns json to populate the autocomplete on the
        /// Index and IndexFail pages
        /// </summary>
        /// <param name="term"></param>
        /// <returns>JSON</returns>
        public JsonResult GetMembers(string term)
        {
            List<string> members;

            members = db.Members.Where(x => x.Name.Contains(term)).Select(y => y.Name).ToList();

            return Json(members, JsonRequestBehavior.AllowGet);


        }

        /// <summary>
        /// This returns json to populate the autocomplete on the Report
        /// Page
        /// </summary>
        /// <param name="term">Owners Name</param>
        /// <returns>json</returns>
        public JsonResult OwnerNames(string term)
        {
            List<string> households;

            households = db.Households.Where(x => x.Name.Contains(term)).Select(y => y.Name).ToList();

            return Json(households, JsonRequestBehavior.AllowGet);
        }
        

        /// <summary>
        /// Populates the calendar 
        /// </summary>
        /// <returns>json</returns>
        public JsonResult CalendarItems()
        {
            List<SchedulerViewModel> calendar = new List<SchedulerViewModel>();

            var regular = db.Regulars.ToList();

            foreach (var item in regular) {
               
                svm = new SchedulerViewModel(item.Id);
                calendar.Add(svm);
            }

            return Json(calendar, JsonRequestBehavior.AllowGet);
        }

        #endregion









    }
}