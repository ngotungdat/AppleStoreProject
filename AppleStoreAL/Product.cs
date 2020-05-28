using AppleStore.Model;
using AppleStoreIAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppleStoreAL
{
    public class Product : IProduct
    {
        private AppleStoreDbContext objAppleStoreDbContext;
        public Product()
        {
            objAppleStoreDbContext = new AppleStoreDbContext();
        }
        public IEnumerable<SanPham> Detail(string id)
        {
            var sp = from p in objAppleStoreDbContext.SanPhams where p.MaSanPham == id select p;
            return sp.ToList();
        }

        public List<SanPham> GetProduct()
        {
            var query = from p in objAppleStoreDbContext.SanPhams
                        select p;
            return query.ToList();
        }

        public IEnumerable<SanPham> GetProductById(string txtSearch)
        {
            var result = from p in objAppleStoreDbContext.SanPhams
                         select p;
            if (!string.IsNullOrEmpty(txtSearch))
            {
                result = result.Where(x => x.TenSanPham.Contains(txtSearch));
            }
            return result;
        }
    }
}
