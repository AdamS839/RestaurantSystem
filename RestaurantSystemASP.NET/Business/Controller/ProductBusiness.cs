using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantSystemASPNET.Data;
using RestaurantSystemASPNET.Data.Model;

namespace RestaurantSystemASPNET.Business
{
    public class ProductBusiness
    {
        private RestaurantContext productContext;

        /// <summary>
        /// Returns a list of all products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAll()
        {
            using (productContext = new RestaurantContext())
            {
                return productContext.Products.ToList();
            }
        }

        /// <summary>
        /// Finds the product with the specified id and returns it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product Get(int id)
        {
            using (productContext = new RestaurantContext())
            {
                return productContext.Products.Find(id);
            }
        }

        /// <summary>
        /// Adds a product
        /// </summary>
        /// <param name="product"></param>
        public void Add(Product product)
        {
            using (productContext = new RestaurantContext())
            {
                productContext.Products.Add(product);
                productContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the product with specified id if the job exists, if not - no action is taken
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (productContext = new RestaurantContext())
            {
                var product = productContext.Products.Find(id);
                if (product != null)
                {
                    productContext.Products.Remove(product);
                    productContext.SaveChanges();
                    Console.WriteLine("Product deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Product not found!");
                }
            }
        }

        /// <summary>
        /// Retrieves existing product by searching the id, updates the properties and finally save the changes to the database
        /// </summary>
        /// <param name="product"></param>
        public void Update(Product product)
        {
            using (productContext = new RestaurantContext())
            {
                var item = productContext.Products.Find(product.ProductId);
                if (item != null)
                {
                    productContext.Entry(item).CurrentValues.SetValues(product);
                    productContext.SaveChanges();
                }
            }
        }

    }
}
