using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Total { get; set; } = 0;
        public string? Payment { get; set; }
        public bool? Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
