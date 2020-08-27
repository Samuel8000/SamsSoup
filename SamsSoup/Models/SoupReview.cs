using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Models
{
    public class SoupReview
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public int SoupId { get; set; }
        public Soup Soup { get; set; }
    }
}
