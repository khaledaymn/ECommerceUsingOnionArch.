using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; } // Primary key
        public string? Name { get; set; }
        public string? Description { get; set; }
       
        public virtual ICollection<Product> Products { get; } = new List<Product>();
    }
}
