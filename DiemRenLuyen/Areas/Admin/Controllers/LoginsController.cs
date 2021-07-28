using DiemRenLuyen.Areas.Admin.Model;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiemRenLuyen.Areas.Admin.Controllers
{
    public class LoginsController : Controller
    {
        // GET: Admin/Logins
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new adminDAO();
                var result = dao.checkLogin(user.UserName, user.PassWord);
                if(result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else
                {
                    if (result == 2)
                    {
                        ModelState.AddModelError("", "Đăng nhập thành công");
                        Session.Add(Models.Constraints.Common.USER_SESSION, user);
                        return RedirectToAction("Index", "baoHiemYTes");
                    }
                    else
                    {
                        if (result == 1)
                        {
                            ModelState.AddModelError("", "Mật khẩu sai");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Tài khoản đã bị khoá");
                        }
                    }
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[Models.Constraints.Common.USER_SESSION] = null;
            return RedirectToAction("Index", "Logins");
        }
    }
}