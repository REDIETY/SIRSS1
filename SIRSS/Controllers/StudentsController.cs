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
    public class StudentsController : Controller
    {
        private SIRSSDBEntities db = new SIRSSDBEntities();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.ClassRoom).Include(s => s.DisablityType).Include(s => s.GradeLevel);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Location");
            ViewBag.DisablityTypeId = new SelectList(db.DisablityTypes, "Id", "Disability");
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Age,RegistrationNumber,GradeLevelId,ClassRoomId,DisablityTypeId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Location", student.ClassRoomId);
            ViewBag.DisablityTypeId = new SelectList(db.DisablityTypes, "Id", "Disability", student.DisablityTypeId);
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1", student.GradeLevelId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Location", student.ClassRoomId);
            ViewBag.DisablityTypeId = new SelectList(db.DisablityTypes, "Id", "Disability", student.DisablityTypeId);
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1", student.GradeLevelId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Age,RegistrationNumber,GradeLevelId,ClassRoomId,DisablityTypeId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Location", student.ClassRoomId);
            ViewBag.DisablityTypeId = new SelectList(db.DisablityTypes, "Id", "Disability", student.DisablityTypeId);
            ViewBag.GradeLevelId = new SelectList(db.GradeLevels, "Id", "GradeLevel1", student.GradeLevelId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
