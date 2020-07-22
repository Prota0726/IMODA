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
    public class question_categoryController : Controller
    {
        private test1Entities db = new test1Entities();

        // GET: question_category
        public ActionResult Index()
        {
            return View(db.question_category.ToList());
        }
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var question_category = this.db.question_category.Find(int.Parse(id));
                this.db.question_category.Remove(question_category);
                this.db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: question_category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question_category question_category = db.question_category.Find(id);
            if (question_category == null)
            {
                return HttpNotFound();
            }
            return View(question_category);
        }

        // GET: question_category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: question_category/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,active,en_title,en_content,th_title,th_content")] question_category question_category)
        {
            if (ModelState.IsValid)
            {
                db.question_category.Add(question_category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(question_category);
        }

        // GET: question_category/Edit/5
        public ActionResult Mod(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question_category question_category = db.question_category.Find(id);
            if (question_category == null)
            {
                return HttpNotFound();
            }
            return View(question_category);
        }

        // POST: question_category/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mod([Bind(Include = "id,active,en_title,en_content,th_title,th_content")] question_category question_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question_category);
        }

        // GET: question_category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question_category question_category = db.question_category.Find(id);
            if (question_category == null)
            {
                return HttpNotFound();
            }
            return View(question_category);
        }

        // POST: question_category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            question_category question_category = db.question_category.Find(id);
            db.question_category.Remove(question_category);
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
