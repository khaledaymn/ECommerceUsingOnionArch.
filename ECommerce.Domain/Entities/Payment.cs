using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; } // Primary key
        public decimal Amount { get; set; } // Amount paid
        public DateTime Date { get; set; } // Date of payment
        [ForeignKey(nameof(PaymentMethod))]                                     
        public int PaymentMethodId { get; set; } // Method of payment (e.g., Credit Card, PayPal) // Foreign key
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
