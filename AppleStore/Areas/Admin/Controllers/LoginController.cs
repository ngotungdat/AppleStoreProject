using AppleStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        AppleStoreDbContext objAppleStoreDbContext;
        public LoginController()
        {
            objAppleStoreDbContext = new AppleStoreDbContext();
        }
        public ActionResult Login(string username,string password)
        {
            USER user = objAppleStoreDbContext.USERS.SingleOrDefault(x => x.UserName == username && x.PassWord == password && x.Allowed == 1);
            if (user != null)
            {
                Session["userid"] = user.UserId;
                Session["username"] = user.UserName;
                Session["avatar"] = user.Avatar;
                return RedirectToAction("Index","Home");
            }
            ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }
    }
}