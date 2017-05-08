using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIRSS;

namespace SIRSS.Controllers
{
    public class DisablityTypesController : Controller
    {
        private SIRSSDBEntities db = new SIRSSDBEntities();

        // GET: DisablityTypes
        public ActionResult Index()
        {
            return View(db.DisablityTypes.ToList());
        }

        // GET: DisablityTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisablityType disablityType = db.DisablityTypes.Find(id);
            if (disablityType == null)
            {
                return HttpNotFound();
            }
            return View(disablityType);
        }

        // GET: DisablityTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisablityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Disability,Description")] DisablityType disablityType)
        {
            if (ModelState.IsValid)
            {
                db.DisablityTypes.Add(disablityType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disablityType);
        }

        // GET: DisablityTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisablityType disablityType = db.DisablityTypes.Find(id);
            if (disablityType == null)
            {
                return HttpNotFound();
            }
            return View(disablityType);
        }

        // POST: DisablityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Disability,Description")] DisablityType disablityType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disablityType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disablityType);
        }

        // GET: DisablityTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisablityType disablityType = db.DisablityTypes.Find(id);
            if (disablityType == null)
            {
                return HttpNotFound();
            }
            return View(disablityType);
        }

        // POST: DisablityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DisablityType disablityType = db.DisablityTypes.Find(id);
            db.DisablityTypes.Remove(disablityType);
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
