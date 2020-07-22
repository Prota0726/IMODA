using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMODA.Models;

namespace IMODA.Controllers
{
    public class HomeController : Controller
    {
        private test1Entities db = new test1Entities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection post)
        {
            var admin = (from a in db.manger
                         where a.account == "admin"
                         select a).SingleOrDefault();
            string account = post["account"];
            string password = post["password"];
            if (account == "admin" && admin.password == password)
            {
                Session["account"] = account;
                return RedirectToAction("Index");
            }
            else
                TempData["message"] = "帳號或密碼輸入錯誤";
            return View();
        }
        public ActionResult Mod_Password()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Mod_Password(FormCollection post)
        {
            string old_password = post["old_password"];
            string password = post["password"];
            string new_password = post["new_password"];

            var admin = (from a in db.manger
                         where a.account == "admin"
                         select a).SingleOrDefault(); ;



            if (admin.password == old_password && password == new_password)
            {
                admin.password = new_password;
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
                TempData["message"] = "輸入錯誤";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToActionPermanent("Login");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}