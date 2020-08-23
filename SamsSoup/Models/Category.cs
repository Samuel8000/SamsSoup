using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<Soup> Soups { get; set; }
    }
}
