using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }
        private void FillPage()
        {
            ProductModel productmodel = new ProductModel();
            List<Product> products = productmodel.GetAllProducts();

            if(products!=null)
            {
                foreach (Product product in products)
                {
                    Panel productpanel = new Panel();
                    ImageButton imgbut = new ImageButton();
                    Label lblName = new Label();
                    Label lblprice = new Label();

                    imgbut.ImageUrl = "~/Images/Products/" + product.Image;
                    imgbut.CssClass = "productImage";
                    imgbut.PostBackUrl = "~/Product.aspx?id=" + product.Id;

                    lblName.Text = product.Name;
                    lblName.CssClass = "productName";

                    lblprice.Text = "$" + product.Price;
                    lblprice.CssClass = "productPrice";

                    productpanel.Controls.Add(imgbut);
                    productpanel.Controls.Add(new Literal { Text = "<br/>" });
                    productpanel.Controls.Add(lblName);
                    productpanel.Controls.Add(new Literal { Text = "<br/>" });
                    productpanel.Controls.Add(lblprice);

                    pnlProducts.Controls.Add(productpanel);
                }
            }
                else
                {
                    pnlProducts.Controls.Add(new Literal { Text = "No products found" });

                 }
                    

            }

       
        

        }
    }
