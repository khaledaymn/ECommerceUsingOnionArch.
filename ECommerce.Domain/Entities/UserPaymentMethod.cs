using ECommerce.Domain.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class UserPaymentMethod
    {
        public string? PaymentDetails { get; set; } // Details of the payment method (e.g., card number, bank account)
        public DateTime AddedDate { get; set; } // Date when the payment method was added
        [ForeignKey(nameof(User))]
        public int UserId { get; set; } // Foreign key to Customer
        public virtual ApplicationUser User { get; set; } // Navigation property to Customer
        [ForeignKey(nameof(PaymentMethod))]
        public int PaymentMethodId { get; set; } // Foreign key to PaymentMethod
        public virtual PaymentMethod PaymentMethod { get; set; } // Navigation property to PaymentMethod
    }
}
