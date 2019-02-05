using Assignment3_MVC_HospitalRecords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3_MVC_HospitalRecords.Controllers
{
    public class HomeController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserTbl user)
        {
            if (ModelState.IsValid)
            {
                using (HospitalRecordsDBContext db = new HospitalRecordsDBContext())
                {
                    var obj = db.UserTbls.Where(a => a.username_.Equals(user.username_) && a.password.Equals(user.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        if (Convert.ToBoolean(obj.admin))
                        {
                            Session["IsAdmin"] = obj.admin.ToString();
                            return RedirectToAction("Admin");
                        }
                        else
                        {
                            Session["IsAdmin"] = obj.admin.ToString();
                            return RedirectToAction("Users");
                        }
                    }
                }
            }
            return View(user);
        }

        public ActionResult Admin()
        {
            if (Session["IsAdmin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Users()
        {
            if (Session["IsAdmin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}