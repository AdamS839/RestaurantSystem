using RestaurantSystem.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Display
{
    public class TableDisplay
    {
        private static TableBusiness tableBusiness = new TableBusiness();

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
                        Console.Clear();
                        UpdateTable();
                        break;
                    default:
                        Console.Clear();
                        TableDisplayData();
                        break;
                }
            }
        }

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

        static void ListTables()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 12) + " Table List " + new string('=', 12));
            Console.WriteLine(new string('=', 40));
            var tables = tableBusiness.GetAll();
            Console.WriteLine("ID Name Salary");
            foreach (var item in tables)
            {
                Console.WriteLine("{0}. {1} {2} {3}", item.Id, item.TableForm, item.Reserved, item.EmployeeId);
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }

        static void AddTable()
        {
            Table table = new Table();
            Console.WriteLine("Ënter table form: ");
            table.TableForm = Console.ReadLine();
            Console.WriteLine("Enter reservation: ");
            table.Reserved = Console.ReadLine();
            Console.WriteLine("Enter waiter ID: ");
            table.EmployeeId = int.Parse(Console.ReadLine());
            tableBusiness.Add(table);
            Console.WriteLine("Table added successfully!");
            Thread.Sleep(3000);
        }

        static void RemoveTable()
        {
            Table table = new Table();
            Console.WriteLine("Enter table ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            tableBusiness.Delete(id);
            Console.WriteLine("Table deleted successfully!");
            Thread.Sleep(3000);
        }

        static void GetTable()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 12) + " Get table by id " + new string('=', 11));
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
            Console.ReadKey();
        }

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
