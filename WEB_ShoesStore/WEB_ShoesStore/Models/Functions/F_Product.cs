using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_ShoesStore.Models.Entities;

namespace WEB_ShoesStore.Models.Functions
{
    public class F_Product
    {
        private ShoesDBContext context;

        public F_Product()
        {
            context = new ShoesDBContext();
        }

        // Trả về tất cả các bản ghi
        public IQueryable<Product> DS_Product
        {
            get { return context.Products; }
        }

        // Trả về một đối tượng khi biết khóa
        public Product FindEntity(string productKey)
        {
            Product dbEntry = context.Products.Find(productKey);
            return dbEntry;
        }

        // Thêm một đối tượng
        public string Insert(Product model)
        {
            Product dbEntry = context.Products.Find(model.Product_ID);
            if (dbEntry != null)
            {
                return null;
            }

            context.Products.Add(model);
            context.SaveChanges();
            return model.Product_ID;
        }

        // Sửa dữ liệu
        public string Update(Product model)
        {
            Product dbEntry = context.Products.Find(model.Product_ID);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return null;
            }
            dbEntry.Product_Name = model.Product_Name;
            dbEntry.Src1 = model.Src1;
            dbEntry.Src2 = model.Src2;
            dbEntry.Src3 = model.Src3;
            dbEntry.Price = model.Price;


            context.SaveChanges();

            return model.Product_ID;
        }
        public string Delete(string productKey)
        {
            Product dbEntry = context.Products.Find(productKey);
            if (dbEntry == null)
            {
                return null;
            }
            context.Products.Remove(dbEntry);

            context.SaveChanges();
            return productKey;
        }
    }
}