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
            lop lop = db.lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // GET: Admin/lops/Create
        public ActionResult Create()
        {
            var session = (Model.LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            ViewBag.maNganh = new SelectList(db.nganhs, "maNganh", "tenNganh");
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
                db.lops.Add(lop);
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
            lop lop = db.lops.Find(id);
            // cái ni có mã lớp dúng haandeens service tạo hàm 1 tìm lớp 
            // 2 viết hàm tìm cán bộ lớp và giáo viên chủ nhiệm hiện tại (status =1 lớp = mã lớp) 
            // 3 lấy được thì sửa được thôi mà em,
            // còn view thì em làm 2 cái selectlist  là select list sinh vien của lớp(cái ni hình như thầy làm r mà bỏ thêm pagelist r e coi viết lại)
            // list thứ 2 là giảng viên, ời all giảng viên chứ k làm gv theo khoa ngành được
            // hiểu hân
            if (lop == null)
            {
                return HttpNotFound();
            }
            ViewBag.maNganh = new SelectList(db.nganhs, "maNganh", "tenNganh", lop.maNganh);
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
            ViewBag.maNganh = new SelectList(db.nganhs, "maNganh", "tenNganh", lop.maNganh);
            return View(lop);
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {

            lop lop = db.lops.Find(id);
            lop.trangThai = 0;
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