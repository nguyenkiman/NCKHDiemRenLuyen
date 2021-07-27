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
using PagedList;

namespace DiemRenLuyen.Areas.Admin.Controllers
{
    public class lopsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/lops
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {

            var session = (DiemRenLuyen.Areas.Admin.Model.LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            var lops = new lopsDAO();
            var model = lops.ListWhereAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);

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

            ViewBag.maNganh = new SelectList(db.nganhs, "maNganh", "tenNganh", lop.maNganh);

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

        [HttpDelete]
        public ActionResult Delete(string id)
        {

            lop lop = db.lops.Find(id);
            lop.trangThai = 0 ;
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
