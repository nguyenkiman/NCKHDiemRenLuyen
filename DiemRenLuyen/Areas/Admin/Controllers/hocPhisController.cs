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
    public class hocPhisController : Controller
    {
        private Db db = new Db();

        // GET: Admin/hocPhis
        public ActionResult Index()
        {
            var hocPhis = db.hocPhi.Include(h => h.hocKi).Include(h => h.sinhVien);
            return View(hocPhis.ToList());
        }

        // GET: Admin/hocPhis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hocPhi hocPhi = db.hocPhi.Find(id);
            if (hocPhi == null)
            {
                return HttpNotFound();
            }
            return View(hocPhi);
        }

        // GET: Admin/hocPhis/Create
        public ActionResult Create()
        {
            ViewBag.maHocKi = new SelectList(db.hocKi, "maHocKi", "nguoiTao");
            ViewBag.maSinhVien = new SelectList(db.sinhVien, "maSinhVien", "matKhau");
            return View();
        }

        // POST: Admin/hocPhis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSinhVien,maHocKi,trangThai")] hocPhi hocPhi)
        {
            if (ModelState.IsValid)
            {
                db.hocPhi.Add(hocPhi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maHocKi = new SelectList(db.hocKi, "maHocKi", "nguoiTao", hocPhi.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhVien, "maSinhVien", "matKhau", hocPhi.maSinhVien);
            return View(hocPhi);
        }

        // GET: Admin/hocPhis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hocPhi hocPhi = db.hocPhi.Find(id);
            if (hocPhi == null)
            {
                return HttpNotFound();
            }
            ViewBag.maHocKi = new SelectList(db.hocKi, "maHocKi", "nguoiTao", hocPhi.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhVien, "maSinhVien", "matKhau", hocPhi.maSinhVien);
            return View(hocPhi);
        }

        // POST: Admin/hocPhis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSinhVien,maHocKi,trangThai")] hocPhi hocPhi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocPhi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maHocKi = new SelectList(db.hocKi, "maHocKi", "nguoiTao", hocPhi.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhVien, "maSinhVien", "matKhau", hocPhi.maSinhVien);
            return View(hocPhi);
        }

        // GET: Admin/hocPhis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hocPhi hocPhi = db.hocPhi.Find(id);
            if (hocPhi == null)
            {
                return HttpNotFound();
            }
            return View(hocPhi);
        }

        // POST: Admin/hocPhis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            hocPhi hocPhi = db.hocPhi.Find(id);
            db.hocPhi.Remove(hocPhi);
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
