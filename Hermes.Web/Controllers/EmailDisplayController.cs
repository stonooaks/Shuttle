using Hermes.Data.Models;
using Hermes.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hermes.Web.Controllers
{
    public class EmailDisplayController : Controller
    {
        private EmailViewModel vm = new EmailViewModel();
        private HermesContext db = new HermesContext();

        //
        // GET: /EmailDisplay/
        public ActionResult Index()
        {
            return View();
        }

        
        public PartialViewResult _PhoneList(int regularId)
        {

            vm.Regular = db.Regulars.Find(regularId);

            vm.Emails.Add(vm.Regular.Member.Email);

            foreach (var phone in vm.Regular.Member.Phones) {

                vm.Phones.Add(phone.Number);
            }

            ViewBag.PhoneList = new SelectList(vm.Phones, null);
            ViewBag.EmailList = new SelectList(vm.Emails, null);

            return PartialView("_PhoneList");
        }

        public PartialViewResult _AddPhone(string phone)
        {
            vm.Phones.Add(phone);
            return PartialView("_PhoneList");
        }

        public PartialViewResult _AddEmail(string email)
        {
            vm.Emails.Add(email);
            return PartialView("_PhoneList");
        }
	}
}