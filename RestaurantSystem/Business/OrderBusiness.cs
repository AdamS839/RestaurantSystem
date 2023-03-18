using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantSystem.Data;
using RestaurantSystem.Data.Model;

namespace RestaurantSystem.Business
{
    class OrderBusiness
    {
        private RestaurantContext orderContext;

        public List<Order> GetAll()
        {
            using (orderContext = new RestaurantContext())
            {
                return orderContext.Orders.ToList();
            }
        }

        public Order Get(int id)
        {
            using (orderContext = new RestaurantContext())
            {
                return orderContext.Orders.Find(id);
            }
        }

        public void Add(Order order)
        {
            using (orderContext = new RestaurantContext())
            {
                orderContext.Orders.Add(order);
                orderContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (orderContext = new RestaurantContext())
            {
                var order = orderContext.Orders.Find(id);
                if (order != null)
                {
                    orderContext.Orders.Remove(order);
                    orderContext.SaveChanges();
                }
            }
        }

        public void Update(Order order)
        {
            using (orderContext = new RestaurantContext())
            {
                var item = orderContext.Orders.Find(order.Id);
                if (item != null)
                {
                    orderContext.Entry(item).CurrentValues.SetValues(order);
                    orderContext.SaveChanges();
                }
            }
        }

    }
}
