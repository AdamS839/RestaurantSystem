using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.Model
{
    public class Table
    {
        public Table(int id, string tableform, bool reserved)
        {
            this.Id = id;
            this.TableForm = tableform;
            this.Reserved = reserved;
        }

        public Table() { }

        public int Id { get; set; }
        public string TableForm { get; set; }
        public bool Reserved { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}