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
using Models.DAO;
using Models.EF;
using PagedList;

namespace DiemRenLuyen.Areas.Admin.Controllers
{
    public class hocPhisController : Controller
    {
        private Db db = new Db();

        // GET: Admin/hocPhis
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var hocPhis = db.hocPhis.Include(h => h.hocKi).Include(h => h.sinhVien);
            ViewBag.maLop = new SelectList(db.lops, "maLop", "maLop");
            ViewBag.maNganh = new SelectList(db.nganhs, "maNganh", "tenNganh");
            ViewBag.maKhoa = new SelectList(db.khoas, "maKhoa", "tenKhoa");

            var model = db.hocPhis.ToList();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            ViewBag.maLop = new SelectList(db.lops, "maLop", "maLop");
            ViewBag.maNganh = new SelectList(db.nganhs, "maNganh", "tenNganh");
            ViewBag.maKhoa = new SelectList(db.khoas, "maKhoa", "tenKhoa");
            var sv = new hocPhiDAO();
            var model = sv.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        // GET: Admin/hocPhis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hocPhi hocPhi = db.hocPhis.Find(id);
            if (hocPhi == null)
            {
                return HttpNotFound();
            }
            return View(hocPhi);
        }

        // GET: Admin/hocPhis/Create
        public ActionResult Create()
        {
            ViewBag.maHocKi = new SelectList(db.hocKis, "maHocKi", "nguoiTao");
            ViewBag.maSinhVien = new SelectList(db.sinhViens, "maSinhVien", "matKhau");
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
                db.hocPhis.Add(hocPhi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maHocKi = new SelectList(db.hocKis, "maHocKi", "nguoiTao", hocPhi.maHocKi);
            ViewBag.maSinhVien = new SelectList(db.sinhViens, "maSinhVien", "matKhau", hocPhi.maSinhVien);
            return View(hocPhi);
        }

        // GET: Admin/hocPhis/Edit/5
        [HttpGet]
        public ActionResult Edit(string id, String id1)
        {
            hocPhi hocPhi = db.hocPhis.Find(id,id1);
            if(hocPhi.trangThai== 0)
            {
                hocPhi.trangThai = 1;
            }
            else
            {
                hocPhi.trangThai = 0;
            }
            
            db.Entry(hocPhi).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Admin/hocPhis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hocPhi hocPhi = db.hocPhis.Find(id);
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
            hocPhi hocPhi = db.hocPhis.Find(id);
            db.hocPhis.Remove(hocPhi);
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
        public ActionResult CreateExel(hocPhi users, HttpPostedFileBase FileUpload)
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
                    var artistAlbums = from a in excelFile.Worksheet<hocPhi>(sheetName) select a;
                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                            if (a.maSinhVien != "" && a.maHocKi != "" && a.trangThai == 1 || a.trangThai == 0)
                            {
                                hocPhi TU = new hocPhi();
                                TU.maSinhVien = a.maSinhVien;
                                TU.maHocKi = a.maHocKi;
                                TU.trangThai = a.trangThai;
                                db.hocPhis.Add(TU);
                                db.SaveChanges();
                            }
                            else
                            {
                                data.Add("<ul>");
                                if (a.maSinhVien == "" || a.maSinhVien == null) data.Add("<li> Ma Sinh Vien is required</li>");
                                if (a.maHocKi == "" || a.maHocKi == null) data.Add("<li> Mat Khau is required</li>");
                               
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
