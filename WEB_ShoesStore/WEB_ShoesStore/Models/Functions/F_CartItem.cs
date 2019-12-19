using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_ShoesStore.Models.Entities;

namespace WEB_ShoesStore.Models.Functions
{
    public class F_CartItem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
    }
}