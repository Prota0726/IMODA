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
    public class question_setController : Controller
    {
        private test1Entities db = new test1Entities();

        // GET: question_set
        public ActionResult Index()
        {
            return View(db.question_set.ToList());
        }
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var question_set = this.db.question_set.Find(int.Parse(id));
                this.db.question_set.Remove(question_set);
                this.db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: question_set/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question_set question_set = db.question_set.Find(id);
            if (question_set == null)
            {
                return HttpNotFound();
            }
            return View(question_set);
        }

        // GET: question_set/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: question_set/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,extends,en_title,en_content,th_title,th_content")] question_set question_set)
        {
            if (ModelState.IsValid)
            {
                db.question_set.Add(question_set);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(question_set);
        }

        // GET: question_set/Edit/5
        public ActionResult Mod(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question_set question_set = db.question_set.Find(id);
            if (question_set == null)
            {
                return HttpNotFound();
            }
            return View(question_set);
        }

        // POST: question_set/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mod([Bind(Include = "id,extends,en_title,en_content,th_title,th_content")] question_set question_set)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question_set).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question_set);
        }

        // GET: question_set/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question_set question_set = db.question_set.Find(id);
            if (question_set == null)
            {
                return HttpNotFound();
            }
            return View(question_set);
        }

        // POST: question_set/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            question_set question_set = db.question_set.Find(id);
            db.question_set.Remove(question_set);
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
