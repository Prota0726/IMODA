using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMODA.Models;

namespace IMODA.Controllers
{
    public class gradeController : Controller
    {
        private test1Entities db = new test1Entities();

        // GET: grade
        public ActionResult Index()
        {
            return View(db.member_level.ToList());
        }

        // GET: grade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member_level member_level = db.member_level.Find(id);
            if (member_level == null)
            {
                return HttpNotFound();
            }
            return View(member_level);
        }

        // GET: grade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: grade/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,u_id,u_time,switch,name_,sum_,discount,icoin,end_day,shopping_gold,remark")] member_level member_level)
        {
            if (ModelState.IsValid)
            {
                db.member_level.Add(member_level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member_level);
        }

        // GET: grade/Edit/5
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member_level member_level = db.member_level.Find(id);
            if (member_level == null)
            {
                return HttpNotFound();
            }
            return View(member_level);
        }

        // POST: grade/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "id,u_id,u_time,switch,name_,sum_,discount,icoin,end_day,shopping_gold,remark")] member_level member_level)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member_level).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member_level);
        }

        // GET: grade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member_level member_level = db.member_level.Find(id);
            if (member_level == null)
            {
                return HttpNotFound();
            }
            return View(member_level);
        }

        // POST: grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            member_level member_level = db.member_level.Find(id);
            db.member_level.Remove(member_level);
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


        public ActionResult Discount()
        {
            
            onsale onsale = db.onsale.Find(1);
            if (onsale == null)
            {
                return HttpNotFound();
            }
            return View(onsale);
        }

        // POST: grade/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Discount([Bind(Include = "id,u_id,u_time,discount")] onsale onsale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onsale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(onsale);
        }
    }
}
