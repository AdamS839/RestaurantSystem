﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.Model
{
    public class Table
    {
        public Table(int id, string tableform, string reserved)
        {
            this.TableForm = tableform;
            this.Reserved = reserved;
        }

        public Table() { }

        public int Id { get; set; }
        public string TableForm { get; set; }
        public string Reserved { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}