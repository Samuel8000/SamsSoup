using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public double IngredientQuantity { get; set; }
    }
}
