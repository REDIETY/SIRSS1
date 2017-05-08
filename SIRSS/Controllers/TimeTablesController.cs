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
    public class TimeTablesController : Controller
    {
        private SIRSSDBEntities db = new SIRSSDBEntities();

        // GET: TimeTables
        public ActionResult Index()
        {
            var timeTables = db.TimeTables.Include(t => t.GradeLevel).Include(t => t.Subject).Include(t => t.Teacher);
            return View(timeTables.ToList());
        }

        // GET: TimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // GET: TimeTables/Create
        public ActionResult Create()
        {
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Id");
            return View();
        }

        // POST: TimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Period,DayOfWeek,Year,Semister,SubjectId,GradeLevelId,TeacherId")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                db.TimeTables.Add(timeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1", timeTable.GradeLevelId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", timeTable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Id", timeTable.TeacherId);
            return View(timeTable);
        }

        // GET: TimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1", timeTable.GradeLevelId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", timeTable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Id", timeTable.TeacherId);
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Period,DayOfWeek,Year,Semister,SubjectId,GradeLevelId,TeacherId")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1", timeTable.GradeLevelId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", timeTable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Id", timeTable.TeacherId);
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeTable timeTable = db.TimeTables.Find(id);
            db.TimeTables.Remove(timeTable);
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
