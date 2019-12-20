using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_ShoesStore.Models.Entities;

namespace WEB_ShoesStore.Models.Dao
{
    public class OrderDao
    {
        ShoesDBContext db = null;
        public OrderDao()
        {
            db = new ShoesDBContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.MADON; //order kieu bigint
        }
    }
}