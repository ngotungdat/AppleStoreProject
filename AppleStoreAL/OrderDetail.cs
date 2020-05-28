using AppleStore.Model;
using AppleStoreIAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleStoreAL
{
    public class OrderDetail
    {
        private AppleStoreDbContext appleStoreDbContext = null;
        public OrderDetail()
        {
            appleStoreDbContext = new AppleStoreDbContext();
        }
        public bool Insert(ChiTietDatHang orderDetail)
        {
            try
            {
                appleStoreDbContext.ChiTietDatHangs.Add(orderDetail);
                appleStoreDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
