using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.Model
{
    public class Job
    {
        public Job(int id, string name, decimal salary)
        {
            this.Id = id;
            this.Name = name;
            this.Salary = salary;
        }

        public Job() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}