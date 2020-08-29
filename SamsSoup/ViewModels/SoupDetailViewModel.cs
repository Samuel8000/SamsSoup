using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.ViewModels
{
    public class SoupDetailViewModel
    {
        public Soup Soup { get; set; }
        public string Review { get; set; }

        public IEnumerable<SoupReview> Reviews { get; set; }
    }
}
