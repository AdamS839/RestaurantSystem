using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.Model
{
    public class Order
    {
        public Order(int id, int productId, int quantity, int tableId)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
            this.TableId = tableId;
        }

        public Order() { }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int TableId { get; set; }
        public ICollection<Product> Products { get; set; }
        public Table Table { get; set; }

    }
}