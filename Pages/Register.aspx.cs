using Apotheke.Models;
using Apotheke.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apotheke.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        EFDbContext db = new EFDbContext();

        public bool AlreadyExist(string email, string username)
        {
            List<User> users = db.Users.ToList();
            bool answer = true;
            foreach (User us in users)
            {
                if (us.Email == email) { answer = false; break; }
                else if (us.Username == username) { answer = false; break; }
                else if (us.Username != username && us.Email != email)
                {
                    answer = true;
                }
            }
            return answer;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string email = exampleInputEmail1.Value;
                string name = exampleInputName.Value;
                string username = exampleInputUserName.Value;
                string password = exampleInputPassword1.Value;

                User user = new User()
                {
                    Email = email,
                    FullName = name,
                    Username = username,
                    Password = password
                };
                if (AlreadyExist(email, username) == true)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    Login.IsLoggedIn = true;
                    Login.user = Login.GetUser(email, password);
                    Response.Redirect(RouteTable.Routes
                        .GetVirtualPath(null, "list", null).VirtualPath);
                }
                else { this.Page.Response.Write("Такие логин или пароль уже зарегистрированы в системе!"); }
                


            }
        }
    }
}