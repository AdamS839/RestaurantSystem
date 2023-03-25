using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantSystemASPNET.Data;
using RestaurantSystemASPNET.Data.Model;

namespace RestaurantSystemASPNET.Business
{
    public class OrderBusiness
    {
        private RestaurantContext orderContext;


        /// <summary>
        /// Returns a list of all orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAll()
        {
            using (orderContext = new RestaurantContext())
            {
                return orderContext.Orders.ToList();
            }
        }

        /// <summary>
        /// Finds the order with the specified id and returns it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order Get(int id)
        {
            using (orderContext = new RestaurantContext())
            {
                return orderContext.Orders.Find(id);
            }
        }

        /// <summary>
        /// Adds an order
        /// </summary>
        /// <param name="order"></param>
        public void Add(Order order)
        {
            using (orderContext = new RestaurantContext())
            {
                orderContext.Orders.Add(order);
                orderContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the order with specified id if the job exists, if not - no action is taken
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (orderContext = new RestaurantContext())
            {
                var order = orderContext.Orders.Find(id);
                if (order != null)
                {
                    orderContext.Orders.Remove(order);
                    orderContext.SaveChanges();
                    Console.WriteLine("Order deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Order not found!");
                }
            }
        }

        /// <summary>
        /// Retrieves existing order by searching the id, updates the properties and finally save the changes to the database
        /// </summary>
        /// <param name="order"></param>
        public void Update(Order order)
        {
            using (orderContext = new RestaurantContext())
            {
                var item = orderContext.Orders.Find(order.OrderId);
                if (item != null)
                {
                    orderContext.Entry(item).CurrentValues.SetValues(order);
                    orderContext.SaveChanges();
                }
            }
        }

    }
}
