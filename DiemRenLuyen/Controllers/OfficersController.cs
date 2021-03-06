using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using DiemRenLuyen.Model;
using Models.Services;
using Models.ViewModel;
using System.IO;
using System.Data.Entity;

namespace DiemRenLuyen.Controllers
{
    public class OfficersController : Controller
    {
        // GET: Officers

        
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
            ViewBag.SinhVien = model;
            return View();
        }
        public ActionResult ListClass(string maLop)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            
            var model = db.sinhViens.Where(x => x.maLop.Equals(maLop)).Where(x => x.maSinhVien.Equals(session.UserName)).ToList();
            var hocky = sinhVienServices.ListHocKy();
            var sinhvien = sinhVienServices.ListWhereAll(session.UserName);

            Session.Add(Models.Constraints.Common.LOP_USER_SESSION, maLop);
            if (model != null)
            {
                ViewBag.SinhVien = sinhvien;
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
                                            tongDiem = c.tongDiem,
                                            trangThai=c.trangThai

                                        };
                var sinhVienInfo = sinhVienChamDiems.SingleOrDefault();
                if (sinhVienInfo != null)
                {
                    var masinhvien = sinhVienInfo.maSinhVien;
                    var tensinhvien = sinhVienInfo.tenSinhVien;
                    var tongdiem = sinhVienInfo.tongDiem;
                    var trangthai=sinhVienInfo.trangThai;
                    sinhVienChamDiem.Add(new PhieuChamDiemModel(masinhvien, tensinhvien, tongdiem, trangthai));
                }

            }

            return Json(sinhVienChamDiem, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult OfficersMark(string masinhvien, string maHocKy)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            phieuChamDiem phieuChamDiem = phieuChamDiemServices.findByMaSinhVienAndMaHocKy(masinhvien, maHocKy);

            var model = sinhVienServices.ListWhereAll(session.UserName);
            ViewBag.SinhVien = model;
            return View(phieuChamDiem);
        }
        public ActionResult NotifySuccess()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            var model = sinhVienServices.ListWhereAll(session.UserName);
            ViewBag.SinhVien = model;
            return View();
        }
        public ActionResult OfficersSuccess()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            var model = sinhVienServices.ListWhereAll(session.UserName);
            ViewBag.SinhVien = model;
            return View();
        }
        [HttpGet]
        public ActionResult ToastError()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            var sinhvien = sinhVienServices.ListWhereAll(session.UserName);
            var model = sinhVienServices.ListHocKy();
            ViewBag.SinhVien = sinhvien;
            return View(model);
        }
        [HttpPost]
        public ActionResult OfficersMark(string maSinhVien,int diemTuCham_1, int diemTuCham_2, int diemTuCham_3, int diemTuCham_4, int diemTuCham_5, int diemTuCham_6, int diemTuCham_7,
            int diemTuCham_8, int diemTuCham_9, int diemTuCham_10, int diemTuCham_11, int diemTuCham_12, int diemTuCham_13, int diemTuCham_14, int diemTuCham_15, int diemTuCham_16
            , int diemTuCham_17, int diemTuCham_18, int diemTuCham_19, int diemTuCham_20, int diemTuCham_21, int diemTuCham_22, int diemTuCham_23)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }

            hocKi hocKi = new hocKiServices().getCurrentHocKi();
            phieuChamDiem phieuChamDiem = new phieuChamDiem(); 
            phieuChamDiem oldphieuChamDiem = phieuChamDiemServices.findByMaSinhVienAndMaHocKy(maSinhVien, hocKi.maHocKi);
            
            phieuChamDiem.maPhieuChamDiem = oldphieuChamDiem.maPhieuChamDiem;
            phieuChamDiem.maSinhVien = oldphieuChamDiem.maSinhVien;
            phieuChamDiem.maHocKi = oldphieuChamDiem.maHocKi;
            phieuChamDiem.ngayCham = oldphieuChamDiem.ngayCham;
            phieuChamDiem.tongDiemSV = oldphieuChamDiem.tongDiemSV;
            phieuChamDiem.trangThai = 2;
            phieuChamDiem.tongDiem = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9 + diemTuCham_10 + diemTuCham_11
                + diemTuCham_12 + diemTuCham_13 + diemTuCham_14 + diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19 + diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;

            phieuChamDiem.tongDiemCBL = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9 + diemTuCham_10 + diemTuCham_11
                + diemTuCham_12 + diemTuCham_13 + diemTuCham_14 + diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19 + diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;
            



            db.Entry(phieuChamDiem).State = EntityState.Modified;
            db.SaveChanges();




            //var rs = MailServices.Send(oldphieuChamDiem.sinhVien.gmail, "CẬP NHẬT ĐIỂM RÈN LUYỆN", "Điểm rèn luyện của " + oldphieuChamDiem.sinhVien.tenSinhVien + "" +
            //    "  đã được " + sinhVienServices.findByMaSinhVien(session.UserName).tenSinhVien + " cập nhật lại");

            var rs = MailServices.Send("hoangminhcp10@gmail.com", "CẬP NHẬT ĐIỂM RÈN LUYỆN", "Điểm rèn luyện của " + oldphieuChamDiem.sinhVien.tenSinhVien + "" +
     "  đã được cán bộ lớp " + sinhVienServices.findByMaSinhVien(session.UserName).tenSinhVien + " cập nhật lại");

            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 1, diemTuCham_1);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 2, diemTuCham_2);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 3, diemTuCham_3);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 4, diemTuCham_4);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 5, diemTuCham_5);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 6, diemTuCham_6);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 7, diemTuCham_7);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 8, diemTuCham_8);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 9, diemTuCham_9);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 10, diemTuCham_10);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 11, diemTuCham_11);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 12, diemTuCham_12);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 13, diemTuCham_13);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 14, diemTuCham_14);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 15, diemTuCham_15);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 16, diemTuCham_16);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 17, diemTuCham_17);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 18, diemTuCham_18);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 19, diemTuCham_19);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 20, diemTuCham_20);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 21, diemTuCham_21);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 22, diemTuCham_22);
            phieuChamDiemServices.CBLUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 23, diemTuCham_23);

            return RedirectToAction("OfficersSuccess", "Officers");
        }

        [HttpGet]
        public ActionResult MarkPoint()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            var model = sinhVienServices.ListWhereAll(session.UserName);

            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            hocKi hocKi = new hocKiServices().getCurrentHocKi();
            if (hocKi is null)
            {
                return RedirectToAction("NotifyError", "Students");
            }
            else
            {
                phieuChamDiem phieuChamDiem = phieuChamDiemServices.findByMaSinhVienAndMaHocKy(session.UserName, hocKi.maHocKi);
                if (phieuChamDiem is null)
                {
                    phieuChamDiem = phieuChamDiemServices.generateNewPhieuChamDiem(session.UserName);
                    ViewBag.SinhVien = model;
                    return View(phieuChamDiem);
                }
                else
                {
                    ViewBag.SinhVien = model;
                    return View(phieuChamDiem);
                }
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

            newphieuChamDiem.tongDiemSV = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9 + diemTuCham_10 + diemTuCham_11
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

            return RedirectToAction("NotifySuccess", "Officers");
        }

        public ActionResult ViewScores()
        {
            var hocky = sinhVienServices.ListHocKy();
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            hocKi hocKi = hocky.First();
            phieuChamDiem phieuChamDiem = phieuChamDiemServices.findByMaSinhVienAndMaHocKy(session.UserName,hocKi.maHocKi);
            var model = sinhVienServices.ListWhereAll(session.UserName);
            ViewBag.SinhVien = model;
            ViewBag.Hocky = hocky;

            if(phieuChamDiem is null)
            {
                return RedirectToAction("ToastError", "Officers");
            }    
            return View(phieuChamDiem);
        }
        
    }
}