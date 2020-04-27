using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class ProductModel
    {
        public String InsertProduct(Product product)
        {
                try
                {
                    ShopEntities db=new ShopEntities();
                    db.Products.Add(product);
                    db.SaveChanges();
                    return product.Name + " was succesfully inserted";
                }
                catch(Exception e)
                {
                    return "Error :" + e;
                }

        }
        public String UpdateProduct(int id,Product product)
        {
                 try
                {
                    ShopEntities db=new ShopEntities();
                     //fetch object from db
                    Product p = db.Products.Find(id);
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.Description = product.Description;
                    p.Image = product.Image;
                    p.Category_id = product.Category_id;
                    db.SaveChanges();
                    return product.Name + " was succesfully updated";

                }
                catch(Exception e)
                {
                    return "Error :" + e;
                }

        }
        public String DeleteProduct(int id)
        {
                 try
                {
                    ShopEntities db=new ShopEntities();
                    Product p = db.Products.Find(id);
                    db.Products.Attach(p);
                    db.Products.Remove(p);
                    db.SaveChanges();
                    return p.Name + " was succesfully Deleted";
                    
                }
                catch(Exception e)
                {
                    return "Error :" + e;
                }

        }
        public Product GetProduct(int id)
        {
            try
            {
                using(ShopEntities db=new ShopEntities())
                {
                    Product p = db.Products.Find(id);
                    return p;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }
        
        public List<Product>GetAllProducts()
        {
            try
            {
                using (ShopEntities db = new ShopEntities())
                {
                    List<Product> p = (from x in db.Products select x).ToList();
                    return p;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Product> GetProductsByType(int typeid)
        {
            try
            {
                using (ShopEntities db = new ShopEntities())
                {
                    List<Product> p = (from x in db.Products where x.Category_id==typeid select x).ToList();
                    return p;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Product> GetProductsByName(String name)
        {
            try
            {
                using (ShopEntities db = new ShopEntities())
                {
                    List<Product> p = (from x in db.Products where x.Name.Contains( name)  select x).ToList();
                    return p;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}