using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Collections;
using System.Web.UI.WebControls;
using Shopping.Models;

namespace Shopping.Pages.Management
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GetImages();

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void GetImages()
        {
            try
            {
                //get file paths
                string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products"));
                //get all file names
                ArrayList imagelist = new ArrayList();
                foreach(string image in images )
                {
                    string imageName=image.Substring(image.LastIndexOf(@"\" , StringComparison.Ordinal)+1);
                    imagelist.Add(imageName);
                }
                DropDownList2.DataSource = imagelist;
                DropDownList2.AppendDataBoundItems = true;
                DropDownList2.DataBind();

            }
            catch(Exception e)
            {
                Label1.Text = e.ToString();
            }

        }
        private Product createproduct()
        {
            Product p=new Product();
            p.Name=TextBox1.Text;
            p.Price=Convert.ToInt32(TextBox2.Text);
            p.Category_id=Convert.ToInt32(DropDownList1.SelectedValue);
            p.Description=TextBox3.Text;
            p.Image=DropDownList2.SelectedValue;

            return p;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProductModel p=new ProductModel();
            Product pro = createproduct();
            Label1.Text = p.InsertProduct(pro);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}