using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.Model
{
    public class Product
    {
        public Product(int id, string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Product() { }
        
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}