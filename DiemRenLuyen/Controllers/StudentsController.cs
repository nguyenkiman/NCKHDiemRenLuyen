<<<<<<< HEAD
﻿using Models.EF;
using Models.Services;
=======
﻿using Models.Services;
>>>>>>> parent of 362962d (Merge branch 'master' into develops)
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