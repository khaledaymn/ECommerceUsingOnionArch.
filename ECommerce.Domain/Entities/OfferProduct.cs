using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class OfferProduct
    {
        [ForeignKey(nameof(Offer))]
        public int OfferId { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; } 
        public Product Product { get; set; }
        public Offer Offer { get; set; }
    }
}
