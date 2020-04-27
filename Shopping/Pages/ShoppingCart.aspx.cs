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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = User.Identity.GetUserId();
            GetPurchasesInCart(userid);
        }

        private void GetPurchasesInCart(string userid)
        {
            OrderModel order = new OrderModel();
            double subtotal = 0;

            //generate html for each element in purchase list
            List<Order> purchaseList = order.GetOrdersInCart(userid);
            CreateShopTable(purchaseList,out subtotal);

            //add totals to web page
            double vat=subtotal*0.21;
            double totalamount=subtotal+vat+15;

            litTotal.Text="$"+subtotal;
            LitVat.Text="$"+vat;
            LitTotalAmount.Text="$"+totalamount;


        }

        private void CreateShopTable(List<Order> purchaseList, out double subTotal)
        {

            subTotal = new double();
            ProductModel model = new ProductModel();

            foreach (Order order in purchaseList)
            {
                //Create HTML elements and fill values with database data
                Product product = model.GetProduct(order.Product_id);

                ImageButton btnImage = new ImageButton
                {
                    ImageUrl = string.Format("~/Images/Products/{0}", product.Image)
                   
                    
                };

                LinkButton lnkDelete = new LinkButton
                {
                    PostBackUrl = string.Format("~/Pages/ShoppingCart.aspx?productId={0}", order.Id),
                    Text = "Delete Item",
                    ID = "del" + order.Id,
                };
                //add an onclick event
                lnkDelete.Click += Delete_Item;

                //Fill quantity list with numbers 1-20
                int[] amount = Enumerable.Range(1, 20).ToArray();
                DropDownList ddlAmount = new DropDownList
                {
                    DataSource = amount,
                    AppendDataBoundItems = true,
                    AutoPostBack = true,
                    ID = order.Id.ToString()
                };
                ddlAmount.DataBind();
                ddlAmount.SelectedValue = order.Quantity.ToString();
                ddlAmount.SelectedIndexChanged += ddlAmount_SelectedIndexChanged;

                //Create table to hold shopping cart details with 2 rows
                Table table = new Table 
                {
                    CssClass = "CartTable" 
                   
                    


                };
                TableRow a = new TableRow();
                TableRow b = new TableRow();

                TableCell a1 = new TableCell { RowSpan = 2, Width = 50 };
                TableCell a2 = new TableCell
                {
                    Text = string.Format("<h4>{0}</h4><br />{1}<br/>In Stock",
                        product.Name, "Item No:" + product.Id),
                    HorizontalAlign = HorizontalAlign.Left,
                    Width = 350,
                };
                TableCell a3 = new TableCell { Text = "Unit Price<hr/>" };
                TableCell a4 = new TableCell { Text = "Quantity<hr/>" };
                TableCell a5 = new TableCell { Text = "Item Total<hr/>" };
                TableCell a6 = new TableCell();

                TableCell b1 = new TableCell();
                TableCell b2 = new TableCell { Text = "£ " + product.Price };
                TableCell b3 = new TableCell();
                //(order.Quantity. * product.Price)
                TableCell b4 = new TableCell { Text = "£ " + (order.Quantity * product.Price) };
                TableCell b5 = new TableCell();
                TableCell b6 = new TableCell();



                //Set special controls
                a1.Controls.Add(btnImage);
                a6.Controls.Add(lnkDelete);
                b3.Controls.Add(ddlAmount);

                //Add cells to rows
                a.Cells.Add(a1);
                a.Cells.Add(a2);
                a.Cells.Add(a3);
                a.Cells.Add(a4);
                a.Cells.Add(a5);
                a.Cells.Add(a6);

                b.Cells.Add(b1);
                b.Cells.Add(b2);
                b.Cells.Add(b3);
                b.Cells.Add(b4);
                b.Cells.Add(b5);
                b.Cells.Add(b6);


                //add rows to table
                table.Rows.Add(a);
                table.Rows.Add(b);

                //add table to pnlshoopingCart
                pnlShoppingCart.Controls.Add(table);

                //Add total of current purchased item to subtotal
                subTotal += (order.Quantity * product.Price);
            }

            //Add current user shopping cart to Session
            Session[User.Identity.GetUserId()] = purchaseList;
        }

        private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get ID of product that has had its quantity dropdownlist changed.
            DropDownList selectedList = (DropDownList)sender;
            int cartId = Convert.ToInt32(selectedList.ID);
            int quantity = Convert.ToInt32(selectedList.SelectedValue);

            //Update purchase with new quantity and refresh page
            OrderModel cartModel = new OrderModel();
            cartModel.UpdateQuantity(cartId, quantity);
            Response.Redirect("~/Pages/ShoppingCart.aspx");
        }

        private void Delete_Item(object sender, EventArgs e)
        {
            LinkButton selectedLink = (LinkButton)sender;
            string link = selectedLink.ID.Replace("del", "");
            int cartId = Convert.ToInt32(link);

            OrderModel model = new OrderModel();
            model.DeleteOrder(cartId);

            Response.Redirect("~/Pages/ShoppingCart.aspx");
        }
    }
}