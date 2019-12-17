using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEB_ShoesStore.Models.Entities;

namespace WEB_ShoesStore.Models.Functions
{
    public class F_AdminAccount
    {
        private ShoesDBContext context = null;
        public F_AdminAccount()
        {
            context = new ShoesDBContext();
        }
        public bool Login(string userName, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@pass",password)
            };
            var res = context.Database.SqlQuery<bool>("Admin_Login @UserName, @pass", sqlParams).SingleOrDefault();
            return res;
        }
    }
}