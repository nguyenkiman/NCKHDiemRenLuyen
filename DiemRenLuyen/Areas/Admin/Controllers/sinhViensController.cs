using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinqToExcel;
using Models.EF;
using ExcelLibrary;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

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
            ViewBag.maLop = new SelectList(db.lop, "maLop", "maLop");

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
        [HttpGet]
        public ActionResult Delete(string id)
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

        [HttpPost]
        public ActionResult CreateExel(sinhVien users, HttpPostedFileBase FileUpload)
        {

            List<string> data = new List<string>();
            if (FileUpload != null)
            {
                // tdata.ExecuteCommand("truncate table OtherCompanyAssets");
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = FileUpload.FileName;
                    string targetpath = Server.MapPath("~/Content/Doc/");
                    FileUpload.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    var connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }

                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    var ds = new DataSet();
                    adapter.Fill(ds, "ExcelTable");
                    DataTable dtable = ds.Tables["ExcelTable"];
                    string sheetName = "Sheet1";
                    var excelFile = new ExcelQueryFactory(pathToExcelFile);
                    var artistAlbums = from a in excelFile.Worksheet<sinhVien>(sheetName) select a;
                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                            if (a.maSinhVien != "" && a.matKhau != "" && a.tenSinhVien != "" && a.soDienThoai != "" && a.gmail != "" && a.gioiTinh != null && a.trangThai != null && a.maLop != "")
                            {
                                sinhVien TU = new sinhVien();
                                TU.maSinhVien = a.maSinhVien;
                                TU.matKhau = a.matKhau;
                                TU.tenSinhVien = a.tenSinhVien;
                                TU.ngaySinh = a.ngaySinh;
                                TU.soDienThoai = a.soDienThoai;
                                TU.gmail = a.gmail;
                                TU.gioiTinh = a.gioiTinh;
                                TU.trangThai = a.trangThai;
                                TU.maLop = a.maLop;
                                db.sinhVien.Add(TU);
                                db.SaveChanges();
                            }
                            else
                            {
                                data.Add("<ul>");
                                if (a.maSinhVien == "" || a.maSinhVien == null) data.Add("<li> Ma Sinh Vien is required</li>");
                                if (a.matKhau == "" || a.matKhau == null) data.Add("<li> Mat Khau is required</li>");
                                if (a.tenSinhVien == "" || a.tenSinhVien == null) data.Add("<li>Ten Sinh Vien is required</li>");
                                data.Add("</ul>");
                                data.ToArray();
                                return Json(data, JsonRequestBehavior.AllowGet);
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {
                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                                }
                            }
                        }
                    }
                    //deleting excel file from folder
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    //alert message for invalid file format
                    data.Add("<ul>");
                    data.Add("<li>Only Excel file format is allowed</li>");
                    data.Add("</ul>");
                    data.ToArray();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                data.Add("<ul>");
                if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
                data.Add("</ul>");
                data.ToArray();
                return RedirectToAction("CreateExel");
            }
        }
    }
}

