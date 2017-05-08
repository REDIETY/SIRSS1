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
    public class ResultTypesController : Controller
    {
        private SIRSSDBEntities db = new SIRSSDBEntities();

        // GET: ResultTypes
        public ActionResult Index()
        {
            return View(db.ResultTypes.ToList());
        }

        // GET: ResultTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultType resultType = db.ResultTypes.Find(id);
            if (resultType == null)
            {
                return HttpNotFound();
            }
            return View(resultType);
        }

        // GET: ResultTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResultTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] ResultType resultType)
        {
            if (ModelState.IsValid)
            {
                db.ResultTypes.Add(resultType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resultType);
        }

        // GET: ResultTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultType resultType = db.ResultTypes.Find(id);
            if (resultType == null)
            {
                return HttpNotFound();
            }
            return View(resultType);
        }

        // POST: ResultTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] ResultType resultType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resultType);
        }

        // GET: ResultTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultType resultType = db.ResultTypes.Find(id);
            if (resultType == null)
            {
                return HttpNotFound();
            }
            return View(resultType);
        }

        // POST: ResultTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResultType resultType = db.ResultTypes.Find(id);
            db.ResultTypes.Remove(resultType);
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
