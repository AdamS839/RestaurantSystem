﻿using RestaurantSystem.Business;
using RestaurantSystem.Data.Model;
using System;
using RestaurantSystem.Display;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Display
{
    public class EmployeeDisplay
    {
        private static EmployeeBusiness employeeBusiness = new EmployeeBusiness();

        /// <summary>
        /// Calling the main display method for employees
        /// </summary>
        public EmployeeDisplay()
        {
            employeeBusiness = new EmployeeBusiness();
            EmployeesDisplayMenu();
        }

        /// <summary>
        ///  Main display menu for employees, calling each method
        /// </summary>
        static void EmployeesDisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                EmployeesDisplayData();
                int cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.Clear();
                        ListEmployees();
                        break;
                    case 2:
                        AddEmployee();
                        break;
                    case 3:
                        RemoveEmployee();
                        break;
                    case 4:
                        Console.Clear();
                        GetEmployee();
                        break;
                    case 5:
                        UpdateEmployee();
                        break;
                    default:
                        Console.Clear();
                        EmployeesDisplayData();
                        break;
                }
            }
        }

        /// <summary>
        /// Display data menu for employees
        /// </summary>
        static void EmployeesDisplayData()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(new string('=', 7) + " Employees Menu " + new string('=', 7));
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("1. List all employees");
            Console.WriteLine("2. Add employee");
            Console.WriteLine("3. Remove employee");
            Console.WriteLine("4. Get employee by Id");
            Console.WriteLine("5. Update employee");
            Console.WriteLine("0. Back");
            Console.WriteLine(new string('=', 30));
        }

        /// <summary>
        /// Lists all employees added
        /// </summary>
        static void ListEmployees()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(new string('=', 12) + " Employee List " + new string('=', 13));
            Console.WriteLine(new string('=', 40));
            var employees = employeeBusiness.GetAll();
            foreach (var item in employees)
            {
                Console.WriteLine("ID: " + item.Id);
                Console.WriteLine("First name: " + item.FirstName);
                Console.WriteLine("Last name: " + item.LastName);
                Console.WriteLine("Age: " + item.Age);
                Console.WriteLine("Mail: " + item.Mail);
                Console.WriteLine("Phone number: " + item.Phone);
                Console.WriteLine("Job ID: " + item.JobId);
                Console.WriteLine("Manager ID: " + item.ManagerId);
                Console.WriteLine("Hire date: " + item.HireDate.ToString("dd-MM-yyyy"));
                Console.WriteLine();
            }
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }

        /// <summary>
        /// Adds new employee
        /// </summary>
        static void AddEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter first name: ");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            employee.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter email address: ");
            employee.Mail = Console.ReadLine();
            Console.WriteLine("Enter phone number: ");
            employee.Phone = Console.ReadLine();
            Console.WriteLine("Enter job id: ");
            employee.JobId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter manager id: ");
            employee.ManagerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter hire date: ");
            employee.HireDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            employeeBusiness.Add(employee);
            Console.WriteLine("Successfully added employee.");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Deletes the employee by id
        /// </summary>
        static void RemoveEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter employee ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            employeeBusiness.Delete(id);
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Finds the employee id and if the employee exists, the information about the employee is displayed
        /// </summary>
        static void GetEmployee()
        {
            Console.WriteLine(new string('=', 41));
            Console.WriteLine(new string('=', 10) + " Get employee by id " + new string('=', 10));
            Console.WriteLine(new string('=', 41));
            Console.WriteLine("Enter Id to find job: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = employeeBusiness.Get(id);
            if (employee != null)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("ID: " + employee.Id);
                Console.WriteLine("First name: " + employee.FirstName);
                Console.WriteLine("Last name: " + employee.LastName);
                Console.WriteLine("Age: " + employee.Age);
                Console.WriteLine("Mail Address: " + employee.Mail);
                Console.WriteLine("Phone number: " + employee.Phone);
                Console.WriteLine("Job ID: " + employee.JobId);
                Console.WriteLine("Manager ID: " + employee.ManagerId);
                Console.WriteLine("Hire date: " + employee.HireDate);
                Console.WriteLine(new string('=', 20));
            }
            else
            {
                Console.WriteLine("Employee not found!");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Updates information for employee by finding the id
        /// </summary>
        static void UpdateEmployee()
        {
            Console.WriteLine("Enter employee ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = employeeBusiness.Get(id);
            if (employee != null)
            {
                Console.WriteLine("Enter first name: ");
                employee.FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                employee.LastName = Console.ReadLine();
                Console.WriteLine("Enter age: ");
                employee.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter mail address: ");
                employee.Mail = Console.ReadLine();
                Console.WriteLine("Enter phone number: ");
                employee.Phone = Console.ReadLine();
                Console.WriteLine("Enter job ID: ");
                employee.JobId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter manager ID: ");
                employee.ManagerId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter hire date: ");
                employee.HireDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                employeeBusiness.Update(employee);
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

    }
}
