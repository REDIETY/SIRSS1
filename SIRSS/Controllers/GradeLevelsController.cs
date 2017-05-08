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
    public class GradeLevelsController : Controller
    {
        private SIRSSDBEntities db = new SIRSSDBEntities();

        // GET: GradeLevels
        public ActionResult Index()
        {
            var gradeLevels = db.GradeLevels.Include(g => g.SectionType);
            return View(gradeLevels.ToList());
        }

        // GET: GradeLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLevel gradeLevel = db.GradeLevels.Find(id);
            if (gradeLevel == null)
            {
                return HttpNotFound();
            }
            return View(gradeLevel);
        }

        // GET: GradeLevels/Create
        public ActionResult Create()
        {
            ViewBag.SectionTypeId = new SelectList(db.SectionTypes, "Id", "Name");
            return View();
        }

        // POST: GradeLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GradeLevel1,Description,NumberOfSections,SectionTypeId")] GradeLevel gradeLevel)
        {
            if (ModelState.IsValid)
            {
                db.GradeLevels.Add(gradeLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SectionTypeId = new SelectList(db.SectionTypes, "Id", "Name", gradeLevel.SectionTypeId);
            return View(gradeLevel);
        }

        // GET: GradeLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLevel gradeLevel = db.GradeLevels.Find(id);
            if (gradeLevel == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionTypeId = new SelectList(db.SectionTypes, "Id", "Name", gradeLevel.SectionTypeId);
            return View(gradeLevel);
        }

        // POST: GradeLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GradeLevel1,Description,NumberOfSections,SectionTypeId")] GradeLevel gradeLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradeLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SectionTypeId = new SelectList(db.SectionTypes, "Id", "Name", gradeLevel.SectionTypeId);
            return View(gradeLevel);
        }

        // GET: GradeLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLevel gradeLevel = db.GradeLevels.Find(id);
            if (gradeLevel == null)
            {
                return HttpNotFound();
            }
            return View(gradeLevel);
        }

        // POST: GradeLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GradeLevel gradeLevel = db.GradeLevels.Find(id);
            db.GradeLevels.Remove(gradeLevel);
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
