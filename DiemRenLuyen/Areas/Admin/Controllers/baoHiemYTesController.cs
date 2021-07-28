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

        public ActionResult CreateExel()
        {
            var session = (Model.LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateExel(baoHiemYTe users, HttpPostedFileBase FileUpload)
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
                    var artistAlbums = from a in excelFile.Worksheet<baoHiemYTe>(sheetName) select a;
                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                            if (a.maSinhVien != "" && a.maHocKi != "" && a.trangThai == 0 || a.trangThai ==1)
                            {
                                try
                                {
                                    baoHiemYTe TU = new baoHiemYTe();
                                    TU.maSinhVien = a.maSinhVien;
                                    TU.maHocKi = a.maHocKi;
                                    TU.trangThai = a.trangThai;
                                    db.baoHiemYTes.Add(TU);
                                    db.SaveChanges();
                                }
                                catch
                                {
                                    return RedirectToAction("CreateExel", "baoHiemYTes");
                                }
                                
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
