using ECommerce.Domain.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class UserFavorite
    {
        public int ProductId { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
