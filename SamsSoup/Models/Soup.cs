using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Models
{
    public class Soup
    {
        public int Id { get; set; }
        public string SoupName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        //public string ImageFilePath { get; set; }
        public bool IsSoupOfTheWeek { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
