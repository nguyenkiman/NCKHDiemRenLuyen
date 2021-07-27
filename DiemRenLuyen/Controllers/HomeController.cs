using DiemRenLuyen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Services;
using System.Web.UI;
using Microsoft.Build.Tasks;

namespace DiemRenLuyen.Controllers
{
    public class HomeController : Controller
    {
        sinhVienServices sinhVienServices = new sinhVienServices();
        giangVienServices giangVienServices = new giangVienServices();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel user)
        {
            var checkGiangVien = giangVienServices.checkLoginGiangVien(user.UserName, user.PassWord);
            var checkHocSinh = sinhVienServices.checkLogin(user.UserName, user.PassWord);
            

            if (checkGiangVien == Models.Constraints.Common.ACCOUNT_NOT_EXISTS)
            {
                if (checkHocSinh == Models.Constraints.Common.ACCOUNT_NOT_EXISTS)
                {
                    // SetAlert("Tài khoản không tồn tại", "error");
                    //Response.Write("<script>alert('Tài khoản không tồn tại');</script>");
                }
                else
                {
                    if (checkHocSinh == Models.Constraints.Common.LOGIN_SUCCESS)
                    {
                        Session.Add(Models.Constraints.Common.USER_SESSION, user);
                        if (sinhVienServices.isCanBoLop(user.UserName))
                        {
                            return RedirectToAction("Index", "Officers");
                        }
                        else
                        {
                            var sinhVien = sinhVienServices.findByMaSinhVien(user.UserName);
                            Session.Add(Models.Constraints.Common.USER_SESSION, user);
                            
                            return RedirectToAction("Index", "Students");

                        }
                    }
                    else if (checkHocSinh == Models.Constraints.Common.INVALID_PASSWORDS)
                    {

                        //ModelState.AddModelError("", "Mật khẩu không đúng");
                        //Response.Write("<script>alert('Mật khẩu không đúng');</script>");
                       // SetAlert("Mật khẩu không đúng", "error");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Tài khoản bị khóa");
                    }
                }

            }
            else
            {
                if (checkGiangVien == Models.Constraints.Common.LOGIN_SUCCESS)
                {
                    Session.Add(Models.Constraints.Common.USER_SESSION, user);
                    return RedirectToAction("Index", "Teacher");
                }
                else if (checkGiangVien == Models.Constraints.Common.INVALID_PASSWORDS)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa");
                }
            }
            return RedirectToAction("Login", "Home");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult UpdatePersonalInfo()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}