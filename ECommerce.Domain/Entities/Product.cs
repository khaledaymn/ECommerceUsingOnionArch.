using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; } // Primary key
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; }
        public virtual ICollection<OfferProduct> OfferProducts { get; } = new List<OfferProduct>();
    }
}
