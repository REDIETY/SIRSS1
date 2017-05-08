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
    public class SectionTypesController : Controller
    {
        private SIRSSDBEntities db = new SIRSSDBEntities();

        // GET: SectionTypes
        public ActionResult Index()
        {
            return View(db.SectionTypes.ToList());
        }

        // GET: SectionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionType sectionType = db.SectionTypes.Find(id);
            if (sectionType == null)
            {
                return HttpNotFound();
            }
            return View(sectionType);
        }

        // GET: SectionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SectionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] SectionType sectionType)
        {
            if (ModelState.IsValid)
            {
                db.SectionTypes.Add(sectionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sectionType);
        }

        // GET: SectionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionType sectionType = db.SectionTypes.Find(id);
            if (sectionType == null)
            {
                return HttpNotFound();
            }
            return View(sectionType);
        }

        // POST: SectionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] SectionType sectionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sectionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sectionType);
        }

        // GET: SectionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionType sectionType = db.SectionTypes.Find(id);
            if (sectionType == null)
            {
                return HttpNotFound();
            }
            return View(sectionType);
        }

        // POST: SectionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SectionType sectionType = db.SectionTypes.Find(id);
            db.SectionTypes.Remove(sectionType);
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
