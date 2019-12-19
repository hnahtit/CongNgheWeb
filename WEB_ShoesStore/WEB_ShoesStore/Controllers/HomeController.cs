using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_ShoesStore.Models.Dao;
using WEB_ShoesStore.Models.Entities;
using WEB_ShoesStore.Models.Functions;

namespace WEB_ShoesStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new F_Product().DS_Product.ToList();
            return View(model);
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
      
        public ActionResult Shop()
        {
            return View();
        }
        public ActionResult Single(string id)
        {   
            var model = new F_Product().FindEntity(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Search(string s)
        {     
            var model = new F_Product().DS_Product.Where(x => x.Product_Name.Contains(s)).ToList();
            ViewBag.SP = model;
            return View("Index", model);
        }
        // GET: DangKy
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(F_RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                long id = 5;
                var dao = new UserDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var u = new User();
                    u.ID = id;
                    u.UserName = model.UserName;
                    u.Password = model.Password;
                    u.Phone = model.Phone;
                    u.Email = model.Email;
                    u.Address = model.Address;
                    u.Status = true;

                    var result = dao.Insert(u);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new F_RegisterModel();
                        return Redirect("~/Home/Login");
             
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            else
            {

            }
            return View(model);
        }
    }
}