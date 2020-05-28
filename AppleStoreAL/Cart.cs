using AppleStore.Model;
using AppleStoreIAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AppleStoreAL
{
    public class Cart : ICart
    {
        AppleStoreDbContext appleStoreDbContext;
        private const string CartName = "giohang";
        public Cart()
        {
            appleStoreDbContext = new AppleStoreDbContext();
        }
        [HttpPost]
        public List<GioHang> AddCart(string id)
        {
            throw new NotImplementedException();
        }

        public List<GioHang> GetAllCart()
        {
            throw new NotImplementedException();
        }

        public GioHang RemoveFromCart(GioHang IdProd)
        {
            throw new NotImplementedException();
        }
    }
}
