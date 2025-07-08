using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; } // Primary key
        public int Quantity { get; set; } // Quantity of the product in the order
        public decimal SubTotal { get; set; } // Price of the product at the time of order
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; } // Foreign key to Product
        public virtual Order Order { get; set; } // Navigation property to the Order entity
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; } // Foreign key to Order
    }
}
