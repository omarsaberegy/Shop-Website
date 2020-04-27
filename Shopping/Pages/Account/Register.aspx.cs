using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping.Pages.Account
{
    public partial class Register : System.Web.UI.Page
    {


        protected void Button1_Click(object sender, EventArgs e)
        {
            //create database with new users
            UserStore<IdentityUser> userstore = new UserStore<IdentityUser>();
            //merge with our database
            userstore.Context.Database.Connection.ConnectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString;
            UserManager<IdentityUser> mamger = new UserManager<IdentityUser>(userstore);

            //create new user and store db
            IdentityUser user = new IdentityUser();
            user.UserName = TextBox1.Text;
            if(TextBox2.Text == TextBox3.Text)
            {
                try
                {
                    //create user object
                    //db will be created
                    IdentityResult res=mamger.Create(user,TextBox2.Text);
                    if(res.Succeeded)
                    {
                        UserInformation info = new UserInformation
                        {
                            FirstName=TextBox4.Text,
                            LastName=TextBox5.Text,
                            Address=TextBox6.Text,
                            PostalCard=Convert.ToInt32(TextBox7.Text),
                            GUID=user.Id
                        };
                        UserInfoModel model = new UserInfoModel();
                        model.InsertUserInformation(info);

                        //store user in db
                        var authenticationmanager = HttpContext.Current.GetOwinContext().Authentication;
                        //set to log in new user by cookie
                        var userIdentity = mamger.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        // log in the new user and redirect to home page
                        authenticationmanager.SignIn(new AuthenticationProperties(), userIdentity);
                        Response.Redirect("~/Index.aspx");
                    }
                    else
                    {
                        Literal1.Text = res.Errors.FirstOrDefault();
                    }
                }
                    catch(Exception d)
                    {
                         Literal1.Text = d.ToString();
                    }
                }
            else
            {
                 Literal1.Text = "Password don't match";
            }

            }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }




        
    }
}