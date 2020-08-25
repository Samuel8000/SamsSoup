using Microsoft.AspNetCore.Mvc.Rendering;
using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.ViewModels
{
    public class SoupEditViewModel
    {
        public Soup Soup { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
    }
}
