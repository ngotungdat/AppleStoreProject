using AppleStoreIAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        private IProduct _iProduct;
        public SearchController(IProduct iproduct)
        {
            _iProduct = iproduct;
        }
        public ActionResult Searchs(string txtSearch)
        {
            return View(_iProduct.GetProductById(txtSearch));
        }
    }
}