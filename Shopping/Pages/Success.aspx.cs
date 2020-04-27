using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Shopping.Models;
namespace Shopping.Pages
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String[] amount = { "Cash On delivery", "Credit Card" };
                DropDownList1.DataSource = amount;
                DropDownList1.AppendDataBoundItems = true;
                DropDownList1.AutoPostBack = true;
                DropDownList1.DataBind();
            }

                TextBox1.Visible = false;
                TextBox2.Visible = false;
                TextBox3.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
           
            
        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Order> orders = (List<Order>)Session[User.Identity.GetUserId()];

            OrderModel model = new OrderModel();
            model.MarkOrederAsPaid(orders);
            model.Delete();

            Session[User.Identity.GetUserId()] = null;
            Literal1.Text = "Your payemnet has been recieved , Thank you for choosing us  ";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           String g= DropDownList1.SelectedValue;
            if(g =="Cash On delivery")
            {
                Label1.Visible = true;
                TextBox1.Visible = true;
                TextBox3.Visible = true;
                Label3.Visible = true;
            }
            else
            {
                Label2.Visible = true;
                TextBox2.Visible = true;
            }
        }
    }
}