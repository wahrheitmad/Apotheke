using Apotheke.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

//namespace Apotheke.App_Start
namespace Apotheke
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "list/{category}/{page}",
                                        "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "", "~/Pages/Listing.aspx");
            routes.MapPageRoute("list", "list", "~/Pages/Listing.aspx");
            routes.MapPageRoute("search", "search", "~/Pages/SearchListing.aspx");

            routes.MapPageRoute("cart", "cart", "~/Pages/CartView.aspx");
            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");
            routes.MapPageRoute("login", "login", "~/Pages/Login.aspx");
            routes.MapPageRoute("history", "history", "~/Pages/OrderHistory.aspx");
            routes.MapPageRoute("info", "info", "~/Pages/OrderDetails.aspx");
            routes.MapPageRoute("register", "register", "~/Pages/Register.aspx");

        }
    }
}