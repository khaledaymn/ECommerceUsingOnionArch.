using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       
        public virtual ICollection<OfferProduct> OfferProducts { get; } = new List<OfferProduct>();
        public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }
}
