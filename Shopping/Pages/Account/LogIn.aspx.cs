using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping.Pages.Account
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserStore<IdentityUser> userstore = new UserStore<IdentityUser>();
            userstore.Context.Database.Connection.ConnectionString =
               System.Configuration.ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString;
            UserManager<IdentityUser> mamger = new UserManager<IdentityUser>(userstore);
            var user = mamger.Find(TextBox1.Text, TextBox2.Text);
            if (user != null)
            {
                if (TextBox1.Text == "admin")
                {
                    //call owin functions
                    var authenticationmanager = HttpContext.Current.GetOwinContext().Authentication;

                    var userIdentity = mamger.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    //sign in user
                    authenticationmanager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, userIdentity
                        );
                    Response.Redirect("~/Pages/Management/Management.aspx");
                }
                else
                {
                    //call owin functions
                    var authenticationmanager = HttpContext.Current.GetOwinContext().Authentication;

                    var userIdentity = mamger.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    //sign in user
                    authenticationmanager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, userIdentity
                        );
                    Response.Redirect("~/Index.aspx");
                }

            }
            else
            {
                Literal1.Text = "Invalid uesrname or password";
            }
        }
    }
}