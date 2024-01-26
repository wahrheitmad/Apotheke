using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apotheke.Models;
using Apotheke.Models.Repository;
using Apotheke.Pages.Helpers;

namespace Apotheke.Pages
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
            totalValue.Text = CartTot().ToString("c") + " ";
        }

        public string ReturnUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "history",
                    null).VirtualPath;
            }
        }

        public IEnumerable<OrderLine> GetOrderLines()
        {
            Order order = OrderHistory.orderToShow;
            return order.OrderLines;                
        }

        public decimal CartTot()
        {
            Order order = OrderHistory.orderToShow;
            List<OrderLine> orderLines = order.OrderLines;
            decimal total = 0;
            foreach (OrderLine line in orderLines)
            {
                total += line.Quantity * line.Drug.Price;
            }
       
            return total;
        }

        

    }

}