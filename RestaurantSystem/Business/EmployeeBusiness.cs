using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantSystem.Data;
using RestaurantSystem.Data.Model;

namespace RestaurantSystem.Business
{
    public class EmployeeBusiness
    {
        private RestaurantContext employeeContext;
        

        public List<Employee> GetAll()
        {
            using(employeeContext = new RestaurantContext())
            {
                return employeeContext.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (employeeContext = new RestaurantContext())
            {
                return employeeContext.Employees.Find(id);
            }
        }

        public void Add(Employee employee)
        {
            using (employeeContext = new RestaurantContext())
            {
                employeeContext.Employees.Add(employee);
                employeeContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (employeeContext = new RestaurantContext())
            {
                var employee = employeeContext.Employees.Find(id);
                if (employee != null)
                {
                    employeeContext.Employees.Remove(employee);
                    employeeContext.SaveChanges();
                }
            }
        }

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
