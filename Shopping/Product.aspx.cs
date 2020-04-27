using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping.Models;
using Microsoft.AspNet.Identity;

namespace Shopping
{
    public partial class Product1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillPage();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                string clientId = Context.User.Identity.GetUserId();
                if (clientId != null)
                {

                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    int amount = Convert.ToInt32(ddlAmount.SelectedValue);

                    Order cart = new Order
                    {
                        Quantity = amount,
                        Customer_id = clientId,
                        Date_ordered = DateTime.Now,
                        is_in_order = true,
                        Product_id = id
                    };

                    OrderModel model = new OrderModel();
                    lblResult.Text = model.InsertOrder(cart);
                }
                else
                {
                    lblResult.Text = "Please log in to order items";
                }
            }
        }


        
        private void fillPage()
        {

            //Get selected product data
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                ProductModel model = new ProductModel();
                Product product = model.GetProduct(id);

                //Fill page with data
                lblTitle.Text = product.Name;
                lblDescription.Text = product.Description;
                lblPrice.Text = "Price per unit:<br/>£ " + product.Price;
                imgProduct.ImageUrl = "~/Images/Products/" + product.Image;
                lblItemNr.Text = product.Id.ToString();


                //Fill amount list with numbers 1-20
                int[] amount = Enumerable.Range(1, 20).ToArray();
                ddlAmount.DataSource = amount;
                ddlAmount.AppendDataBoundItems = true;
                ddlAmount.DataBind();
            }
        }

        

       

        }
    }
