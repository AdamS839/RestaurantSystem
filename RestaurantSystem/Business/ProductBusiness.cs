﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantSystem.Data;
using RestaurantSystem.Data.Model;

namespace RestaurantSystem.Business
{
    class ProductBusiness
    {
        private RestaurantContext productContext;

        public List<Product> GetAll()
        {
            using (productContext = new RestaurantContext())
            {
                return productContext.Products.ToList();
            }
        }

        public Product Get(int id)
        {
            using (productContext = new RestaurantContext())
            {
                return productContext.Products.Find(id);
            }
        }

        public void Add(Product product)
        {
            using (productContext = new RestaurantContext())
            {
                productContext.Products.Add(product);
                productContext.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (productContext = new RestaurantContext())
            {
                var item = productContext.Products.Find(product.Id);
                if (item != null)
                {
                    productContext.Entry(item).CurrentValues.SetValues(product);
                    productContext.SaveChanges();
                }
            }
        }
    }
}
