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
    public class PatientTblsController : Controller
    {
        private HospitalRecordsDBContext db = new HospitalRecordsDBContext();

        // GET: PatientTbls
        public PartialViewResult All()
        {
            //var patientTbls = db.PatientTbls.Include(p => p.DoctorTbl);
            return PartialView("_Patient",db.PatientTbls.ToList());
        }

        public PartialViewResult AllPat()
        {
            return PartialView("_ViewPatient", db.PatientTbls.ToList());
        }
        // GET: PatientTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            if (patientTbl == null)
            {
                return HttpNotFound();
            }
            return View(patientTbl);
        }

        // GET: PatientTbls/Create
        public ActionResult Create()
        {
            ViewBag.docid = new SelectList(db.DoctorTbls, "Id", "firstname");
            return View();
        }

        // POST: PatientTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(String firstname, String lastname)
        {

            PatientTbl patientTbl = new PatientTbl();
            patientTbl.firstname = firstname;
            patientTbl.lastname = lastname;
            patientTbl.admission = DateTime.Now.Date;
            patientTbl.isdischarge = "N";
                db.PatientTbls.Add(patientTbl);
                db.SaveChanges();
                return RedirectToAction("Admin", "Home");
            

   
            return View(patientTbl);
        }

        // GET: PatientTbls/Edit/5
        public ActionResult List()
        {

            /* PatientTbl patientTbl = db.PatientTbls.Find(id);
             ViewBag.docid = new SelectList(db.DoctorTbls, "Id", "firstname", patientTbl.docid);
             return View(patientTbl);*/

            //list
            List<PatientTbl> patientTbl = db.PatientTbls.ToList();
            return View(patientTbl);
        }

        // GET: PatientTbls/Edit/5
        public ActionResult Edit(int? id)
        {

             PatientTbl patientTbl = db.PatientTbls.Find(id);
             ViewBag.docid = new SelectList(db.DoctorTbls, "Id", "firstname", patientTbl.docid);
             return View(patientTbl);

            //list
            //List <PatientTbl> patientTbl = db.PatientTbls.ToList();
            //return View(patientTbl);
        }

        // POST: PatientTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstname,lastname,docid,admission,discharge,isdischarge")] PatientTbl patientTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
          //  ViewBag.docid = new SelectList(db.DoctorTbls, "Id", "firstname", patientTbl.docid);
            return View(patientTbl);
        }

        // GET: PatientTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            if (patientTbl == null)
            {
                return HttpNotFound();
            }
            return View(patientTbl);
        }

        // POST: PatientTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            db.PatientTbls.Remove(patientTbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Index(string Searchby, string search)
        {
            if (Searchby == "FirstName")
            {
                return View(db.PatientTbls.Where(x => x.firstname.Contains(search)|| search == null).ToString());

            }
            else
            {
                return View(db.PatientTbls.Where(x => x.lastname.Contains(search) || search == null).ToString());

            }
        }
        /* public ActionResult Search(String input, String )
         {

             PatientTbl patientTbl = db.PatientTbls.Find(id);
             db.PatientTbls.Remove(patientTbl);
             db.SaveChanges();
             return RedirectToAction("Index");
         }*/

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
