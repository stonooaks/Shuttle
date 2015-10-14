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
    /// <summary>
    /// Controller to Add additional items
    /// </summary>
    public class AdditionalController : Controller
    {
        private HermesContext db = new HermesContext();

        /// <summary>
        /// This action method returns all additional items and types to the 
        /// view
        /// <remarks>
        /// HTTPGET
        /// </remarks>
        /// </summary>
        /// <returns>Index View</returns>
        public ActionResult Index()
        {
            var additionals = db.Additionals.Include(a => a.AdditionalType);
            return View(additionals.ToList());
        }

        /// <summary>
        /// This GET action method returns a view showing the details of one 
        /// additional item
        /// </summary>
        /// <param name="id">Additional item id</param>
        /// <returns>Detail View</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional additional = db.Additionals.Find(id);
            if (additional == null)
            {
                return HttpNotFound();
            }
            return View(additional);
        }

        /// <summary>
        /// This GET action method returns a form view to enter in a new 
        /// Additional item
        /// </summary>
        /// <returns>Create Form View</returns>
        public ActionResult Create()
        {
            ViewBag.AdditionalTypeId = new SelectList(db.AdditionalTypes, "Id", "Name");
            return View();
        }
        
        /// <summary>
        /// This POST action method accepts an object back from the view and
        /// updates the Database
        /// </summary>
        /// <param name="additional">Additional object</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,AdditionalTypeId,Name,Cost")] Additional additional)
        {
            if (ModelState.IsValid)
            {
                db.Additionals.Add(additional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdditionalTypeId = new SelectList(db.AdditionalTypes, "Id", "Name", additional.AdditionalTypeId);
            return View(additional);
        }

        // GET: /Additional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional additional = db.Additionals.Find(id);
            if (additional == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdditionalTypeId = new SelectList(db.AdditionalTypes, "Id", "Name", additional.AdditionalTypeId);
            return View(additional);
        }

        // POST: /Additional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,AdditionalTypeId,Name,Cost")] Additional additional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdditionalTypeId = new SelectList(db.AdditionalTypes, "Id", "Name", additional.AdditionalTypeId);
            return View(additional);
        }

        // GET: /Additional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional additional = db.Additionals.Find(id);
            if (additional == null)
            {
                return HttpNotFound();
            }
            return View(additional);
        }

        // POST: /Additional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Additional additional = db.Additionals.Find(id);
            db.Additionals.Remove(additional);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Disposal method that clears the memory
        /// </summary>
        /// <param name="disposing"></param>
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
