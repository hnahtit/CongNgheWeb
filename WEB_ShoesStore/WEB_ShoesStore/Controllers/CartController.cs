using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WEB_ShoesStore.Models.Dao;
using WEB_ShoesStore.Models.Entities;
using WEB_ShoesStore.Models.Functions;

namespace WEB_ShoesStore.Controllers
{
    public class CartController : Controller
    {
        public const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<F_CartItem>();
            if (cart != null)
            {
                list = (List<F_CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteOne(string id)
        {
            var sessionCart = (List<F_CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.Product_ID == id);
            Session[CartSession] = sessionCart; 
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<F_CartItem>>(cartModel);
            var sessionCart = (List<F_CartItem>) Session[CartSession];

            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.Product_ID == item.Product.Product_ID);
                if(jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(string ProductID, int Quantity)
        {
            var product = new F_Product().FindEntity(ProductID);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<F_CartItem>)cart;
                //neu list co chua thang productID thi
                if (list.Exists(x => x.Product.Product_ID == ProductID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.Product_ID == ProductID)
                        {
                            item.Quantity += Quantity;

                        }
                    }
                }
                else
                {
                    //tao moi doi tuong cartItem
                    var item = new F_CartItem();
                    item.Product = product;
                    item.Quantity = Quantity;
                    list.Add(item);
                }
                //gan vao session
                Session[CartSession] = list;

            }
            else
            {
                //tao moi doi tuong cartItem
                var item = new F_CartItem();
                var list = new List<F_CartItem>();
                item.Product = product;
                item.Quantity = Quantity;

                list.Add(item);
                //gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<F_CartItem>();
            if (cart != null)
            {
                list = (List<F_CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string Shipname, string mobile, string Address, string email)
        {
            
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipName = Shipname;
            order.ShipAddress = Address;
            order.ShipMobile = mobile;
            order.ShipEmail = email;

         
                var id = new OrderDao().Insert(order);
                var cart = (List<F_CartItem>)Session[CartSession];

                var detailDao = new OrderDetailDao();
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.OrderID = id;
                    orderDetail.ProductID = item.Product.Product_ID;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                }
            
          
            return Redirect("/Cart/Success");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}