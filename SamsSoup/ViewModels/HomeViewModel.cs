using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Soup> SoupsOfTheWeek { get; set; }
    }
}
