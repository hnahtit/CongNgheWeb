using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_ShoesStore.Areas.Admin.Code;
using WEB_ShoesStore.Areas.Admin.Models;
using WEB_ShoesStore.Common;
using WEB_ShoesStore.Models.Dao;
using WEB_ShoesStore.Models.Entities;
using WEB_ShoesStore.Models.Functions;

namespace WEB_ShoesStore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = (user.ID);
                    Session.Add(Common.CommonConstant.USER_SESSION, userSession);
                    // return RedirectToAction("Index", "Home");
                    return Redirect("/Admin/AdminDanhMuc/Index");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return Redirect("Index");

        }
        public ActionResult Logout()
        {
            Session[Common.CommonConstant.USER_SESSION] = null;
            return Redirect("~/Home/Login");
        }
    }
}