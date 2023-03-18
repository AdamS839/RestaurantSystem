using RestaurantSystem.Business;
using RestaurantSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Display
{
    public class OrderDisplay
    {
        private static OrderBusiness orderBusiness = new OrderBusiness();

        /// <summary>
        /// Calling the main display method for orders
        /// </summary>
        public OrderDisplay() 
        {
            orderBusiness = new OrderBusiness();
            OrderDisplayMenu();
        }

        /// <summary>
        ///  Main display menu for orders, calling each method
        /// </summary>
        static void OrderDisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                OrderDisplayData();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.Clear();
                        ListOrders();
                        break;
                    case 2:
                        AddOrder();
                        break;
                    case 3:
                        RemoveOrder();
                        break;
                    case 4:
                        Console.Clear();
                        GetOrder();
                        break;
                    case 5:
                        Console.Clear();
                        UpdateOrder();
                        break;
                    default:
                        Console.Clear();
                        OrderDisplayData();
                        break;
                }
            }
        }

        /// <summary>
        /// Order display data menu
        /// </summary>
        static void OrderDisplayData()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(new string('=', 9) + " Order Menu " + new string('=', 9));
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("1. List all orders");
            Console.WriteLine("2. Add order");
            Console.WriteLine("3. Remove order");
            Console.WriteLine("4. Get order by id");
            Console.WriteLine("5. Update order");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 30));
        }

        /// <summary>
        /// Lists all orders added
        /// </summary>
        static void ListOrders()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 12) + " Order List " + new string('=', 12));
            Console.WriteLine(new string('=', 40));
            var orders = orderBusiness.GetAll();
            Console.WriteLine("ID Name Salary");
            foreach (var item in orders)
            {
                Console.WriteLine("{0}. {1} {2} {3}", item.Id, item.TableId, item.ProductId, item.Quantity);
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }

        /// <summary>
        /// Adds order
        /// </summary>
        static void AddOrder()
        {
            Order order = new Order();
            Console.WriteLine("Ënter table id: ");
            order.TableId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product id: ");
            order.ProductId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity: ");
            order.Quantity = int.Parse(Console.ReadLine());
            orderBusiness.Add(order);
            Console.WriteLine("Order added successfully!");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Removes order by id
        /// </summary>
        static void RemoveOrder()
        {
            Order order = new Order();
            Console.WriteLine("Enter order ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            orderBusiness.Delete(id);
            Console.WriteLine("Order deleted successfully!");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Gets information for order by id
        /// </summary>
        static void GetOrder()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 12) + " Get order by id " + new string('=', 11));
            Console.WriteLine(new string('=', 41));
            Console.WriteLine("Enter Id to find order: ");
            int id = int.Parse(Console.ReadLine());
            Order order = orderBusiness.Get(id);
            if (order != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + order.Id);
                Console.WriteLine("Table ID: " + order.TableId);
                Console.WriteLine("Product ID: " + order.ProductId);
                Console.WriteLine("Quantity: " + order.Quantity);
                Console.WriteLine(new string('=', 20));
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Updates information for order by id
        /// </summary>
        static void UpdateOrder()
        {
            Console.WriteLine("Enter order ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Order order = orderBusiness.Get(id);
            if (order != null)
            {
                Console.WriteLine("Enter table ID: ");
                order.TableId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter product ID: ");
                order.ProductId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter quantity: ");
                orderBusiness.Update(order);
                Console.WriteLine("Order updated successfully.");
            }
            else
            {
                Console.WriteLine("Order not found.");
            }
            Thread.Sleep(4000);
        }
    }
}
