using RestaurantSystemASPNET.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemASPNET.Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Table> Tables { get; set; }

        /// <summary>
        /// Managing foreign keys
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasRequired(e => e.Job)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobId);

            modelBuilder.Entity<Table>()
                .HasRequired(t => t.Employee)
                .WithMany(e => e.Tables)
                .HasForeignKey(t => t.EmployeeId);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableId);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);
        }

    }
}