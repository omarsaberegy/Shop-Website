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
    public partial class ManageCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       protected void btnsubmit_Click(object sender, EventArgs e)
        {
            CategoryModel model = new CategoryModel();
            Category c = createcategory();
            Label1.Text = model.InsertCategory(c);
          

        }
        private Category createcategory()
        {
            Category p = new Category();
            p.Name = txtName.Text;
            return p;
           
         
        }
    }
}