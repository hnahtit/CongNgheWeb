using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_ShoesStore.Models.Entities;

namespace WEB_ShoesStore.Models.Dao
{
    public class OrderDetailDao
    {
        ShoesDBContext db = null;
        public OrderDetailDao()
        {
            db = new ShoesDBContext();
        }
        public bool Insert(OrderDetail detail)
        {
           try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true; //order kieu bigint
            }
            catch
            {
                return false;
            }
        }
    }
}