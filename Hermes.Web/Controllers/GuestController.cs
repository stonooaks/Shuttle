using Hermes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hermes.Web.Controllers
{
    public class GuestController : Controller
    {
        HermesContext db = new HermesContext();
        
        [HttpGet]
        public ActionResult Create(int regularId)
        {
            ViewBag.RegularId = regularId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,RegularId")] Guest guest)
        {
            int regularId = guest.RegularId;
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Details", "Regular", new { Id = regularId });
            }
            return View(guest);
        }

        
        public ActionResult Delete(int id)
        {

            Guest guest = db.Guests.Find(id);
            int regularId = guest.RegularId;
            db.Guests.Remove(guest);
            db.SaveChanges();
            return RedirectToAction("Details", "Regular", new { id = regularId });
        }

        
	}
}