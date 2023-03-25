using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.Model
{
    public class Order
    {
        public Order(int quantity, int tableId, int productid) : base()
        {
            this.ProductId = productid;
            this.Quantity = quantity;
            this.TableId = tableId;
        }

        public Order() { }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public Product Product { get; set; }

    }
}