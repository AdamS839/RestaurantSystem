using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.Model
{
    public class Employee
    {
        public Employee(string firstname, string lastname, int age, string mail, string phone,int jobid, int managerid, DateTime hiredate) : base()
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Age = age;
            this.Mail = mail;
            this.Phone = phone;
            this.JobId = jobid;
            this.ManagerId = managerid;
            this.HireDate = hiredate;
        }

        public Employee() { }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public int JobId { get; set; }
        public int ManagerId { get; set; }
        public DateTime HireDate { get; set; }
        public Job Job { get; set; }
        public ICollection<Table> Tables { get; set; }

    }
}
