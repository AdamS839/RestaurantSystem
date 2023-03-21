using RestaurantSystem.Business;
using RestaurantSystem.Data;
using RestaurantSystem.Data.Model;
using System.Globalization;
using RestaurantSystem.Display;

namespace RestaurantSystem.Display
{
    public class DisplaySystem
    {
        public DisplaySystem()
        {
            Input();
        }

        /// <summary>
        /// Main method that calls each display
        /// </summary>
        private void Input()
        {
            while (true)
            {
                Console.Clear();
                DefaultDisplayMenu();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 1:
                        Console.Clear();
                        EmployeeDisplay employeeDisplay = new EmployeeDisplay();
                        break;
                    case 2:
                        Console.Clear();
                        JobDisplay jobDisplay = new JobDisplay();
                        break;
                    case 3:
                        Console.Clear();
                        TableDisplay tableDisplay = new TableDisplay();
                        break;
                    case 4:
                        Console.Clear();
                        OrderDisplay orderDisplay = new OrderDisplay();
                        break;
                    case 5:
                        Console.Clear();
                        ProductDisplay productDisplay = new ProductDisplay();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        /// <summary>
        /// Main menu for the display
        /// </summary>
        static void DefaultDisplayMenu()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(new string('=', 13) + " Restaurant System Menu " + new string('=', 13));
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("1. Employees");
            Console.WriteLine("2. Jobs");
            Console.WriteLine("3. Tables");
            Console.WriteLine("4. Orders");
            Console.WriteLine("5. Products");
            Console.WriteLine("9. Exit");
            Console.WriteLine(new string('=', 50));
        }
    }
}
