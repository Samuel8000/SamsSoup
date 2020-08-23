using SamsSoup.Data.Interfaces;
using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Data.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{Id = 1, CategoryName="Clear Soups", CategoryDescription="Clear Soups based on broths"},
                new Category{Id = 2, CategoryName="Cream Soups", CategoryDescription="Soups made with cream"},
                new Category{Id = 3, CategoryName="Chicken Soups", CategoryDescription="Soups made with chicken"}

            };
    }
}
