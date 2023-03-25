using RestaurantSystem.Business;
using RestaurantSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Display
{
    public class TableDisplay
    {
        private static TableBusiness tableBusiness = new TableBusiness();

        /// <summary>
        /// Calling the main display method for tables
        /// </summary>
        public TableDisplay() 
        {
            tableBusiness = new TableBusiness();
            TableDisplayMenu();
        }

        /// <summary>
        ///  Main display menu for tables, calling each method
        /// </summary>
        static void TableDisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                TableDisplayData();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.Clear();
                        ListTables();
                        break;
                    case 2:
                        AddTable();
                        break;
                    case 3:
                        RemoveTable();
                        break;
                    case 4:
                        Console.Clear();
                        GetTable();
                        break;
                    case 5:
                        UpdateTable();
                        break;
                    default:
                        Console.Clear();
                        TableDisplayData();
                        break;
                }
            }
        }

        /// <summary>
        /// Table display data menu
        /// </summary>
        static void TableDisplayData()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(new string('=', 9) + " Table Menu " + new string('=', 9));
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("1. List all tables");
            Console.WriteLine("2. Add table");
            Console.WriteLine("3. Remove table");
            Console.WriteLine("4. Get table by id");
            Console.WriteLine("5. Update table");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 30));
        }

        /// <summary>
        /// Lists all tables added
        /// </summary>
        static void ListTables()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 14) + " Table List " + new string('=', 14));
            Console.WriteLine(new string('=', 40));
            var tables = tableBusiness.GetAll();
            foreach (var item in tables)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Table form: " + item.TableForm);
                Console.WriteLine("Reserved: " + item.Reserved);
                Console.WriteLine("Waiter Id: " + item.EmployeeId);
                Console.WriteLine();
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }

        /// <summary>
        /// Adds table
        /// </summary>
        static void AddTable()
        {
            Table table = new Table();
            Console.WriteLine("Ënter table form: ");
            table.TableForm = Console.ReadLine();
            Console.WriteLine("Enter reservation: ");
            table.Reserved = Console.ReadLine();
            Console.WriteLine("Enter waiter id: ");
            table.EmployeeId = int.Parse(Console.ReadLine());
            tableBusiness.Add(table);
            Console.WriteLine("Table added successfully!");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Removes table by id
        /// </summary>
        static void RemoveTable()
        {
            Table table = new Table();
            Console.WriteLine("Enter table ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            tableBusiness.Delete(id);
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Finds the table id and if the table exists, the information about the table is displayed
        /// </summary>
        static void GetTable()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 12) + " Get table by id " + new string('=', 12));
            Console.WriteLine(new string('=', 41));
            Console.WriteLine("Enter Id to find table: ");
            int id = int.Parse(Console.ReadLine());
            Table table = tableBusiness.Get(id);
            if (table != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + table.Id);
                Console.WriteLine("Table form: " + table.TableForm);
                Console.WriteLine("Reserved: " + table.Reserved);
                Console.WriteLine("Waiter ID: " + table.EmployeeId);
                Console.WriteLine(new string('=', 20));
            }
            else
            {
                Console.WriteLine("Table not found!");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Updates information about table by id
        /// </summary>
        static void UpdateTable()
        {
            Console.WriteLine("Enter table ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Table table = tableBusiness.Get(id);
            if (table != null)
            {
                Console.WriteLine("Enter table form: ");
                table.TableForm = Console.ReadLine();
                Console.WriteLine("Enter reservation: ");
                table.Reserved = Console.ReadLine();
                Console.WriteLine("Enter waiter ID: ");
                table.EmployeeId = int.Parse(Console.ReadLine());
                tableBusiness.Update(table);
                Console.WriteLine("Table updated successfully!");
            }
            else
            {
                Console.WriteLine("Table not found.");
            }
            Thread.Sleep(4000);
        }

    }
}
