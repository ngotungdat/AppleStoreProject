using AppleStore.Model;
using AppleStoreIAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleStoreAL
{
    public class Category : ICategory
    {
        private AppleStoreDbContext objAppleStoreDbContext;
        public Category()
        {
            objAppleStoreDbContext = new AppleStoreDbContext();
        }

        public IEnumerable<SanPham> GetAllByCategoryId(string id)
        {            
            var query = from sp in objAppleStoreDbContext.SanPhams let cat = sp.TheLoai where cat.MaTheLoai == id select sp;
            var products = query.ToList();
            return products;
        }

        public List<TheLoai> GetAllCategory()
        {
            var queryCat = from cat in objAppleStoreDbContext.TheLoais select cat;
            return queryCat.ToList();
        }

        public List<SanPham> GetProduct()
        {
            var queryProd = from prod in objAppleStoreDbContext.SanPhams select prod;
            return queryProd.OrderByDescending(x => x.NgayCapNhat).Take(8).ToList();
        }

        public IEnumerable<SanPham> SortByDonGia(string sortOrder)
        {
            var listProd = from obj in objAppleStoreDbContext.SanPhams select obj;
            switch (sortOrder)
            {
                case "1":
                    listProd = listProd.OrderBy(x => x.DonGia);
                    break;
                case "0":
                    listProd = listProd.OrderByDescending(x => x.DonGia);
                    break;
                case "2":
                    listProd = listProd.OrderByDescending(x => x.SoLuongBan);
                    break;
            }
            return listProd.ToList();
        }
    }
}
