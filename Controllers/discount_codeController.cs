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
    public class discount_codeController : Controller
    {
        private test1Entities db = new test1Entities();

        // GET: discount_code
        public ActionResult Index()
        {
            return View(db.discount_code.ToList());
        }

        // GET: discount_code/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discount_code discount_code = db.discount_code.Find(id);
            if (discount_code == null)
            {
                return HttpNotFound();
            }
            return View(discount_code);
        }

        // GET: discount_code/Create
        public ActionResult _Create()
        {
            return View();
        }

        // POST: discount_code/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Create([Bind(Include = "id,c_time,c_id,u_time,u_id,name,amount,deduction,start_time,end_time,level,remark")] discount_code discount_code)
        {
            if (ModelState.IsValid)
            {
                db.discount_code.Add(discount_code);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discount_code);
        }

        // GET: discount_code/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discount_code discount_code = db.discount_code.Find(id);
            if (discount_code == null)
            {
                return HttpNotFound();
            }
            return View(discount_code);
        }

        // POST: discount_code/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,c_time,c_id,u_time,u_id,name,amount,deduction,start_time,end_time,level,remark")] discount_code discount_code)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discount_code).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discount_code);
        }

        // GET: discount_code/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discount_code discount_code = db.discount_code.Find(id);
            if (discount_code == null)
            {
                return HttpNotFound();
            }
            return View(discount_code);
        }

        // POST: discount_code/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            discount_code discount_code = db.discount_code.Find(id);
            db.discount_code.Remove(discount_code);
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
