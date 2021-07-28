using System.Web.Mvc;
using Models.EF;
using Models.Services;
using DiemRenLuyen.Model;
using System.Linq;
using Models.DAO;
using System.Collections.Generic;
using Models.Constraints;
using Models.ViewModel;

namespace DiemRenLuyen.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        Db db = new Db();
        giangVienServices giangVienServices = new giangVienServices();
        giangVienDAO giangVienDAO = new giangVienDAO();
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
                                       tongDiem = c.tongDiem
                                     
                                   };
                var sinhVienInfo = sinhVienChamDiems.SingleOrDefault();
                if (sinhVienInfo != null)
                {
                    var masinhvien = sinhVienInfo.maSinhVien;
                    var tensinhvien = sinhVienInfo.tenSinhVien;
                    var tongdiem = sinhVienInfo.tongDiem;
                    sinhVienChamDiem.Add(new PhieuChamDiemModel(masinhvien,tensinhvien,tongdiem));
                }    
                 
            }

            return Json(sinhVienChamDiem, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DetailPoint()
        {
            return View();
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
        public JsonResult ChangePassword(string maGiangVien, string password, string newPassword)
        {
            bool result;
            var gv = db.giangViens.Where(x => x.maGiangVien.Equals(maGiangVien)).Where(x => x.matKhau == password).SingleOrDefault();
            if (gv != null)
            {
                gv.matKhau = newPassword;
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
    }
}