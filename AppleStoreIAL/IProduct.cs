using AppleStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppleStoreIAL
{
    public interface IProduct
    {
        List<SanPham> GetProduct();
        IEnumerable<SanPham> Detail(string id);
        IEnumerable<SanPham> GetProductById(string txtSearch);
    }
}
