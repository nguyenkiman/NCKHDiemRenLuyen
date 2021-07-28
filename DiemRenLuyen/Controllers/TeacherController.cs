using System.Web.Mvc;
using Models.EF;
using Models.Services;
using DiemRenLuyen.Model;
using System.Linq;
using Models.DAO;
using System.Collections.Generic;
using Models.Constraints;
using Models.ViewModel;
using System.Data.Entity;

namespace DiemRenLuyen.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        Db db = new Db();
        giangVienServices giangVienServices = new giangVienServices();
        giangVienDAO giangVienDAO = new giangVienDAO();
        sinhVienServices sinhVienServices = new sinhVienServices();
        phieuChamDiemServices phieuChamDiemServices = new phieuChamDiemServices();
        public ActionResult Index()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var model = giangVienServices.ListClass(session.UserName);
            ViewBag.GiaoVienChuNhiem = model;
            return View();
        }
        public ActionResult TeacherSuccess()
        {
            var session = (LoginModel)Session[Common.USER_SESSION];
            var maLop = Session[Common.LOP_USER_SESSION];
            var model = giangVienServices.ListGVCN(maLop, session.UserName);
            ViewBag.GiaoVienChuNhiem = model;
            return View();
        }
        public ActionResult ListClass(string maLop)
        {
            var session = (LoginModel)Session[Common.USER_SESSION];
            var model = giangVienServices.ListGVCN(maLop, session.UserName);
            var hocky = giangVienServices.ListHocKy();
            var gvcn = giangVienServices.ListClass(session.UserName);
            
            Session.Add(Common.LOP_USER_SESSION, maLop);
            if (model != null)
            {
                ViewBag.GiaoVienChuNhiem = model;
                ViewBag.Hocky = hocky;
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public JsonResult ListClass(string maLop, string maHocKy)
        {
            var sinhVien = db.sinhViens.Where(x => x.maLop.Equals(maLop)).Where(x => x.trangThai == Common.ACTIVATE).ToList();
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
                    var trangthai = sinhVienInfo.trangThai;
                    sinhVienChamDiem.Add(new PhieuChamDiemModel(masinhvien,tensinhvien,tongdiem, trangthai));
                }    
                 
            }

            return Json(sinhVienChamDiem, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DetailPoint(string masinhvien, string maHocKy)
        {
            var session = (LoginModel)Session[Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            phieuChamDiem phieuChamDiem = phieuChamDiemServices.findByMaSinhVienAndMaHocKy(masinhvien, maHocKy);

            var model = giangVienServices.ListClass(session.UserName);
            ViewBag.GiaoVienChuNhiem = model;
            return View(phieuChamDiem);
        }
        [HttpPost]
        public ActionResult DetailPoint(string maSinhVien,string maHocKi, int diemTuCham_1, int diemTuCham_2, int diemTuCham_3, int diemTuCham_4, int diemTuCham_5, int diemTuCham_6, int diemTuCham_7,
            int diemTuCham_8, int diemTuCham_9, int diemTuCham_10, int diemTuCham_11, int diemTuCham_12, int diemTuCham_13, int diemTuCham_14, int diemTuCham_15, int diemTuCham_16
            , int diemTuCham_17, int diemTuCham_18, int diemTuCham_19, int diemTuCham_20, int diemTuCham_21, int diemTuCham_22, int diemTuCham_23)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            phieuChamDiem phieuChamDiem = new phieuChamDiem();
            phieuChamDiem oldphieuChamDiem = phieuChamDiemServices.findByMaSinhVienAndMaHocKy(maSinhVien, maHocKi);

            phieuChamDiem.maPhieuChamDiem = oldphieuChamDiem.maPhieuChamDiem;
            phieuChamDiem.maSinhVien = oldphieuChamDiem.maSinhVien;
            phieuChamDiem.maHocKi = oldphieuChamDiem.maHocKi;
            phieuChamDiem.ngayCham = oldphieuChamDiem.ngayCham;
            phieuChamDiem.tongDiemSV = oldphieuChamDiem.tongDiemSV;
            phieuChamDiem.tongDiemCBL = oldphieuChamDiem.tongDiemCBL;
            phieuChamDiem.trangThai = 3;
            phieuChamDiem.tongDiem = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9 + diemTuCham_10 + diemTuCham_11
                + diemTuCham_12 + diemTuCham_13 + diemTuCham_14 + diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19 + diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;

            phieuChamDiem.tongDiemGVCN = diemTuCham_1 + diemTuCham_2 + diemTuCham_3 + diemTuCham_4 + diemTuCham_5 + diemTuCham_6 + diemTuCham_7 + diemTuCham_8 + diemTuCham_9 + diemTuCham_10 + diemTuCham_11
                + diemTuCham_12 + diemTuCham_13 + diemTuCham_14 + diemTuCham_15 + diemTuCham_16 + diemTuCham_17 + diemTuCham_18 + diemTuCham_19 + diemTuCham_20 + diemTuCham_21 + diemTuCham_22 + diemTuCham_23;




            db.Entry(phieuChamDiem).State = EntityState.Modified;
            db.SaveChanges();

            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 1, diemTuCham_1);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 2, diemTuCham_2);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 3, diemTuCham_3);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 4, diemTuCham_4);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 5, diemTuCham_5);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 6, diemTuCham_6);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 7, diemTuCham_7);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 8, diemTuCham_8);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 9, diemTuCham_9);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 10, diemTuCham_10);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 11, diemTuCham_11);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 12, diemTuCham_12);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 13, diemTuCham_13);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 14, diemTuCham_14);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 15, diemTuCham_15);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 16, diemTuCham_16);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 17, diemTuCham_17);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 18, diemTuCham_18);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 19, diemTuCham_19);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 20, diemTuCham_20);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 21, diemTuCham_21);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 22, diemTuCham_22);
            phieuChamDiemServices.GVCNUpdateChiTietPhieuCham(phieuChamDiem.maPhieuChamDiem, 23, diemTuCham_23);

            return RedirectToAction("OfficersSuccess", "Teacher");
        }
        public ActionResult UpdatePersonalInfo(string maUser)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var model = giangVienServices.ListWhereAll(maUser);
            var gvcn = giangVienServices.ListClass(maUser);
            ViewBag.GiaoVienChuNhiem = gvcn;
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdatePersonalInfo(giangVien gv)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            giangVienServices.UpdatePersonalInfo(gv);
            return RedirectToAction("UpdatePersonalInfo", "Teacher", new { maUser = session.UserName });
        }
        public ActionResult ChangePassword(string maUser)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var gvcn = giangVienServices.ListClass(maUser);
            ViewBag.GiaoVienChuNhiem = gvcn;
            return View();
        }
        [HttpPost]
        public JsonResult ChangePassword(string maGiangVien, string password, string newPassword, string newPasswordConfirm)
        {
            int NOT_NULL = 0;
            int CHANGE_SUCCESS = 2;
            int result;
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newPasswordConfirm))
            {
                result = NOT_NULL;
            }
            else
            {
                var gv = db.giangViens.Where(x => x.maGiangVien.Equals(maGiangVien)).Where(x => x.matKhau == password).SingleOrDefault();
                if (gv != null)
                {
                    gv.matKhau = newPassword;
                    db.SaveChanges();
                    result = CHANGE_SUCCESS;
                }
                else
                {
                    result = Common.INVALID_PASSWORDS;
                }
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}