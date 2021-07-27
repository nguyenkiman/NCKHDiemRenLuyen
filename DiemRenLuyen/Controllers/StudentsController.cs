using Models.EF;
using Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiemRenLuyen.Model;

namespace DiemRenLuyen.Controllers
{
    public class StudentsController : Controller
    {
        Db db = new Db();
        sinhVienServices sinhVienServices = new sinhVienServices();
        // GET: Students
        public ActionResult Index()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        public ActionResult MarkPoint()
        {

            return View();
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
            var sv = db.sinhVien.Where(x => x.maSinhVien.Equals(maSinhVien)).Where(x => x.matKhau == password).SingleOrDefault();
            if(sv!=null)
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
        public ActionResult NotifySuccess()
        {
            return View();
        }
        public ActionResult NotifyError()
        {
            return View();
        }
    }
    
}