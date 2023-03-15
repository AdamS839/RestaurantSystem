using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Table> Tables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RestaurantDB;Integrated Security=True");
            }
        }

    }
}