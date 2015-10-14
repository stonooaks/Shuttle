/********************************************************************************
 * CLASS NAME:      ReportController.cs
 * PROGRAMMER:      Michael Hughes
 * DESCRIPTION:     This is the controller for the Reports Views
 * VERSION:         1.0.0.0 
 * CREATED DATE:    4/1/2014
 * MODIFIED DATE:   
********************************************************************************/
        

using Hermes.Data.Models;
using Hermes.ViewModels.ReportViewModel;
using Hermes.ViewModels.ReturnTrips;
using Hermes.Web.ViewModels;
using Hughes.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hermes.Web.Controllers
{
    /// <summary>
    /// This is the controller for the Reports Views
    /// </summary>
    public class ReportController : Controller
    {

        #region Public Declared Objects
        HermesContext db = new HermesContext();
        DriverLogViewModel vm;
        OwnerCheckViewModel ownerVm;
        DriverLog dl = new DriverLog();
        //LogEventLog log = new LogEventLog(); 
        #endregion


        #region MVC Actions
        
        /// <summary>
        /// Default Index Action
        /// </summary>
        /// <param name="Date">Date of Report</param>
        /// <returns>Index View</returns>
        public ActionResult Index(DateTime Date)
        {
            return View();

        }

        /// <summary>
        /// Daily Report Action
        /// </summary>
        /// <param name="Date">Date of requested information</param>
        /// <returns>View with List of VMs</returns>
        [HttpGet]
        public ActionResult DailyReport(DateTime Date)
        {
            //Create a list of DriverLogViewModel objects
            List<DriverLogViewModel> dlList = new List<DriverLogViewModel>();

            //Create a new ViewBag with date variable in the longstringformat
            ViewBag.Date = Date.ToLongDateString();

            //Create a regular list with the date, if the trip is not cancelled
            // and order it by Pickup times
            var regular = db.Regulars.Where(x => x.Date == Date)
                                    .Where(x => x.IsCancelled == false)
                                    .OrderBy(x => x.PickupTime)
                                    .ToList();

            //foreach item in regular object list
            foreach (var item in regular) {

                //Create a new VM
                vm = new DriverLogViewModel(item.Id);

                //add it to the list
                dlList.Add(vm);
                if (item.ReturnTrips.Count != 0) {

                    //Create a new return trip VM
                    vm = dl.CreateRTVM(item.Id);

                    //add it to the list
                    dlList.Add(vm);
                }

            }

            //Try to send the list of trips to the view
            try {
                return PartialView(dlList);


            }
            //Catch an Exception
            catch (Exception e) {

                //Log the Exception message and the custom method
               // log.FatalError(e.Message);
               // log.FatalError(Hermes.ViewModels.ReportViewModel.Resources.InvalidDailyReportLog, 23);

                //Return HttpNotFound View
                return new HttpNotFoundResult();
            }
        }

        /// <summary>
        /// Daily Report Action
        /// </summary>
        /// <param name="Date">Date of requested information</param>
        /// <returns>View with List of VMs</returns>
        [HttpGet]
        public ActionResult DailyReportDate(DateTime StartDate, DateTime EndDate)
        {
            double SumTotal = 0.0;
            //Create a list of DriverLogViewModel objects
            List<DriverLogViewModel> dlList = new List<DriverLogViewModel>();

            //Create a new ViewBag with date variable in the longstringformat
            ViewBag.StartDate = StartDate.ToShortDateString();
            ViewBag.EndDate = EndDate.ToShortDateString();

            //Create a regular list with the date, if the trip is not cancelled
            // and order it by Pickup times
            var regular = db.Regulars.Where(x => x.Date >= StartDate)
                                     .Where(x => x.Date <= EndDate)
                                     .Where(x => x.IsCancelled == false)
                                     .ToList();

                               

            //foreach item in regular object list
            foreach (var item in regular) {

                //Create a new VM
                vm = new DriverLogViewModel(item.Id);
                SumTotal = SumTotal + item.Cost.Value;

                //add it to the list
                dlList.Add(vm);
                //if (item.ReturnTrips.Count != 0) {

                //    //Create a new return trip VM
                //    vm = dl.CreateRTVM(item.Id);

                //    //add it to the list
                //    dlList.Add(vm);
                //}

            }
            ViewBag.SumTotal = SumTotal;
            //Try to send the list of trips to the view
            try {
                return PartialView(dlList);


            }
            //Catch an Exception
            catch (Exception e) {

                //Log the Exception message and the custom method
                //log.FatalError(e.Message);
                //log.FatalError(Hermes.ViewModels.ReportViewModel.Resources.InvalidDailyReportLog, 23);

                //Return HttpNotFound View
                return new HttpNotFoundResult();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OwnerReport(string searchTerm)
        {

            ViewBag.Owner = searchTerm;
            var trips = db.Regulars.Where(x => x.Household.Name == searchTerm);

            List<OwnerCheckViewModel> ownerList = new List<OwnerCheckViewModel>();

            foreach (var item in trips) {

                ownerVm = new OwnerCheckViewModel(item.Id);
                ownerList.Add(ownerVm);
            }


            return PartialView(ownerList);
        }

        public ActionResult DailyReportWrap()
        {
            return View();
        }

        public JsonResult OwnerNames(string term)
        {
            List<string> households;

            households = db.Households.Where(x => x.Name.Contains(term)).Select(y => y.Name).ToList();

            return Json(households, JsonRequestBehavior.AllowGet);
        }
        #endregion


	}
}