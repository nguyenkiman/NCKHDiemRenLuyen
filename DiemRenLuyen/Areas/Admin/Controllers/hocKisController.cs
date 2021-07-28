using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiemRenLuyen.Areas.Admin.Model;
using Models.DAO;
using Models.EF;

namespace DiemRenLuyen.Areas.Admin.Controllers
{
    public class hocKisController : Controller
    {
        private Db db = new Db();

        // GET: Admin/hocKis
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            var hocKi = new hocKisDAO();
            var model = hocKi.ListWhereAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);

        }

        // GET: Admin/hocKis/Create
        public ActionResult Create()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            ViewBag.nguoiTao = new SelectList(db.admins, "taiKhoan", "matKhau");
            return View();
        }

        // POST: Admin/hocKis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maHocKi,ngayBatDauCham,ngayKetThucCham,ngayTao,nguoiTao")] hocKi hocKi)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (ModelState.IsValid)
            {
                hocKi.ngayTao = DateTime.Now;
                hocKi.nguoiTao = session.UserName;
                db.hocKis.Add(hocKi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nguoiTao = new SelectList(db.admins, "taiKhoan", "matKhau", hocKi.nguoiTao);
            return View(hocKi);
        }

        // GET: Admin/hocKis/Edit/5
        public ActionResult Edit(string id)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hocKi hocKi = db.hocKis.Find(id);
            if (hocKi == null)
            {
                return HttpNotFound();
            }
            ViewBag.nguoiTao = new SelectList(db.admins, "taiKhoan", "hoTen", hocKi.nguoiTao);
            return View(hocKi);
        }

        // POST: Admin/hocKis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maHocKi,ngayBatDauCham,ngayKetThucCham,ngayTao,nguoiTao")] hocKi hocKi)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (ModelState.IsValid)
            {
                hocKi.nguoiTao = session.UserName;
                db.Entry(hocKi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nguoiTao = new SelectList(db.admins, "taiKhoan", "matKhau", hocKi.nguoiTao);
            return View(hocKi);
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
