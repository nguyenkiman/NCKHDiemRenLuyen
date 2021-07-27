using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiemRenLuyen.Controllers
{
    public class OfficersController : Controller
    {
        // GET: Officers
        public ActionResult Index()
        {
            var session = Session[Models.Constraints.Common.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        public ActionResult ListClass()
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
        public ActionResult MarkPoint()
        {
            return View();
        }
    }
}