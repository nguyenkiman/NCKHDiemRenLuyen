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
    public class diemHocTapsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/diemHocTaps
        public ActionResult Index()
        {
            var diemHocTaps = db.diemHocTap.Include(d => d.hocKi).Include(d => d.sinhVien);
            return View(diemHocTaps.ToList());
        }

        // GET: Admin/diemHocTaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diemHocTap diemHocTap = db.diemHocTap.Find(id);
            if (diemHocTap == null)
            {
                return HttpNotFound();
            }
            return View(diemHocTap);
        }

        // GET: Admin/diemHocTaps/Create
        public ActionResult Create()
        {
            ViewBag.maHocKi = new SelectList(db.hocKi, "maHocKi", "nguoiTao");
            ViewBag.maSinhVien = new SelectList(db.sinhVien, "maSinhVien", "matKhau");
            return View();
        }

        // POST: Admin/diemHocTaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSinhVien,maHocKi,diemTrungBinh")] diemHocTap diemHocTap)
        {
            if (ModelState.IsValid)
            {
                db.diemHocTap.Add(diemHocTap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maHocKi = new SelectList(db.hocKi, "maHocKi", "nguoiTao", diemHocTap.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhVien, "maSinhVien", "matKhau", diemHocTap.maSinhVien);
            return View(diemHocTap);
        }

        // GET: Admin/diemHocTaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diemHocTap diemHocTap = db.diemHocTap.Find(id);
            if (diemHocTap == null)
            {
                return HttpNotFound();
            }
            ViewBag.maHocKi = new SelectList(db.hocKi, "maHocKi", "nguoiTao", diemHocTap.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhVien, "maSinhVien", "matKhau", diemHocTap.maSinhVien);
            return View(diemHocTap);
        }

        // POST: Admin/diemHocTaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSinhVien,maHocKi,diemTrungBinh")] diemHocTap diemHocTap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diemHocTap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maHocKi = new SelectList(db.hocKi, "maHocKi", "nguoiTao", diemHocTap.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhVien, "maSinhVien", "matKhau", diemHocTap.maSinhVien);
            return View(diemHocTap);
        }

        // GET: Admin/diemHocTaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diemHocTap diemHocTap = db.diemHocTap.Find(id);
            if (diemHocTap == null)
            {
                return HttpNotFound();
            }
            return View(diemHocTap);
        }

        // POST: Admin/diemHocTaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            diemHocTap diemHocTap = db.diemHocTap.Find(id);
            db.diemHocTap.Remove(diemHocTap);
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
