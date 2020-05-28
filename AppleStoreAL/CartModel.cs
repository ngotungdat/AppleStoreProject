using AppleStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleStoreAL
{
    public class CartModel
    {
        public CartModel()
        {
            Items = new List<GioHang>();
        }
        public IList<GioHang> Items { get; set; }
        public int TotalPrice { get; set; }
        public string CartTotal => this.TotalPrice.ToString("C");
    }
}
