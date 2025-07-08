using ECommerce.Domain.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; } // Primary key
        public int CustomerId { get; set; } // Foreign key to Customer
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Status { get; set; } // e.g., "Active", "Inactive"

        public virtual ApplicationUser Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
