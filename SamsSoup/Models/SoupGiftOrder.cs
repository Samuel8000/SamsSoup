using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Models
{
    public class SoupGiftOrder
    {
        [BindNever]
        public int Id { get; set; }
        public Soup Soup { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the address")]
        [StringLength(100)]
        public string Address { get; set; }

    }
}
