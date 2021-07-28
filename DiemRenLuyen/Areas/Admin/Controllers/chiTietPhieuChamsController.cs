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
    public class chiTietPhieuChamsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/chiTietPhieuChams
        public ActionResult Index()

        {
            var session = (DiemRenLuyen.Areas.Admin.Model.LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            var chiTietPhieuChams = db.chiTietPhieuChams.Include(c => c.noiDungDanhGia).Include(c => c.phieuChamDiem);
            return View(chiTietPhieuChams.ToList());
        }

        // GET: Admin/chiTietPhieuChams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chiTietPhieuCham chiTietPhieuCham = db.chiTietPhieuChams.Find(id);
            if (chiTietPhieuCham == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuCham);
        }

        // GET: Admin/chiTietPhieuChams/Create
        public ActionResult Create()
        {
            ViewBag.maNoiDung = new SelectList(db.noiDungDanhGias, "maNoiDung", "tenNoiDung");
            ViewBag.maPhieuChamDiem = new SelectList(db.phieuChamDiems, "maPhieuChamDiem", "maSinhVien");
            return View();
        }

        // POST: Admin/chiTietPhieuChams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPhieuChamDiem,maNoiDung,diemTuCham,diemCBLCham,diemGVCNCham,minhChung")] chiTietPhieuCham chiTietPhieuCham)
        {
            if (ModelState.IsValid)
            {
                db.chiTietPhieuChams.Add(chiTietPhieuCham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maNoiDung = new SelectList(db.noiDungDanhGias, "maNoiDung", "tenNoiDung", chiTietPhieuCham.maNoiDung);
            ViewBag.maPhieuChamDiem = new SelectList(db.phieuChamDiems, "maPhieuChamDiem", "maSinhVien", chiTietPhieuCham.maPhieuChamDiem);
            return View(chiTietPhieuCham);
        }

        // GET: Admin/chiTietPhieuChams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chiTietPhieuCham chiTietPhieuCham = db.chiTietPhieuChams.Find(id);
            if (chiTietPhieuCham == null)
            {
                return HttpNotFound();
            }
            ViewBag.maNoiDung = new SelectList(db.noiDungDanhGias, "maNoiDung", "tenNoiDung", chiTietPhieuCham.maNoiDung);
            ViewBag.maPhieuChamDiem = new SelectList(db.phieuChamDiems, "maPhieuChamDiem", "maSinhVien", chiTietPhieuCham.maPhieuChamDiem);
            return View(chiTietPhieuCham);
        }

        // POST: Admin/chiTietPhieuChams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPhieuChamDiem,maNoiDung,diemTuCham,diemCBLCham,diemGVCNCham,minhChung")] chiTietPhieuCham chiTietPhieuCham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuCham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maNoiDung = new SelectList(db.noiDungDanhGias, "maNoiDung", "tenNoiDung", chiTietPhieuCham.maNoiDung);
            ViewBag.maPhieuChamDiem = new SelectList(db.phieuChamDiems, "maPhieuChamDiem", "maSinhVien", chiTietPhieuCham.maPhieuChamDiem);
            return View(chiTietPhieuCham);
        }

        // GET: Admin/chiTietPhieuChams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chiTietPhieuCham chiTietPhieuCham = db.chiTietPhieuChams.Find(id);
            if (chiTietPhieuCham == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuCham);
        }

        // POST: Admin/chiTietPhieuChams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chiTietPhieuCham chiTietPhieuCham = db.chiTietPhieuChams.Find(id);
            db.chiTietPhieuChams.Remove(chiTietPhieuCham);
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
