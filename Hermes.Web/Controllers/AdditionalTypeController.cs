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
    public class AdditionalTypeController : Controller
    {
        private HermesContext db = new HermesContext();

        // GET: /AdditionalType/
        public ActionResult Index()
        {
            return View(db.AdditionalTypes.ToList());
        }

        // GET: /AdditionalType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalType additionaltype = db.AdditionalTypes.Find(id);
            if (additionaltype == null)
            {
                return HttpNotFound();
            }
            return View(additionaltype);
        }

        // GET: /AdditionalType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AdditionalType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] AdditionalType additionaltype)
        {
            if (ModelState.IsValid)
            {
                db.AdditionalTypes.Add(additionaltype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(additionaltype);
        }

        // GET: /AdditionalType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalType additionaltype = db.AdditionalTypes.Find(id);
            if (additionaltype == null)
            {
                return HttpNotFound();
            }
            return View(additionaltype);
        }

        // POST: /AdditionalType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] AdditionalType additionaltype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additionaltype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(additionaltype);
        }

        // GET: /AdditionalType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalType additionaltype = db.AdditionalTypes.Find(id);
            if (additionaltype == null)
            {
                return HttpNotFound();
            }
            return View(additionaltype);
        }

        // POST: /AdditionalType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdditionalType additionaltype = db.AdditionalTypes.Find(id);
            db.AdditionalTypes.Remove(additionaltype);
            db.SaveChanges();
            return RedirectToAction("Index");
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
