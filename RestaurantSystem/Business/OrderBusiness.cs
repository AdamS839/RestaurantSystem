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
        private RestaurantContext orderBusiness;

        public List<Order> GetAll()
        {
            using (orderBusiness = new RestaurantContext())
            {
                return orderBusiness.Orders.ToList();
            }
        }

        public Order Get(int id)
        {
            using (orderBusiness = new RestaurantContext())
            {
                return orderBusiness.Orders.Find(id);
            }
        }

        public void Add(Order order)
        {
            using (orderBusiness = new RestaurantContext())
            {
                orderBusiness.Orders.Add(order);
                orderBusiness.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (orderBusiness = new RestaurantContext())
            {
                var employee = orderBusiness.Orders.Find(id);
                if (employee != null)
                {
                    orderBusiness.Orders.Remove(employee);
                    orderBusiness.SaveChanges();
                }
            }
        }

        public void Update(Order order)
        {
            using (orderBusiness = new RestaurantContext())
            {
                var item = orderBusiness.Orders.Find(order.Id);
                if (item != null)
                {
                    orderBusiness.Entry(item).CurrentValues.SetValues(order);
                    orderBusiness.SaveChanges();
                }
            }
        }
    }
}
