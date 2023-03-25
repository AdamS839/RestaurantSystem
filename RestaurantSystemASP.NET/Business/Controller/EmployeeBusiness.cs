using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantSystemASPNET.Data;
using RestaurantSystemASPNET.Data.Model;

namespace RestaurantSystemASPNET.Business
{
    public class EmployeeBusiness
    {
        private RestaurantContext employeeContext;

        /// <summary>
        /// Returns a list of all employees
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAll()
        {
            using(employeeContext = new RestaurantContext())
            {
                return employeeContext.Employees.ToList();
            }
        }

        /// <summary>
        /// Finds the employee with the specified id and returns it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee Get(int id)
        {
            using (employeeContext = new RestaurantContext())
            {
                return employeeContext.Employees.Find(id);
            }
        }

        /// <summary>
        /// Adds an employee
        /// </summary>
        /// <param name="employee"></param>
        public void Add(Employee employee)
        {
            using (employeeContext = new RestaurantContext())
            {
                employeeContext.Employees.Add(employee);
                employeeContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the employee with specified id if the employee exists, if not - no action is taken
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (employeeContext = new RestaurantContext())
            {
                var employee = employeeContext.Employees.Find(id);
                if (employee != null)
                {
                    employeeContext.Employees.Remove(employee);
                    employeeContext.SaveChanges();
                    Console.WriteLine("Employee deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Employee not found!");
                }
            }
        }

        /// <summary>
        /// Retrieves existing employee by searching the id, updates the properties and finally save the changes to the database
        /// </summary>
        /// <param name="employee"></param>
        public void Update(Employee employee)
        {
            using (employeeContext = new RestaurantContext())
            {
                var item = employeeContext.Employees.Find(employee.Id);
                if (item != null)
                {
                    employeeContext.Entry(item).CurrentValues.SetValues(employee);
                    employeeContext.SaveChanges();
                }
            }
        }

    }
}
