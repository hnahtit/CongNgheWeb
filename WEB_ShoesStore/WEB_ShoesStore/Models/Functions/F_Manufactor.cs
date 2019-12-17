using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_ShoesStore.Models.Entities;

namespace WEB_ShoesStore.Models.Functions
{
    public class F_Manufactor
    {
        private ShoesDBContext context;

        public F_Manufactor()
        {
            context = new ShoesDBContext();
        }

        // Trả về tất cả các bản ghi
        public IQueryable<Manufacturer> DS_Manufactor
        {
            get { return context.Manufacturers; }
        }

        // Trả về một đối tượng khi biết khóa
        public Manufacturer FindEntity(string ManufactorKey)
        {
            Manufacturer dbEntry = context.Manufacturers.Find(ManufactorKey);
            return dbEntry;
        }

        // Thêm một đối tượng
        public string Insert(Manufacturer model)
        {
            Manufacturer dbEntry = context.Manufacturers.Find(model.Manufacturer_ID);
            if (dbEntry != null)
            {
                return null;
            }

            context.Manufacturers.Add(model);
            context.SaveChanges();
            return model.Manufacturer_ID;
        }

        // Sửa dữ liệu
        public string Update(Manufacturer model)
        {
            Manufacturer dbEntry = context.Manufacturers.Find(model.Manufacturer_ID);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return null;
            }
            dbEntry.Manufacturer_ID = model.Manufacturer_ID;
            dbEntry.Manufacturer_Name = model.Manufacturer_Name;



            context.SaveChanges();

            return model.Manufacturer_ID;
        }
        public string Delete(string ManufactorKey)
        {
            Manufacturer dbEntry = context.Manufacturers.Find(ManufactorKey);
            if (dbEntry == null)
            {
                return null;
            }
            context.Manufacturers.Remove(dbEntry);

            context.SaveChanges();
            return ManufactorKey;
        }
    }
}