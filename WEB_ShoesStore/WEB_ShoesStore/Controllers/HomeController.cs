using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_ShoesStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Shop()
        {
            return View();
        }
        public ActionResult Single(string id)
        {   /*
            var model = new F_Product().FindEntity(id);
            return View(model);
            */
            return View();
        }
        [HttpPost]
        public ActionResult Search(string s)
        {
            /*
            var model = new F_Product().DS_Product.Where(x => x.Product_Name.Contains(s)).ToList();
            ViewBag.SP = model;
            return View("Index", model);
            */
            return View();
        }
    }
}