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
    public class UserTblsController : Controller
    {
        private HospitalRecordsDBContext db = new HospitalRecordsDBContext();

        // GET: UserTbls
        public ActionResult Index()
        {
            return View(db.UserTbls.ToList());
        }

        // GET: UserTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTbl userTbl = db.UserTbls.Find(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            return View(userTbl);
        }

        // GET: UserTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,username_,password,admin")] UserTbl userTbl)
        {
            if (ModelState.IsValid)
            {
                db.UserTbls.Add(userTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTbl);
        }

        // GET: UserTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTbl userTbl = db.UserTbls.Find(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            return View(userTbl);
        }

        // POST: UserTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,username_,password,admin")] UserTbl userTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTbl);
        }

        // GET: UserTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTbl userTbl = db.UserTbls.Find(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            return View(userTbl);
        }

        // POST: UserTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTbl userTbl = db.UserTbls.Find(id);
            db.UserTbls.Remove(userTbl);
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
