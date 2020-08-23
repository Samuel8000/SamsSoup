using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.ViewModels
{
    public class SoupsListViewModel
    {
        public IEnumerable<Soup> Soups { get; set; }
        public string CurrentCategory { get; set; }
    }
}
