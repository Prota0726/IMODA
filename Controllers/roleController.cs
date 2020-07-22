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
    public class roleController : Controller
    {
        private test1Entities db = new test1Entities();

        // GET: roles
        public ActionResult Index()
        {
            return View(db.role.ToList());
        }

        // GET: roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            role role = db.role.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: roles/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,c_time,c_id,u_time,u_id,name,role_class,remark")] role role)
        {
            if (ModelState.IsValid)
            {
                db.role.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }
        [ChildActionOnly]
        public ActionResult _Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Create([Bind(Include = "id,c_time,c_id,u_time,u_id,name,role_class,remark")] role role)
        {
            if (ModelState.IsValid)
            {
                db.role.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(role);
        }



        // GET: roles/Edit/5
        public ActionResult Mod(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            role role = db.role.Find(id);
            var permission = db.permission.OrderBy(m => m.id).ToList();
            if (role == null)
            {
                return HttpNotFound();
            }

            RoleModViewModel viewModel = new RoleModViewModel();
            viewModel.roledata = role;
            viewModel.PermissionsCollection = permission;


            return View(viewModel);
        }

        // POST: roles/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mod([Bind(Include = "ID,roledata,PermissionsCollection")] RoleModViewModel roleModViewModelole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleModViewModelole.roledata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleModViewModelole);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var role = this.db.role.Find(int.Parse(id));
                this.db.role.Remove(role);
                this.db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            role manger = db.role.Find(id);
            if (manger == null)
            {
                return HttpNotFound();
            }
            return View(manger);
        }

        // POST: manger/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,c_time,c_id,u_time,u_id,name,role_class,remark")] role role)

        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
