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
    public class baoHiemYTesController : Controller
    {
        private Db db = new Db();

        // GET: Admin/baoHiemYTes
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var session = (DiemRenLuyen.Areas.Admin.Model.LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            var bhyt = new baoHiemYTesDAO();
            var model = bhyt.ListWhereAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/baoHiemYTes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baoHiemYTe baoHiemYTe = db.baoHiemYTes.Find(id);
            if (baoHiemYTe == null)
            {
                return HttpNotFound();
            }
            return View(baoHiemYTe);
        }

        // GET: Admin/baoHiemYTes/Edit/5
        public ActionResult Edit(string maSinhVien, string maHocKi)
        {
            if (maSinhVien == null || maHocKi == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baoHiemYTe baoHiemYTe = db.baoHiemYTes.Find(maSinhVien,maHocKi);
            if (baoHiemYTe == null)
            {
                return HttpNotFound();
            }
            ViewBag.maHocKi = new SelectList(db.hocKis, "maHocKi", "nguoiTao", baoHiemYTe.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhViens, "maSinhVien", "matKhau", baoHiemYTe.maSinhVien);
            return View(baoHiemYTe);
        }

        // POST: Admin/baoHiemYTes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSinhVien,maHocKi,trangThai")] baoHiemYTe baoHiemYTe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baoHiemYTe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maHocKi = new SelectList(db.hocKis, "maHocKi", "nguoiTao", baoHiemYTe.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhViens, "maSinhVien", "matKhau", baoHiemYTe.maSinhVien);
            return View(baoHiemYTe);
        }

        // GET: Admin/baoHiemYTes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baoHiemYTe baoHiemYTe = db.baoHiemYTes.Find(id);
            if (baoHiemYTe == null)
            {
                return HttpNotFound();
            }
            return View(baoHiemYTe);
        }

        // POST: Admin/baoHiemYTes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            baoHiemYTe baoHiemYTe = db.baoHiemYTes.Find(id);
            db.baoHiemYTes.Remove(baoHiemYTe);
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
