using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SoupId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Soup Soup { get; set; }
        public Order Order { get; set; }
    }
}
