using Apotheke.Models;
using Apotheke.Models.Repository;
using Apotheke.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apotheke.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        public static User user;
        public static bool IsLoggedIn = false;
        public static User GetUser(string email, string password)
        {
            Repository repository = new Repository();
            IEnumerable<User> users = repository.Users;
            return users
                .Select(u => u)
                .Where(u => u.Email.Equals(email) && u.Password.Equals(password))
                .FirstOrDefault();
                             
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(IsPostBack)
            {
                string email = exampleInputEmail1.Value;
                string password = exampleInputPassword1.Value;
                if(GetUser(email, password) != null )
                {
                    IsLoggedIn = true;
                    user = GetUser(email, password);
                        Response.Redirect(RouteTable.Routes
                            .GetVirtualPath(null, "list", null).VirtualPath);
                }
                else 
                {
                    this.Page.Response.Write("Неправильные почта или пароль!");
                }
                
            }
        }
    }
}