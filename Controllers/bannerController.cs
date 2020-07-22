using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMODA.Models;

namespace IMODA.Controllers
{
    public class bannerController : Controller
    {
        private test1Entities db = new test1Entities();

        // GET: banner
        public ActionResult Index()
        {
            return View(db.banner.ToList());
        }

        // GET: banner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banner banner = db.banner.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // GET: banner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: banner/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,c_time,c_id,u_time,u_id,switch,sort,top_,banner1,center,under,img,url,action,remark")] banner banner)
        {
            if (ModelState.IsValid)
            {
                db.banner.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banner);
        }

        // GET: banner/Edit/5
        public ActionResult Mod(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banner banner = db.banner.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: banner/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mod([Bind(Include = "id,c_time,c_id,u_time,u_id,switch,sort,top_,banner1,center,under,img,url,action,remark")] banner banner, HttpPostedFileBase file)
        {            
            if (ModelState.IsValid && file != null)
            {
                if (file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/image/banner/"), file.FileName);
                    file.SaveAs(path);
                }
                banner.img = file.FileName;
                
                db.Entry(banner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banner);
        }

        // GET: banner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banner banner = db.banner.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: banner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            banner banner = db.banner.Find(id);
            db.banner.Remove(banner);
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
        public ActionResult _Create([Bind(Include = "id,c_time,c_id,u_time,u_id,banner_switch,sort,banner_top,banner,center,under,img,url,action,remark")] banner banner , HttpPostedFileBase file)
        {
            
            
            if (ModelState.IsValid  && file != null)
            {
                if(file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/image/banner/"), file.FileName);
                    file.SaveAs(path);
                }
                banner.img = file.FileName;
                db.banner.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(banner);
        }
    }
}
