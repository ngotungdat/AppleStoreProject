using AppleStore.Model;
using AppleStoreIAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Controllers
{
    public class HomeController : Controller
    {
        private IProduct _iProduct;
        public HomeController(IProduct iProduct)
        {
            _iProduct = iProduct;
        }
        public ActionResult Index()
        {
            List<SanPham> listProd = _iProduct.GetProduct();
            return View(listProd);
        }
        public ActionResult Detailes(string id)
        {
            IEnumerable<SanPham> prod = _iProduct.Detail(id);
            return View(prod);
        }
    }
}