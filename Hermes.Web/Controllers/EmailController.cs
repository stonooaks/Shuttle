using Hermes.Data.Models;
using Hermes.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hermes.Web.Controllers
{
    public class EmailController : Controller
    {

        EmailViewModel emailVM = new EmailViewModel();
        HermesContext db = new HermesContext();

    
        //
        // GET: /Email/
        public PartialViewResult _InformationForm(int memberId)
        {
            prepopulateEmailAddress(memberId);
            ViewBag.EmailList = new SelectList(emailVM.Emails, null);
            ViewBag.PhoneList = new SelectList(emailVM.Phones, null);
            return PartialView();
        }

        #region private Methods
        /// <summary>
        /// This private method prepopulates a list of emails for SelectLists on the main page
        /// </summary>
        /// <param name="memberId"></param>
        private void prepopulateEmailAddress(int memberId)
        {
            foreach (var member in db.Members.Where(x=>x.Id == memberId)) {

                emailVM.Emails.Add(member.Email);
                
                foreach (var phone in member.Phones){
                    emailVM.Phones.Add(phone.Number);
                }
	
            }
        } 
        #endregion

        
	}
}