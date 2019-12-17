using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_ShoesStore.Models.Entities;
using WEB_ShoesStore.Models.Functions;

namespace WEB_ShoesStore.Areas.Admin.Controllers
{
    public class AdminDanhMucController : Controller
    {

        // GET: Admin/AdminDanhMuc
        public ActionResult Index()
        {
            var model = new F_Product().DS_Product.ToList();
            return View(model);
        }
        // GET: /Admin/AdminDanhMuc/Details/5

        public ActionResult Details(string id)
        {
            return View();
        }

        //
        // GET: /Admin/AdminDanhMuc/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/AdminDanhMuc/Create

        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                if (new F_Product().Insert(model) != null)
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/AdminDanhMuc/Edit/5

        public ActionResult Edit(string id)
        {
            var model = new F_Product().FindEntity(id);
            return View(model);
        }

        //
        // POST: /Admin/AdminDanhMuc/Edit/5

        [HttpPost]
        public ActionResult Edit(Product model)
        {
            try
            {
                new F_Product().Update(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/AdminDanhMuc/Delete/5

        public ActionResult Delete(string id)
        {
            new F_Product().Delete(id);
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/AdminDanhMuc/Delete/5

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}