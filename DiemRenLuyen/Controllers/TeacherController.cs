using System.Web.Mvc;
using Models.EF;
using Models.Services;
using DiemRenLuyen.Model;
using System.Linq;

namespace DiemRenLuyen.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        Db db = new Db();
        giangVienServices giangVienServices = new giangVienServices();
        public ActionResult Index()
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
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
        public ActionResult DetailPoint()
        {
            return View();
        }
        public ActionResult UpdatePersonalInfo(string maUser)
        {
            var model = giangVienServices.ListWhereAll(maUser);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdatePersonalInfo(giangVien gv)
        {
            var session = (LoginModel)Session[Models.Constraints.Common.USER_SESSION];
            giangVienServices.UpdatePersonalInfo(gv);
            return RedirectToAction("UpdatePersonalInfo", "Teacher", new { maUser = session.UserName });
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ChangePassword(string maGiangVien, string password, string newPassword)
        {
            bool result;
            var gv = db.giangVien.Where(x => x.maGiangVien.Equals(maGiangVien)).Where(x => x.matKhau == password).SingleOrDefault();
            if (gv != null)
            {
                gv.matKhau = newPassword;
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
    }
}