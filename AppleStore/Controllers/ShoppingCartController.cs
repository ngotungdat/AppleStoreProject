using AppleStore.Model;
using AppleStoreAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: MyCart
        private AppleStoreDbContext appleStoreDbContext;
        private const string CartName = "giohang";
        public ShoppingCartController()
        {
            appleStoreDbContext = new AppleStoreDbContext();
        }
        public ActionResult Index()  //return count total price present
        {
            var sessionCart = Session[CartName] as List<GioHang>;

            var model = PrepareCartModel();
            return View(model);
        }
        public CartModel PrepareCartModel()
        {
            var sessionCart = Session[CartName] as List<GioHang>;
            if (sessionCart == null) return null;
            var model = new CartModel
            {
                Items = sessionCart,
                TotalPrice = sessionCart.Sum(x => (x.iPrice ?? 0) * (x.iSoLuong ?? 0))
            };
            return model;
        }
        [HttpPost]
        public ActionResult AddToCart(string id)
        {
            var sp = appleStoreDbContext.SanPhams.Where(x => x.MaSanPham == id).FirstOrDefault();
            if (sp == null)
            {
                return Json(false);
            }
            var GH = Session[CartName] as List<GioHang>;
            if (GH == null)
            {
                GH = new List<GioHang>();
                Session[CartName] = GH;
            }
            var exists = GH.FirstOrDefault(gh => gh.iId == id);
            if (exists == null)
            {
                GioHang gh = new GioHang();
                gh.iId = sp.MaSanPham;
                gh.iName = sp.TenSanPham;
                gh.iImage = sp.HinhMinhHoa;
                gh.iSoLuong = 1;
                gh.iPrice = sp.DonGia;
                GH.Add(gh);
            }
            else
            {
                exists.iSoLuong++;
            }
            var model = PrepareCartModel();
            return PartialView("MiniCart", model);
        }
        public ActionResult MiniCart()
        {
            var sessionCart = Session[CartName] as List<GioHang>;
            if (sessionCart == null) //Check cart empty then return partialview empty.
                return PartialView(null);
            var model = new CartModel
            {
                Items = sessionCart, //Items duoc khoi tao new list<giohang>
                TotalPrice = sessionCart.Sum(sp => (sp.iPrice ?? 0) * (sp.iSoLuong ?? 0))
                //Count toatal of cart
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult RemoveFromCart(string id, bool inCart = false)
        {
            var sp = appleStoreDbContext.SanPhams.Where(x => x.MaSanPham == id).FirstOrDefault();
            if (sp == null)
            {
                return Json(false);
            }

            var GH = Session[CartName] as List<GioHang>;
            if (GH == null)
            {
                return Json(false);
            }

            var exists = GH.FirstOrDefault(gh => gh.iId == id);
            if (exists != null)
            {
                GH.Remove(exists);
            }
            var model = PrepareCartModel();
            return PartialView(inCart ? "CartDetails" : "MiniCart", model);
        }

        [HttpPost]
        public ActionResult IncrementQuantityForCartItem(string id)
        {
            var sp = appleStoreDbContext.SanPhams.Where(x => x.MaSanPham == id).FirstOrDefault();
            if (sp == null)
            {
                return Json(false);
            }

            var GH = Session[CartName] as List<GioHang>;
            if (GH == null)
            {
                return Json(false);
            }

            var exists = GH.FirstOrDefault(gh => gh.iId == id);
            if (exists != null)
            {
                exists.iSoLuong++;
            }

            var model = PrepareCartModel();
            return PartialView("CartDetails", model);
        }

        [HttpPost]
        public ActionResult DecrementQuantityForCartItem(string id)
        {
            var sp = appleStoreDbContext.SanPhams.Where(x => x.MaSanPham == id).FirstOrDefault();
            if (sp == null)
            {
                return Json(false);
            }

            var GH = Session[CartName] as List<GioHang>;
            if (GH == null)
            {
                return Json(false);
            }

            var exists = GH.FirstOrDefault(gh => gh.iId == id);
            if (exists != null)
            {
                exists.iSoLuong--;
                if (exists.iSoLuong == 0)
                    GH.Remove(exists);
            }

            var model = PrepareCartModel();
            return PartialView("CartDetails", model);
        }

        [HttpPost]
        public ActionResult CheckOut()
        {
            try
            {
                var cart = Session[CartName] as List<GioHang>;
                foreach (var item in cart)
                {
                    var chitiet = new ChiTietDatHang();
                    chitiet.MaSanPham = item.iId;
                    chitiet.NgayDatHang = DateTime.Now;
                    chitiet.DonGia = item.iPrice;
                    chitiet.SoLuong = item.iSoLuong;
                    appleStoreDbContext.ChiTietDatHangs.Add(chitiet);
                    appleStoreDbContext.SaveChanges();
                }
                return RedirectToAction("Success", "ShoppingCart");
            }
            catch
            {
                return Content("Error");
            }
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}