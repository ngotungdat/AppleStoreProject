using AppleStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppleStoreIAL
{
    public interface ICart
    {
        List<GioHang> GetAllCart();
        List<GioHang> AddCart(string id);
        GioHang RemoveFromCart(GioHang IdProd);
    }
}
