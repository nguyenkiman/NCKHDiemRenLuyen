using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using DiemRenLuyen.Model;
using Models.Services;
using Models.ViewModel;

namespace DiemRenLuyen.Controllers
{
    public class OfficersController : Controller
    {
        // GET: Officers

        sinhVienServices sinhVienServices = new sinhVienServices();

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
            return View();
        }
        public ActionResult OfficersMark()
        {
            return View();
        }
        public ActionResult ViewScores()
        {
            return View();
        }
    }
}