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
    public class sizemeasureController : Controller
    {
        private test1Entities db = new test1Entities();

        // GET: sizemeasure
        public ActionResult Index()
        {
            sizemeasure sizemeasure = db.sizemeasure.Find(1);
            if (sizemeasure == null)
            {
                return HttpNotFound();
            }
            return View(sizemeasure);

            //return View(db.sizemeasure.ToList());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index([Bind(Include = "id,en_field1,en_field2,en_field3,en_field4,en_field5,en_field6,en_field7,en_field8,th_field1,th_field2,th_field3,th_field4,th_field5,th_field6,th_field7,th_field8")] sizemeasure sizemeasure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sizemeasure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sizemeasure);
            //return RedirectToAction("Index");
        }

        // GET: sizemeasure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sizemeasure sizemeasure = db.sizemeasure.Find(id);
            if (sizemeasure == null)
            {
                return HttpNotFound();
            }
            return View(sizemeasure);
        }

        // GET: sizemeasure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sizemeasure/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,en_field1,en_field2,en_field3,en_field4,en_field5,en_field6,en_field7,en_field8,th_field1,th_field2,th_field3,th_field4,th_field5,th_field6,th_field7,th_field8")] sizemeasure sizemeasure)
        {
            if (ModelState.IsValid)
            {
                db.sizemeasure.Add(sizemeasure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sizemeasure);
        }

        // GET: sizemeasure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sizemeasure sizemeasure = db.sizemeasure.Find(id);
            if (sizemeasure == null)
            {
                return HttpNotFound();
            }
            return View(sizemeasure);
        }

        // POST: sizemeasure/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,en_field1,en_field2,en_field3,en_field4,en_field5,en_field6,en_field7,en_field8,th_field1,th_field2,th_field3,th_field4,th_field5,th_field6,th_field7,th_field8")] sizemeasure sizemeasure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sizemeasure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sizemeasure);
        }

        // GET: sizemeasure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sizemeasure sizemeasure = db.sizemeasure.Find(id);
            if (sizemeasure == null)
            {
                return HttpNotFound();
            }
            return View(sizemeasure);
        }

        // POST: sizemeasure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sizemeasure sizemeasure = db.sizemeasure.Find(id);
            db.sizemeasure.Remove(sizemeasure);
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
