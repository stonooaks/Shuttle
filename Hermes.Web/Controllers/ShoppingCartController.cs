/********************************************************************************
 * CLASS NAME:
 * PROGRAMMER:
 * DESCRIPTION:
 * VERSION:
 * CREATED DATE:
 * MODIFIED DATE:
********************************************************************************/

using Hermes.Data.Models;
using Hermes.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;
using Hermes.Message;
using Hughes.Common.Logging;
using Hughes.Common;
using System.Resources;
using Hermes.ViewModels.Common;


namespace Hermes.Web.Controllers
{
    /// <summary>
    /// Controller for Shopping Cart
    /// </summary>
	public class ShoppingCartController : Controller
    {

        #region Variable/Object Declarations
        EmailService service = new EmailService();
		private string _body;
        private ShoppingCartViewModel vm;
        private CancellationViewModel cvm;
        //private LogEventLog log = new LogEventLog();
		HermesContext db = new HermesContext();
        private VMFormats meth = new VMFormats();
        #endregion

        #region Actions
        // GET: /ShoppingCart/
		public ActionResult Index(int regularId)
		{
			return View();
		}
		
		/// <summary>
		/// This constructs a Member email to show
		/// </summary>
		/// <param name="regularId">int regular</param>
		/// <returns>view</returns>
		[HttpGet]
		public ActionResult MemberEmail(int regularId) {
            
            Regular regular = db.Regulars.Find(regularId);
            
           
            
            try {
                vm = new ShoppingCartViewModel(regularId);
                regular.Count = vm.Count;
                regular.Cost = vm.TotalCost;
                db.SaveChanges();
                return View(vm);
            }
            catch (Exception e) {
               // log.FatalError(e.Message);
                return new HttpNotFoundResult();
            }
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="regularId">Regular object Id</param>
		/// <param name="email">String Email Address</param>
		/// <param name="cancellation">Cancellation parameter true/false</param>
        /// <param name="edit">Edit parameter true/false</param>
		/// <returns></returns>
		[HttpGet]
		public ActionResult SendEmail(int regularId, string email, bool cancellation = false, bool edit = false)
		{
            var regular = db.Regulars.Find(regularId);
            ViewBag.HHID = regular.HHID;
            ViewBag.MemberId = regular.MemberId;
            ViewBag.selectedDateParam = regular.Date;
            regular.Cost = meth.calculateTripCost(regularId);
            regular.Count = meth.CountGuests(regularId);

            db.SaveChanges();
			//If the email is a regular email, then the vm is created
			if (cancellation == false) {
                if (edit == false) {
                    vm = new ShoppingCartViewModel(regularId);

                    // this script calls the RenderViewToString method to call the 
                    // MemberEmail view and insert the ShoppingCart model
                    //then write it to a string of html for the EmailService
                    this._body = RenderViewToString("MemberEmail", vm);
                }
                else {
                    vm = new ShoppingCartViewModel(regularId);

                    // this script calls the RenderViewToString method to call the 
                    // EditEmail view and insert the ShoppingCart model
                    //then write it to a string of html for the EmailService
                    this._body = RenderViewToString("EditionEmail", vm);
                }
			}
			else {
                cvm = new CancellationViewModel(regularId);

                // this script calls the RenderViewToString method to call the 
                // CancellationEmail view and insert the ShoppingCart model
                //then write it to a string of html for the EmailService
                this._body = RenderViewToString("CancellationEmail", cvm);
			}
            

			//Calls the CreateMessage method from the Hermes.Method Project
			//that will take the body of html and a list of 
			service.CreateMessage(_body, email);
			
			

			
			 
			return View();
		}

		/// <summary>
		/// This Action is a HttpGet method that returns a email for a reservation cancellation
		/// </summary>
		/// <param name="regularId">Sent from the Regular controller after a cancellation</param>
		/// <returns>A view that has the view model information attached to it</returns>
		public ActionResult CancellationEmail(int regularId){

            try {
                CancellationViewModel vm = new CancellationViewModel(regularId);

                return View(vm);
            }
            catch (Exception e) {

               // log.FatalError(e.Message);
                return new HttpNotFoundResult();
            }
		}

        /// <summary>
        /// This Action is a HttpGet method that returns an email for a reservation edition
        /// </summary>
        /// <param name="regularId">regular Id</param>
        /// <returns>A view</returns>
        public ActionResult EditionEmail(int regularId)
        {
            try {
                ShoppingCartViewModel vm = new ShoppingCartViewModel(regularId);

                return View(vm);
            }
            catch (Exception e) {
                
//log.FatalError(e.Message);
                return new HttpNotFoundResult();
            }
        }

        /// <summary>
        /// This Action is a HttpGet Method that returns the Email buttons so that the
        /// when an email is sent, the buttons do not appear in the email
        /// </summary>
        /// <param name="type">the type of email either new, cancel, edit</param>
        /// <param name="email">the email string from the RenderViewToString method</param>
        /// <param name="regularId">regular Id</param>
        /// <returns>a view</returns>
        public ActionResult EmailView(string type, string email, int regularId)
        {
            ViewBag.regularId = regularId;
            ViewBag.Email = email;
            ViewBag.type = type;
            return View();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Renders a email body from a View
        /// </summary>
        /// <param name="viewName">View Name</param>
        /// <param name="model">View Model</param>
        /// <returns>string in html for Body</returns>
        protected string RenderViewToString(string viewName, object model)
		{
			if (string.IsNullOrEmpty(viewName))
				viewName = ControllerContext.RouteData.GetRequiredString("MemberEmail");

			ViewData.Model = model;

			using (StringWriter sw = new StringWriter()) {

				ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
				ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
				viewResult.View.Render(viewContext, sw);
				return sw.GetStringBuilder().ToString();
			}
        }

        #endregion


    }
}