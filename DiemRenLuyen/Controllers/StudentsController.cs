
﻿using Models.Services;
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