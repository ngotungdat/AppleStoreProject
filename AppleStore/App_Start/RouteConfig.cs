using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AppleStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Category",
            //    url: "c/{categoryId}/{categoryName}",
            //    defaults: new { controller = "Category", action = "GetByCategoryId", categoryName = UrlParameter.Optional },
            //    namespaces: new string[] { "AppleStore.Controllers" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "AppleStore.Controllers" }
            );
        }
    }
}
