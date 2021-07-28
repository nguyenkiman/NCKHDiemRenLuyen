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
    public class HomeController : BaseController
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
                    SetAlert("Tài khoản không tồn tại", "error");
                    //Response.Write("<script>alert('Tài khoản không tồn tại');</script>");
                }
                else
                {
                    if (checkHocSinh == Models.Constraints.Common.LOGIN_SUCCESS)
                    {
                        var sinhVien = sinhVienServices.findByMaSinhVien(user.UserName);
                        Session.Add(Models.Constraints.Common.USER_SESSION, user);
                        Session.Add(Models.Constraints.Common.NAME_USER_SESSION, sinhVien.tenSinhVien);
                        Session.Add(Models.Constraints.Common.LOP_USER_SESSION, sinhVien.maLop);
                        SetAlert("Đăng nhập thành công", "success");
                        if (sinhVienServices.isCanBoLop(user.UserName))
                        {
                            return RedirectToAction("Index", "Officers");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Students");
                        }
                    }
                    else if (checkHocSinh == Models.Constraints.Common.INVALID_PASSWORDS)
                    {
                        SetAlert("Mật khẩu không đúng", "error");
                    }
                    else
                    {
                        SetAlert("Tài khoản bị khóa", "error");
                        // ModelState.AddModelError("", "Tài khoản bị khóa");
                    }
                }

            }
            else
            {
                if (checkGiangVien == Models.Constraints.Common.LOGIN_SUCCESS)
                {
                    var giangVien = giangVienServices.findByMaGiangVien(user.UserName);
                    Session.Add(Models.Constraints.Common.NAME_USER_SESSION, giangVien.tenGiangVien);
                    Session.Add(Models.Constraints.Common.USER_SESSION, user);
                    SetAlert("Đăng nhập thành công", "success");
                    return RedirectToAction("Index", "Teacher");
                }
                else if (checkGiangVien == Models.Constraints.Common.INVALID_PASSWORDS)
                {
                    SetAlert("Mật khẩu không đúng", "error");
                    //ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    SetAlert("Tài khoản bị khóa", "error");
                    //ModelState.AddModelError("", "Tài khoản bị khóa");
                }
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Logout()
        {
            Session[Models.Constraints.Common.USER_SESSION] = null;
            Session[Models.Constraints.Common.NAME_USER_SESSION] = null;
            return RedirectToAction("Index", "Home");
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