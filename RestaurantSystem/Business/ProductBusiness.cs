using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantSystem.Data;
using RestaurantSystem.Data.Model;

namespace RestaurantSystem.Business
{
    class ProductBusiness
    {
        private RestaurantContext productBusiness;

        public List<Product> GetAll()
        {
            using (productBusiness = new RestaurantContext())
            {
                return productBusiness.Products.ToList();
            }
        }

        public Product Get(int id)
        {
            using (productBusiness = new RestaurantContext())
            {
                return productBusiness.Products.Find(id);
            }
        }

        public void Add(Product product)
        {
            using (productBusiness = new RestaurantContext())
            {
                productBusiness.Products.Add(product);
                productBusiness.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (productBusiness = new RestaurantContext())
            {
                var product = productBusiness.Products.Find(id);
                if (product != null)
                {
                    productBusiness.Products.Remove(product);
                    productBusiness.SaveChanges();
                }
            }
        }

        public void Update(Product product)
        {
            using (productBusiness = new RestaurantContext())
            {
                var item = productBusiness.Products.Find(product.Id);
                if (item != null)
                {
                    productBusiness.Entry(item).CurrentValues.SetValues(product);
                    productBusiness.SaveChanges();
                }
            }
        }
    }
}
