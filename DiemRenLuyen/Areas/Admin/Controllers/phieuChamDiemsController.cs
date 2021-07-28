using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace DiemRenLuyen.Areas.Admin.Controllers
{
    public class phieuChamDiemsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/phieuChamDiems
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var session = (DiemRenLuyen.Areas.Admin.Model.LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            var phieu = new phieuChamDiemsDAO();
            var model = phieu.ListWhereAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/phieuChamDiems/Details/5
        public ActionResult Details(int? id)
        {
            var chiTietPhieuChams = db.chiTietPhieuChams.Include(c => c.noiDungDanhGia).Include(c => c.phieuChamDiem);
            return View(chiTietPhieuChams.ToList());
        }

        // GET: Admin/phieuChamDiems/Create
        public ActionResult Create()
        {
            ViewBag.maHocKi = new SelectList(db.hocKis, "maHocKi", "nguoiTao");
            ViewBag.maSinhVien = new SelectList(db.sinhViens, "maSinhVien", "matKhau");
            return View();
        }

        // POST: Admin/phieuChamDiems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPhieuChamDiem,maSinhVien,maHocKi,ngayCham,trangThai,tongDiem")] phieuChamDiem phieuChamDiem)
        {
            if (ModelState.IsValid)
            {
                db.phieuChamDiems.Add(phieuChamDiem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maHocKi = new SelectList(db.hocKis, "maHocKi", "nguoiTao", phieuChamDiem.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhViens, "maSinhVien", "matKhau", phieuChamDiem.maSinhVien);
            return View(phieuChamDiem);
        }

        // GET: Admin/phieuChamDiems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieuChamDiem phieuChamDiem = db.phieuChamDiems.Find(id);
            if (phieuChamDiem == null)
            {
                return HttpNotFound();
            }
            ViewBag.maHocKi = new SelectList(db.hocKis, "maHocKi", "nguoiTao", phieuChamDiem.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhViens, "maSinhVien", "matKhau", phieuChamDiem.maSinhVien);
            return View(phieuChamDiem);
        }

        // POST: Admin/phieuChamDiems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPhieuChamDiem,maSinhVien,maHocKi,ngayCham,trangThai,tongDiem")] phieuChamDiem phieuChamDiem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuChamDiem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maHocKi = new SelectList(db.hocKis, "maHocKi", "nguoiTao", phieuChamDiem.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhViens, "maSinhVien", "matKhau", phieuChamDiem.maSinhVien);
            return View(phieuChamDiem);
        }

        // GET: Admin/phieuChamDiems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieuChamDiem phieuChamDiem = db.phieuChamDiems.Find(id);
            if (phieuChamDiem == null)
            {
                return HttpNotFound();
            }
            return View(phieuChamDiem);
        }

        // POST: Admin/phieuChamDiems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            phieuChamDiem phieuChamDiem = db.phieuChamDiems.Find(id);
            db.phieuChamDiems.Remove(phieuChamDiem);
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
