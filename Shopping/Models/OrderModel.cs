using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class OrderModel
    {
        public String InsertOrder(Order order)
        {
            try
            {
                ShopEntities db = new ShopEntities();
                db.Orders.Add(order);
                db.SaveChanges();
                return order.Date_ordered + " is succesfully inserted to your shooping cart";
            }
            catch (Exception e)
            {
                return "Error :" + e;
            }

        }
        public String UpdateOrder(int id, Order order)
        {
            try
            {
                ShopEntities db = new ShopEntities();
                //fetch object from db
                Order p = db.Orders.Find(id);
                p.Date_ordered = order.Date_ordered;
                p.Customer_id = order.Customer_id;
                p.Quantity = order.Quantity;
                p.is_in_order = order.is_in_order;
                p.Product_id = order.Product_id;
                db.SaveChanges();
                return order.Date_ordered + " was succesfully updated";

            }
            catch (Exception e)
            {
                return "Error :" + e;
            }

        }
        public String DeleteOrder(int id)
        {
            try
            {
                ShopEntities db = new ShopEntities();
                Order p = db.Orders.Find(id);
                db.Orders.Attach(p);
                db.Orders.Remove(p);
                db.SaveChanges();
                return p.Date_ordered + " was succesfully Deleted";

            }
            catch (Exception e)
            {
                return "Error :" + e;
            }

        }
        public void Delete()
        {
            
                ShopEntities db = new ShopEntities();
                 List<Order> orders = (from x in db.Orders
                                  where x.is_in_order == false
                                  select x).ToList();
                 if (orders != null)
                 {
                     foreach (Order order in orders)
                     {
                         db.Orders.Attach(order);
                         db.Orders.Remove(order);
                         db.SaveChanges();
                     }
                 }
               
               

            
           

        }
        public List<Order> GetOrdersInCart(string userid)
        {
            ShopEntities db = new ShopEntities();
            List<Order> orders = (from x in db.Orders
                                  where x.Customer_id == userid
                                  && x.is_in_order
                                  orderby x.Date_ordered
                                  select x).ToList();
            return orders;

        }
        public int GetAmountOfOrders(string userid)
        {
            try
            {
                ShopEntities db = new ShopEntities();
                int amount = (from x in db.Orders
                                      where x.Customer_id == userid
                                      && x.is_in_order
                                      
                                      select x.Quantity).Sum();
                return amount;
            }
            catch
            {
                return 0;
            }

        }
        public void UpdateQuantity(int id,int qu)
        {
            ShopEntities db = new ShopEntities();
            Order order = db.Orders.Find(id);
            order.Quantity = qu;
            db.SaveChanges();
        }
        public void MarkOrederAsPaid(List<Order>orders)
        {
            ShopEntities db = new ShopEntities();
            if(orders!=null)
            {
                foreach(Order order in orders)
                {
                    Order oldorder = db.Orders.Find(order.Id);
                    oldorder.Date_ordered = DateTime.Now;
                    oldorder.is_in_order = false;
                }
                db.SaveChanges();
            }
        }
    }
}