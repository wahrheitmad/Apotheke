using Apotheke.Models.Repository;
using Apotheke.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Printing;
using System.Drawing;

namespace Apotheke.Pages
{
    public partial class Store : System.Web.UI.MasterPage
    {
       public static string find;

        public bool Logge()
        {
            if(Login.IsLoggedIn == true)
            { return true; }
            else return false;
        }

        public string LoginUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "login",
                    null).VirtualPath;
            }
        }

        public string RegisterUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "register",
                    null).VirtualPath;
            }
        }

        public string HistoryUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "history",
                    null).VirtualPath;
            }
        }

        public string FindUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "search",
                    null).VirtualPath;
            }
        }

        public string LogOutUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "list",
                    null).VirtualPath;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Login.IsLoggedIn == true)
            { 
                welcome.InnerText = "Вы авторизированы как " + Login.user.FullName; 

            }
            else
            {
                his.Visible = false;
            }
          
            if(IsPostBack) { find = searchInput1.Text; }
        }
    }
}