using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIRSS.Models;

namespace SIRSS.Controllers
{
    public class SubjectGradesRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubjectGradesRecords
        public ActionResult Index()
        {
            var subjectGradesRecords = db.SubjectGradesRecords.Include(s => s.Subject);
            return View(subjectGradesRecords.ToList());
        }

        // GET: SubjectGradesRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectGradesRecord subjectGradesRecord = db.SubjectGradesRecords.Find(id);
            if (subjectGradesRecord == null)
            {
                return HttpNotFound();
            }
            return View(subjectGradesRecord);
        }

        // GET: SubjectGradesRecords/Create
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode");
            return View();
        }

        // POST: SubjectGradesRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubjectId,ClassExam,MidExam,FinalExam,IsDeleted")] SubjectGradesRecord subjectGradesRecord)
        {
            if (ModelState.IsValid)
            {
                db.SubjectGradesRecords.Add(subjectGradesRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", subjectGradesRecord.SubjectId);
            return View(subjectGradesRecord);
        }

        // GET: SubjectGradesRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectGradesRecord subjectGradesRecord = db.SubjectGradesRecords.Find(id);
            if (subjectGradesRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", subjectGradesRecord.SubjectId);
            return View(subjectGradesRecord);
        }

        // POST: SubjectGradesRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubjectId,ClassExam,MidExam,FinalExam,IsDeleted")] SubjectGradesRecord subjectGradesRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectGradesRecord).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", subjectGradesRecord.SubjectId);
            return View(subjectGradesRecord);
        }

        // GET: SubjectGradesRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectGradesRecord subjectGradesRecord = db.SubjectGradesRecords.Find(id);
            if (subjectGradesRecord == null)
            {
                return HttpNotFound();
            }
            return View(subjectGradesRecord);
        }

        // POST: SubjectGradesRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectGradesRecord subjectGradesRecord = db.SubjectGradesRecords.Find(id);
            db.SubjectGradesRecords.Remove(subjectGradesRecord);
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
