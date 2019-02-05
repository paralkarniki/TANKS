using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment3_MVC_HospitalRecords.Models;

namespace Assignment3_MVC_HospitalRecords.Controllers
{
    public class DoctorTblsController : Controller
    {
        private HospitalRecordsDBContext db = new HospitalRecordsDBContext();

        // GET: DoctorTbls
        public ActionResult Index()
        {
            return View(db.DoctorTbls.ToList());
        }

        // GET: DoctorTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorTbl doctorTbl = db.DoctorTbls.Find(id);
            if (doctorTbl == null)
            {
                return HttpNotFound();
            }
            return View(doctorTbl);
        }
       

        // GET: DoctorTbls/Create
        public ActionResult Create()
        {
            ViewBag.docid = new SelectList(db.DoctorTbls, "Id", "firstname");
            return View();
        }

        // POST: DoctorTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(String firstname, String lastname)
        {
            DoctorTbl doctorTbl = new DoctorTbl();
            doctorTbl.firstname =firstname;
            doctorTbl.lastname = lastname;
            db.DoctorTbls.Add(doctorTbl);
            db.SaveChanges();
            return RedirectToAction("Admin", "Home");



            return View(doctorTbl);
        }

        // GET: DoctorTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            DoctorTbl doctorTbl = db.DoctorTbls.Find(id);
            ViewBag.docid = new SelectList(db.DoctorTbls, "Id", "firstname", "lastname");

            return View(doctorTbl);
        }

        // POST: DoctorTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstname,lastname")] DoctorTbl doctorTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DoctorTbls","List");
            }
            return View(doctorTbl);
        }

        // GET: DoctorTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorTbl doctorTbl = db.DoctorTbls.Find(id);
            if (doctorTbl == null)
            {
                return HttpNotFound();
            }
            return View(doctorTbl);
        }

        // POST: DoctorTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorTbl doctorTbl = db.DoctorTbls.Find(id);
            db.DoctorTbls.Remove(doctorTbl);
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
