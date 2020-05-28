using AppleStore.Model;
using AppleStoreIAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private ICategory _iCategory;
        public CategoryController(ICategory icategory)
        {
            _iCategory = icategory;
        }
        public ActionResult GetByCategoryId(string categoryId)
        {
            return View(_iCategory.GetAllByCategoryId(categoryId));
        }
        public ActionResult SortingByDonGia(string sortOrder)
        {
            return View(_iCategory.SortByDonGia(sortOrder));
        }
    }
}