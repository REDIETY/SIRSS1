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
    public class ExamSchedulesController : Controller
    {
        private SIRSSDBEntities db = new SIRSSDBEntities();

        // GET: ExamSchedules
        public ActionResult Index()
        {
            var examSchedules = db.ExamSchedules.Include(e => e.ClassRoom).Include(e => e.GradeLevel).Include(e => e.Subject).Include(e => e.Teacher);
            return View(examSchedules.ToList());
        }

        // GET: ExamSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSchedule examSchedule = db.ExamSchedules.Find(id);
            if (examSchedule == null)
            {
                return HttpNotFound();
            }
            return View(examSchedule);
        }

        // GET: ExamSchedules/Create
        public ActionResult Create()
        {
            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Location");
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Id");
            return View();
        }

        // POST: ExamSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Semister,Year,ExamHour,SectionName,GradeLevelId,SubjectId,TeacherId,ClassRoomId")] ExamSchedule examSchedule)
        {
            if (ModelState.IsValid)
            {
                db.ExamSchedules.Add(examSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Location", examSchedule.ClassRoomId);
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1", examSchedule.GradeLevelId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", examSchedule.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Id", examSchedule.TeacherId);
            return View(examSchedule);
        }

        // GET: ExamSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSchedule examSchedule = db.ExamSchedules.Find(id);
            if (examSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Location", examSchedule.ClassRoomId);
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1", examSchedule.GradeLevelId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", examSchedule.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Id", examSchedule.TeacherId);
            return View(examSchedule);
        }

        // POST: ExamSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Semister,Year,ExamHour,SectionName,GradeLevelId,SubjectId,TeacherId,ClassRoomId")] ExamSchedule examSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Location", examSchedule.ClassRoomId);
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1", examSchedule.GradeLevelId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", examSchedule.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Id", examSchedule.TeacherId);
            return View(examSchedule);
        }

        // GET: ExamSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSchedule examSchedule = db.ExamSchedules.Find(id);
            if (examSchedule == null)
            {
                return HttpNotFound();
            }
            return View(examSchedule);
        }

        // POST: ExamSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamSchedule examSchedule = db.ExamSchedules.Find(id);
            db.ExamSchedules.Remove(examSchedule);
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
