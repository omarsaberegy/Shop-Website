using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class CategoryModel
    {
        public String InsertCategory(Category category)
        {
            try
            {
                ShopEntities db = new ShopEntities();
                db.Categories.Add(category);
                db.SaveChanges();
                return category.Name + " was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error :" + e;
            }

        }
        public String UpdateCategory(int id, Category category)
        {
            try
            {
                ShopEntities db = new ShopEntities();
                //fetch object from db
                Category p = db.Categories.Find(id);
                p.Name = category.Name;
                
                db.SaveChanges();
                return category.Name + " was succesfully updated";

            }
            catch (Exception e)
            {
                return "Error :" + e;
            }

        }
        public String DeleteCategory(int id)
        {
            try
            {
                ShopEntities db = new ShopEntities();
                Category p = db.Categories.Find(id);
                db.Categories.Attach(p);
                db.Categories.Remove(p);
                db.SaveChanges();
                return p.Name + " was succesfully Deleted";

            }
            catch (Exception e)
            {
                return "Error :" + e;
            }

        }
        public int GetCategoryID(String name)
        {
            try
            {
                using (ShopEntities db = new ShopEntities())
                {
                    int id = (from x in db.Categories where x.Name == name select x.Id).Sum();
                    return id;

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

       
    }
}