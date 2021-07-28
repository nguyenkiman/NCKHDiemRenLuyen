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
    public class giangViensController : Controller
    {
        private Db db = new Db();

        // GET: Admin/giangViens
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            var hocKi = new giangVienDAO();
            var model = hocKi.ListWhereAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/giangViens/Details/5
        public ActionResult Details(string id)
        {
            using (Db db = new Db())
            {
                List<giaoVienChuNhiem> gvcn = db.giaoVienChuNhiems.ToList();
                List<giangVien> gv = db.giangViens.ToList();
                var main = from g1 in gv
                           join g2 in gvcn on g1.maGiangVien equals g2.maGiangVien
                           where (g2.maGiangVien == id)
                           select new ViewModel
                           {
                               giangVien = g1,
                               giaoVienChuNhiem = g2
                           };
                ViewBag.Main = main;
                return View();
            }
        }

        // GET: Admin/giangViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/giangViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maGiangVien,matKhau,tenGiangVien,ngaySinh,soDienThoai,gmail,gioiTinh,trangThai")] giangVien giangVien)
        {
            if (ModelState.IsValid)
            {
                db.giangViens.Add(giangVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giangVien);
        }

        // GET: Admin/giangViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giangVien giangVien = db.giangViens.Find(id);
            if (giangVien == null)
            {
                return HttpNotFound();
            }
            return View(giangVien);
        }

        // POST: Admin/giangViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maGiangVien,matKhau,tenGiangVien,ngaySinh,soDienThoai,gmail,gioiTinh,trangThai")] giangVien giangVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giangVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giangVien);
        }

        // GET: Admin/giangViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giangVien giangVien = db.giangViens.Find(id);
            if (giangVien == null)
            {
                return HttpNotFound();
            }
            return View(giangVien);
        }

        // POST: Admin/giangViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            giangVien giangVien = db.giangViens.Find(id);
            db.giangViens.Remove(giangVien);
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
