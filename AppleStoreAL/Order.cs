using AppleStore.Model;
using AppleStoreIAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleStoreAL
{
    public class Order
    {
        private AppleStoreDbContext appleStoreDbContext;
        public Order()
        {
            appleStoreDbContext = new AppleStoreDbContext();
        }
        public string Insert(KhachHang order)
        {
            appleStoreDbContext.KhachHangs.Add(order);
            appleStoreDbContext.SaveChanges();
            return order.MaKhachHang;
        }
    }
}
