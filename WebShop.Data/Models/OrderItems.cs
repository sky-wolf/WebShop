using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Data.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public int APrice { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
