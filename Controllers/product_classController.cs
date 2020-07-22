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
    public class product_classController : Controller
    {
        private test1Entities db = new test1Entities();

        // GET: product_class
        public ActionResult Index()
        {
            return View(db.product_class.ToList());
        }

        // GET: product_class/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_class product_class = db.product_class.Find(id);
            if (product_class == null)
            {
                return HttpNotFound();
            }
            return View(product_class);
        }

        // GET: product_class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: product_class/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,c_time,c_id,u_time,u_id,switch,sort,name,banner,banner_url,banner1,banner_url1,banner2,banner_url2,img,img_url,img1,img_url1,img2,img_url2,img3,img_url3,img4,img_url4,banner_action,img_action,index_,remark")] product_class product_class)
        {
            if (ModelState.IsValid)
            {
                db.product_class.Add(product_class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_class);
        }

        // GET: product_class/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_class product_class = db.product_class.Find(id);
            if (product_class == null)
            {
                return HttpNotFound();
            }
            return View(product_class);
        }

        // POST: product_class/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,c_time,c_id,u_time,u_id,switch,sort,name,banner,banner_url,banner1,banner_url1,banner2,banner_url2,img,img_url,img1,img_url1,img2,img_url2,img3,img_url3,img4,img_url4,banner_action,img_action,index_,remark")] product_class product_class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_class);
        }

        // GET: product_class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_class product_class = db.product_class.Find(id);
            if (product_class == null)
            {
                return HttpNotFound();
            }
            return View(product_class);
        }

        // POST: product_class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product_class product_class = db.product_class.Find(id);
            db.product_class.Remove(product_class);
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
