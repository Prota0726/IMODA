using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMODA.Models;
using IMODA.ViewModels;

namespace IMODA.Controllers
{
    public class mangerController : Controller
    {
        private test1Entities db = new test1Entities();

        // GET: manger
        public ActionResult Index()
        {
            return View(db.manger.ToList());
        }

        // GET: manger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manger manger = db.manger.Find(id);
            if (manger == null)
            {
                return HttpNotFound();
            }
            return View(manger);
        }

        // GET: manger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: manger/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,c_time,c_id,u_time,u_id,account,password,name,class,remark")] manger manger)
        {
            if (ModelState.IsValid)
            {
                db.manger.Add(manger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manger);
        }

        // GET: manger/Edit/5
        public ActionResult Mod(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            //var role = db.role.OrderBy(m => m.id).ToList();
            var role = db.role.Select(v => new SelectListItem { Value = v.id.ToString(), Text = v.name }).ToList();
            manger manger = db.manger.Find(id);
            if (manger == null)
            {
                return HttpNotFound();
            }
            MangerModViewModel viewModel = new MangerModViewModel();
            viewModel.RoleData = role;
            viewModel.MangerData = manger;
            return View(viewModel);
        }

        // POST: manger/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mod([Bind(Include = "ID,RoleData,MangerData")] MangerModViewModel viewModel)
       
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewModel.MangerData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: manger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manger manger = db.manger.Find(id);
            if (manger == null)
            {
                return HttpNotFound();
            }
            return View(manger);
        }

        // POST: manger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manger manger = db.manger.Find(id);
            db.manger.Remove(manger);
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

        [ChildActionOnly]
        public ActionResult _Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Create([Bind(Include = "id,c_time,c_id,u_time,u_id,account,password,name,class,remark")] manger manger)
        {
            if (ModelState.IsValid)
            {
                db.manger.Add(manger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(manger);
        }

    }
}
