using Apotheke.Models;
using Apotheke.Models.Repository;
using Apotheke.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apotheke.Pages
{
    public partial class OrderHistory : System.Web.UI.Page
    {
      
        public static Order orderToShow;
        Repository repository = new Repository();
        
        public IEnumerable<Order> GetOrders()
        {
            int userID = Login.user.UserID;
            IEnumerable<Order> orders = repository.Orders;

            return orders.Where(o => o.UserID == userID);
                
        }

        
        


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
            {       
                int orderId;
                if (int.TryParse(Request.Form["info"], out orderId))
                {
                     orderToShow = repository.Orders
                        .Where(o => o.OrderID == orderId).FirstOrDefault();
                    Response.Redirect(RouteTable.Routes
                           .GetVirtualPath(null, "info", null).VirtualPath);
                   
                }
            }
        }
    }
}