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
    public class ExamResultsController : Controller
    {
        private SIRSSDBEntities db = new SIRSSDBEntities();

        // GET: ExamResults
        public ActionResult Index()
        {
            var examResults = db.ExamResults.Include(e => e.ResultType).Include(e => e.Subject);
            return View(examResults.ToList());
        }

        // GET: ExamResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = db.ExamResults.Find(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }
            return View(examResult);
        }

        // GET: ExamResults/Create
        public ActionResult Create()
        {
            ViewBag.ResultTypeId = new SelectList(db.ResultTypes, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode");
            return View();
        }

        // POST: ExamResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Semister,SubjectId,ResultTypeId,Value,Result")] ExamResult examResult)
        {
            if (ModelState.IsValid)
            {
                db.ExamResults.Add(examResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResultTypeId = new SelectList(db.ResultTypes, "Id", "Name", examResult.ResultTypeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", examResult.SubjectId);
            return View(examResult);
        }

        // GET: ExamResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = db.ExamResults.Find(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResultTypeId = new SelectList(db.ResultTypes, "Id", "Name", examResult.ResultTypeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", examResult.SubjectId);
            return View(examResult);
        }

        // POST: ExamResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Semister,SubjectId,ResultTypeId,Value,Result")] ExamResult examResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResultTypeId = new SelectList(db.ResultTypes, "Id", "Name", examResult.ResultTypeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", examResult.SubjectId);
            return View(examResult);
        }

        // GET: ExamResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = db.ExamResults.Find(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }
            return View(examResult);
        }

        // POST: ExamResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamResult examResult = db.ExamResults.Find(id);
            db.ExamResults.Remove(examResult);
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
