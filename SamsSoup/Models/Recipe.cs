using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Allergen> Allergens { get; set; }
    }
}
