using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserPaymentMethod> CustomerPaymentMethods { get; set; } = new List<UserPaymentMethod>();
    }
}
