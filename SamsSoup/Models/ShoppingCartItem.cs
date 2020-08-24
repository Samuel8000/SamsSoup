using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Soup Soup { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
