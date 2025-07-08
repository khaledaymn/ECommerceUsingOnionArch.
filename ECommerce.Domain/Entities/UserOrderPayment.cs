using ECommerce.Domain.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class UserOrderPayment
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(Payment))]
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
