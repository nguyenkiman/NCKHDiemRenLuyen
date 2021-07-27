using Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using DiemRenLuyen.Model;

namespace DiemRenLuyen.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
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
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult UpdatePersonalInfo()
        {
            return View();
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