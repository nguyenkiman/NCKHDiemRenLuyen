using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using DiemRenLuyen.Model;
using Models.Services;

namespace DiemRenLuyen.Controllers
{
    
    public class StudentsController : Controller
    {
        // GET: Students
        Db db = new Db();
        sinhVienServices sinhVienServices = new sinhVienServices();

        public ActionResult Index()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
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

            phieuChamDiemServices services = new phieuChamDiemServices();
            phieuChamDiem phieuChamDiem = services.generateNewPhieuChamDiem(session.UserName);
            return View(phieuChamDiem);
        }
        [HttpPost]
        public ActionResult MarkPoint(int diemTuCham_1, int diemTuCham_2, int diemTuCham_3, int diemTuCham_4, int diemTuCham_5, int diemTuCham_6, int diemTuCham_7,
            int diemTuCham_8, int diemTuCham_9, int diemTuCham_10, int diemTuCham_11, int diemTuCham_12, int diemTuCham_13, int diemTuCham_15, int diemTuCham_16
            , int diemTuCham_17, int diemTuCham_18, int diemTuCham_19, int diemTuCham_20, int diemTuCham_21, int diemTuCham_22, int diemTuCham_23, HttpPostedFileBase minhchung13
            , HttpPostedFileBase minhchung18, HttpPostedFileBase minhchung21, HttpPostedFileBase minhchung22, HttpPostedFileBase minhchung23)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }

            phieuChamDiemServices services = new phieuChamDiemServices();
            phieuChamDiem phieuChamDiem = services.generateNewPhieuChamDiem(session.UserName);
            return View(phieuChamDiem);
        }
        public ActionResult ListClass()
        {
            return View();
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