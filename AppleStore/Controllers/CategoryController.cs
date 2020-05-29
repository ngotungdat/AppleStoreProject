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
        public ActionResult GetAllCategorys()
        {
            ViewBag.allcategory = _iCategory.GetAllCategory();
            return View();
        }
        public ActionResult GetByCategoryId(string categoryId)
        {
            return View(_iCategory.GetAllByCategoryId(categoryId));
        }
        public ActionResult SortingByDonGia(string sortOrder)
        {
            return View(_iCategory.SortByDonGia(sortOrder));
        }
        public PartialViewResult GetCategory()
        {
            var model = _iCategory.GetAllCategory();
            return PartialView(model);
        }
        public PartialViewResult GetProductMenuLeft()
        {
            var model = _iCategory.GetProduct();
            return PartialView(model);
        }
        public PartialViewResult Slider()
        {
            return PartialView();
        }
    }
}