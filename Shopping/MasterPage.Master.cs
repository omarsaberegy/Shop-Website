using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
namespace Shopping
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Context.User.Identity;
            String user_name=Context.User.Identity.Name;
            if(user.IsAuthenticated)
            {
                if (user_name == "admin")
                {
                    LnkSignI.Visible = false;
                    lnkRegister.Visible = false;

                    LnkSignout.Visible = true;
                    LiStatus.Visible = false;
                    HyperLink1.Visible = false;
                    HyperLink2.Visible = false;
                    HyperLink3.Visible = false;
                    HyperLink5.Visible = false;

                }
                else
                {
                    //LiStatus.Text = Context.User.Identity.Name;
                    LnkSignI.Visible = false;
                    lnkRegister.Visible = false;
                    HyperLink4.Visible = false;

                    LnkSignout.Visible = true;
                    LiStatus.Visible = true;

                    OrderModel model = new OrderModel();
                    String userid = HttpContext.Current.User.Identity.GetUserId();
                    //LiStatus.Text
                    LiStatus.Text = string.Format("{0} ({1})", Context.User.Identity.Name,
                        model.GetAmountOfOrders(userid));
                }
               
            }
            else
            {
                LnkSignI.Visible = true;
                lnkRegister.Visible = true;

                LnkSignout.Visible = false;
                LiStatus.Visible = false;
                HyperLink4.Visible = false;


            }
        }

        protected void LnkSignout_Click(object sender, EventArgs e)
        {
            var authenticationmanager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationmanager.SignOut();
            Response.Redirect("~/Index.aspx");
        }
    }
}