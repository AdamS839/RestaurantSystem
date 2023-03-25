using RestaurantSystem.Business;
using RestaurantSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Display
{
    public class ProductDisplay
    {
        private static ProductBusiness productBusiness = new ProductBusiness();

        /// <summary>
        /// Calling the main display method for products
        /// </summary>
        public ProductDisplay() 
        {
            productBusiness = new ProductBusiness();
            ProductDisplayMenu();
        }
        
        /// <summary>
        /// Main display menu for products, calling each method
        /// </summary>
        public void ProductDisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                ProductDisplayData();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.Clear();
                        ListProducts();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        RemoveProduct();
                        break;
                    case 4:
                        Console.Clear();
                        GetProduct();
                        break;
                    case 5:
                        UpdateProduct();
                        break;
                    default:
                        Console.Clear();
                        ProductDisplayData();
                        break;
                }
            }
        }

        /// <summary>
        /// Product display data menu
        /// </summary>
        static void ProductDisplayData()
        {
            Console.WriteLine(new string('=', 32));
            Console.WriteLine(new string('=', 9) + " Product Menu " + new string('=', 9));
            Console.WriteLine(new string('=', 32));
            Console.WriteLine("1. List all products");
            Console.WriteLine("2. Add product");
            Console.WriteLine("3. Remove product");
            Console.WriteLine("4. Get product by id");
            Console.WriteLine("5. Update product");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 32));
        }

        /// <summary>
        /// Lists all products added
        /// </summary>
        static void ListProducts()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 13) + " Product List " + new string('=', 13));
            Console.WriteLine(new string('=', 40));
            var products = productBusiness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine("{0}. {1} - Price: {2} ", item.ProductId, item.Name, item.Price);
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }

        /// <summary>
        /// Adds product
        /// </summary>
        static void AddProduct()
        {
            Product product = new Product();
            Console.WriteLine("Enter product name: ");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            product.Price = decimal.Parse(Console.ReadLine());
            productBusiness.Add(product);
            Console.WriteLine("Product added successfully!");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Removes product by id
        /// </summary>
        static void RemoveProduct()
        {
            Product product = new Product();
            Console.WriteLine("Enter product ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            productBusiness.Delete(id);
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Finds the product id and if the product exists, information about the product is displayed
        /// </summary>
        static void GetProduct()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 11) + " Get product by id " + new string('=', 11));
            Console.WriteLine(new string('=', 41));
            Console.WriteLine("Enter Id to find product: ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + product.ProductId);
                Console.WriteLine("Name: " + product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine(new string('=', 20));
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Updates information about product by id
        /// </summary>
        static void UpdateProduct()
        {
            Console.WriteLine("Enter product ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine("Enter name: ");
                product.Name = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                product.Price = decimal.Parse(Console.ReadLine());
                productBusiness.Update(product);
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
            Thread.Sleep(4000);
        }

    }
}
