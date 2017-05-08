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
    public class TeachersController : Controller
    {
        private SIRSSDBEntities db = new SIRSSDBEntities();

        // GET: Teachers
        public ActionResult Index()
        {
            var teachers = db.Teachers.Include(t => t.Address).Include(t => t.DisablityType).Include(t => t.Staff).Include(t => t.Subject);
            return View(teachers.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "FirstName");
            ViewBag.DisablityId = new SelectList(db.DisablityTypes, "Id", "Disability");
            ViewBag.StaffId = new SelectList(db.Staffs, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HireDate,AddressId,SubjectId,StaffId,DisablityId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "FirstName", teacher.AddressId);
            ViewBag.DisablityId = new SelectList(db.DisablityTypes, "Id", "Disability", teacher.DisablityId);
            ViewBag.StaffId = new SelectList(db.Staffs, "Id", "Name", teacher.StaffId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", teacher.SubjectId);
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "FirstName", teacher.AddressId);
            ViewBag.DisablityId = new SelectList(db.DisablityTypes, "Id", "Disability", teacher.DisablityId);
            ViewBag.StaffId = new SelectList(db.Staffs, "Id", "Name", teacher.StaffId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", teacher.SubjectId);
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HireDate,AddressId,SubjectId,StaffId,DisablityId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "FirstName", teacher.AddressId);
            ViewBag.DisablityId = new SelectList(db.DisablityTypes, "Id", "Disability", teacher.DisablityId);
            ViewBag.StaffId = new SelectList(db.Staffs, "Id", "Name", teacher.StaffId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectCode", teacher.SubjectId);
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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
