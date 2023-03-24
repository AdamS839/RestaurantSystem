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
        public Product(int id, int orderId, string name, decimal price)
        {
            OrderId = orderId;
            Name = name;
            Price = price;
        }

        public Product() { }
        
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }

    }
}