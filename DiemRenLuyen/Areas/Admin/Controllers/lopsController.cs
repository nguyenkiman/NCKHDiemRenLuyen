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
    public class lopsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/lops
        public ActionResult Index()
        {
            var lops = db.lop.Include(l => l.nganh);
            return View(lops.ToList());
        }

        // GET: Admin/lops/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lop lop = db.lop.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // GET: Admin/lops/Create
        public ActionResult Create()
        {
            ViewBag.maNganh = new SelectList(db.nganh, "maNganh", "tenNganh");
            return View();
        }

        // POST: Admin/lops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maLop,maNganh,trangThai")] lop lop)
        {
            if (ModelState.IsValid)
            {
                db.lop.Add(lop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maNganh = new SelectList(db.nganh, "maNganh", "tenNganh", lop.maNganh);
            return View(lop);
        }

        // GET: Admin/lops/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lop lop = db.lop.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            ViewBag.maNganh = new SelectList(db.nganh, "maNganh", "tenNganh", lop.maNganh);
            return View(lop);
        }

        // POST: Admin/lops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maLop,maNganh,trangThai")] lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maNganh = new SelectList(db.nganh, "maNganh", "tenNganh", lop.maNganh);
            return View(lop);
        }

        // GET: Admin/lops/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lop lop = db.lop.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // POST: Admin/lops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            lop lop = db.lop.Find(id);
            db.lop.Remove(lop);
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
