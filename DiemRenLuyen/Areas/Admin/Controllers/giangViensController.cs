using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace DiemRenLuyen.Areas.Admin.Controllers
{
    public class giangViensController : Controller
    {
        private Db db = new Db();

        // GET: Admin/giangViens
        public ActionResult Index()
        {
            return View(db.giangVien.ToList());
        }

        // GET: Admin/giangViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giangVien giangVien = db.giangVien.Find(id);
            if (giangVien == null)
            {
                return HttpNotFound();
            }
            return View(giangVien);
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
                db.giangVien.Add(giangVien);
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
            giangVien giangVien = db.giangVien.Find(id);
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
            giangVien giangVien = db.giangVien.Find(id);
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
            giangVien giangVien = db.giangVien.Find(id);
            db.giangVien.Remove(giangVien);
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
