using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using DiemRenLuyen.Model;
using Models.Services;
using System.IO;
using Models.ViewModel;
using System.Data.Entity;

namespace DiemRenLuyen.Controllers
{
    
    public class StudentsController : Controller
    {
        // GET: Students
        Db db = new Db();
        sinhVienServices sinhVienServices = new sinhVienServices();
        phieuChamDiemServices phieuChamDiemServices = new phieuChamDiemServices();

        public ActionResult Index()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var model = sinhVienServices.ListWhereAll(session.UserName);
            return View(model);
        }

        public ActionResult NotifyError()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MarkPoint()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            hocKi hocKi = new hocKiServices().getCurrentHocKi();
            if(hocKi is null)
            {
                return RedirectToAction("NotifyError", "Students");
            }
            else
            {
                phieuChamDiem phieuChamDiem = phieuChamDiemServices.findByMaSinhVienAndMaHocKy(session.UserName, hocKi.maHocKi);
                if (phieuChamDiem is null)
                {
                    phieuChamDiem = phieuChamDiemServices.generateNewPhieuChamDiem(session.UserName);
                    return View(phieuChamDiem);
                }
                else
                {
                    return View(phieuChamDiem);
                }


                //phieuChamDiem phieuChamDiem = phieuChamDiemServices.generateNewPhieuChamDiem(session.UserName);
                //return View(phieuChamDiem);
            }


        }



        [HttpPost]
        public ActionResult MarkPoint(int diemTuCham_1, int diemTuCham_2, int diemTuCham_3, int diemTuCham_4, int diemTuCham_5, int diemTuCham_6, int diemTuCham_7,
            int diemTuCham_8, int diemTuCham_9, int diemTuCham_10, int diemTuCham_11, int diemTuCham_12, int diemTuCham_13, int diemTuCham_14, int diemTuCham_15, int diemTuCham_16
            , int diemTuCham_17, int diemTuCham_18, int diemTuCham_19, int diemTuCham_20, int diemTuCham_21, int diemTuCham_22, int diemTuCham_23, HttpPostedFileBase minhchung13
            , HttpPostedFileBase minhchung18, HttpPostedFileBase minhchung21, HttpPostedFileBase minhchung22, HttpPostedFileBase minhchung23)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }

            hocKi hocKi = new hocKiServices().getCurrentHocKi();
            phieuChamDiem phieuChamDiem = phieuChamDiemServices.findByMaSinhVienAndMaHocKy(session.UserName, hocKi.maHocKi);
            phieuChamDiem newphieuChamDiem = new phieuChamDiem();
            newphieuChamDiem.maHocKi = new hocKiServices().getCurrentHocKi().maHocKi;
            newphieuChamDiem.maSinhVien = session.UserName;
            newphieuChamDiem.ngayCham = DateTime.Today;
            newphieuChamDiem.trangThai = 1;
            newphieuChamDiem.tongDiem = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9 + diemTuCham_10 + diemTuCham_11
                + diemTuCham_12 + diemTuCham_13 + diemTuCham_14 + diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19 + diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;

            if (phieuChamDiem is null)
            {
                
                db.phieuChamDiems.Add(newphieuChamDiem);
                db.SaveChanges();
            }
            else
            {
                newphieuChamDiem.maPhieuChamDiem = phieuChamDiemServices.findByMaSinhVienAndMaHocKy(session.UserName, hocKi.maHocKi).maPhieuChamDiem;
                db.Entry(newphieuChamDiem).State = EntityState.Modified;
                db.SaveChanges();
            }

            string minhchungpath13 = null;
            if (minhchung13 != null && minhchung13.ContentLength > 0)
            {
                string filename = Path.GetFileName(minhchung13.FileName);
                string path = Server.MapPath("~/images/" + filename);
                minhchungpath13 = "images/" + filename;
                minhchung13.SaveAs(path);
                
            }

            string minhchungpath18 = null;
            if (minhchung18 != null && minhchung18.ContentLength > 0)
            {
                string filename = Path.GetFileName(minhchung18.FileName);
                string path = Server.MapPath("~/images/" + filename);
                minhchungpath18 = "images/" + filename;
                minhchung18.SaveAs(path);

            }

            string minhchungpath21 = null;
            if (minhchung21 != null && minhchung21.ContentLength > 0)
            {
                string filename = Path.GetFileName(minhchung21.FileName);
                string path = Server.MapPath("~/images/" + filename);
                minhchungpath21 = "images/" + filename;
                minhchung21.SaveAs(path);

            }

            string minhchungpath22 = null;
            if (minhchung22 != null && minhchung22.ContentLength > 0)
            {
                string filename = Path.GetFileName(minhchung22.FileName);
                string path = Server.MapPath("~/images/" + filename);
                minhchungpath22 = "images/" + filename;
                minhchung22.SaveAs(path);

            }
            string minhchungpath23 = null;
            if (minhchung23 != null && minhchung23.ContentLength > 0)
            {
                string filename = Path.GetFileName(minhchung23.FileName);
                string path = Server.MapPath("~/images/" + filename);
                minhchungpath23 = "images/" + filename;
                minhchung23.SaveAs(path);

            }

            var maphieuchamdiem = phieuChamDiemServices.findByMaSinhVienAndMaHocKy(session.UserName, hocKi.maHocKi).maPhieuChamDiem;

            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 1, diemTuCham_1, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 2, diemTuCham_2, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 3, diemTuCham_3, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 4, diemTuCham_4, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 5, diemTuCham_5, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 6, diemTuCham_6, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 7, diemTuCham_7, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 8, diemTuCham_8, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 9, diemTuCham_9, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 10, diemTuCham_10, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 11, diemTuCham_11, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 12, diemTuCham_12, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 13, diemTuCham_13, 0, 0, minhchungpath13);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 14, diemTuCham_14, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 15, diemTuCham_15, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 16, diemTuCham_16, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 17, diemTuCham_17, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 18, diemTuCham_18, 0, 0, minhchungpath18);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 19, diemTuCham_19, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 20, diemTuCham_20, 0, 0, null);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 21, diemTuCham_21, 0, 0, minhchungpath21);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 22, diemTuCham_22, 0, 0, minhchungpath22);
            phieuChamDiemServices.saveChiTietPhieuCham(maphieuchamdiem, 23, diemTuCham_23, 0, 0, minhchungpath23);

            return RedirectToAction("Index");
        }
        public ActionResult ListClass(string maLop)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            var model = db.sinhViens.Where(x => x.maLop.Equals(maLop)).Where(x => x.maSinhVien.Equals(session.UserName)).ToList();
            var hocky = sinhVienServices.ListHocKy();
            Session.Add(Models.Constraints.Common.LOP_USER_SESSION, maLop);
            if (model != null)
            {
                ViewBag.Hocky = hocky;
                return View(model);

            }
            return View();
        }
        [HttpPost]
        public JsonResult ListClass(string maLop, string maHocKy)
        {
            var sinhVien = db.sinhViens.Where(x => x.maLop.Equals(maLop)).Where(x => x.trangThai == Models.Constraints.Common.ACTIVATE).ToList();
            List<string> maSinhVien = new List<string>();
            List<PhieuChamDiemModel> sinhVienChamDiem = new List<PhieuChamDiemModel>();
            foreach (var item in sinhVien)
            {
                maSinhVien.Add(item.maSinhVien);
            }
            foreach (var items in maSinhVien)
            {
                //var sinhVienChamDiems = db.phieuChamDiems.Where(x => x.maSinhVien.Equals(items)).Where(x => x.maHocKi == maHocKy).SingleOrDefault();
                var sinhVienChamDiems = from s in db.sinhViens
                                        join c in db.phieuChamDiems
                                        on s.maSinhVien equals c.maSinhVien
                                        where c.maSinhVien.Equals(items)
                                        where c.maHocKi.Equals(maHocKy)
                                        select new PhieuChamDiemModel //tra ve 1 custom class
                                        {
                                            maSinhVien = s.maSinhVien,
                                            tenSinhVien = s.tenSinhVien,
                                            tongDiem = c.tongDiem

                                        };
                var sinhVienInfo = sinhVienChamDiems.SingleOrDefault();
                if (sinhVienInfo != null)
                {
                    var masinhvien = sinhVienInfo.maSinhVien;
                    var tensinhvien = sinhVienInfo.tenSinhVien;
                    var tongdiem = sinhVienInfo.tongDiem;
                    sinhVienChamDiem.Add(new PhieuChamDiemModel(masinhvien, tensinhvien, tongdiem));
                }

            }

            return Json(sinhVienChamDiem, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewScores()
        {
            return View();
        }
        public ActionResult UpdatePersonalInfo(string maUser)
        {

            var model = sinhVienServices.ListWhereAll(maUser);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdatePersonalInfo(sinhVien sv)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            sinhVienServices.UpdatePersonalInfo(sv);
            return RedirectToAction("UpdatePersonalInfo", "Students", new { maUser = session.UserName });
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ChangePassword(string maSinhVien, string password, string newPassword)
        {
            bool result;
            var sv = db.sinhViens.Where(x => x.maSinhVien.Equals(maSinhVien)).Where(x => x.matKhau == password).SingleOrDefault();
            if (sv != null)
            {
                sv.matKhau = newPassword;
                db.SaveChanges();
                Session[Models.Constraints.Common.USER_SESSION] = null;
                Session[Models.Constraints.Common.NAME_USER_SESSION] = null;
                result = true;
            }
            else
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Notification()
        {
            return View();
        }
        public ActionResult DetailNotification()
        {
            return View();
        }
    }
    
}