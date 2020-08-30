using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SamsSoup.Models
{
    public class Soup
    {
        public int Id { get; set; }
        [Remote("CheckIfSoupNameAlreadyExists", "SoupManagement", ErrorMessage = "The soup name is already taken")]
        public string SoupName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        //public string ImageFilePath { get; set; }
        public bool IsSoupOfTheWeek { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual List<SoupReview> SoupReviews { get; set; }
    }
}
