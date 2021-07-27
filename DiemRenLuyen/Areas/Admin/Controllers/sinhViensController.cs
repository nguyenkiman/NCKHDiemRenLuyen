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
    public class sinhViensController : Controller
    {
        private Db db = new Db();

        // GET: Admin/sinhViens
        public ActionResult Index()
        {
            var sinhViens = db.sinhVien.Include(s => s.lop);
            return View(sinhViens.ToList());
        }

        // GET: Admin/sinhViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinhVien sinhVien = db.sinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: Admin/sinhViens/Create
        public ActionResult Create()
        {
            ViewBag.maLop = new SelectList(db.lop, "maLop", "maNganh");
            
            return View();
        }

        // POST: Admin/sinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSinhVien,matKhau,tenSinhVien,ngaySinh,soDienThoai,gmail,gioiTinh,trangThai,maLop")] sinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.sinhVien.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maLop = new SelectList(db.lop, "maLop", "maNganh", sinhVien.maLop);
            return View(sinhVien);
        }

        // GET: Admin/sinhViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinhVien sinhVien = db.sinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.maLop = new SelectList(db.lop, "maLop", "maNganh", sinhVien.maLop);
            return View(sinhVien);
        }

        // POST: Admin/sinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSinhVien,matKhau,tenSinhVien,ngaySinh,soDienThoai,gmail,gioiTinh,trangThai,maLop")] sinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maLop = new SelectList(db.lop, "maLop", "maNganh", sinhVien.maLop);
            return View(sinhVien);
        }

        // GET: Admin/sinhViens/Delete/5
        public ActionResult Delete(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinhVien sinhVien = db.sinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: Admin/sinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            
            sinhVien sinhVien = db.sinhVien.Find(id);
            sinhVien.trangThai = 0;
            db.Entry(sinhVien).State = EntityState.Modified;
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

        public ActionResult CreateExel()
        {
          
            return View();
        }
    }
}
