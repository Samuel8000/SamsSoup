using SamsSoup.Data.Interfaces;
using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Data.Repositories
{
    public class MockSoupRepository : ISoupRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Soup> AllSoups =>
            new List<Soup>
            {
                new Soup{Id=1, SoupName= "Vegetable Clear Soup", ShortDescription="Lorem Ipsum",
                    LongDescription="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.", 
                    Category = _categoryRepository.AllCategories.ToList()[0], IsSoupOfTheWeek= false},
                new Soup{Id=2, SoupName= "Mushroom Soup", ShortDescription="Lorem Ipsum",
                    LongDescription="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.", Category = _categoryRepository.AllCategories.ToList()[1], IsSoupOfTheWeek= false},
                new Soup{Id=3, SoupName= "Chicken and Chard Pasta Fagioli", ShortDescription="Lorem Ipsum",
                    LongDescription="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.", Category = _categoryRepository.AllCategories.ToList()[2], IsSoupOfTheWeek= false},
                new Soup{Id=4, SoupName= "Japanese Soup", ShortDescription="Lorem Ipsum",
                    LongDescription="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.", Category = _categoryRepository.AllCategories.ToList()[0], IsSoupOfTheWeek= true}
            };


        public IEnumerable<Soup> SoupsOfTheWeek { get; }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public void CreateSoup(Soup soup)
        {
            throw new NotImplementedException();
        }

        public Soup GetSoupById(int soupId)
        {
            return AllSoups.FirstOrDefault(s => s.Id == soupId);
        }

        public void UpdateSoup(Soup soup)
        {
            throw new NotImplementedException();
        }

        public void UpdateSoupNames(List<string> soups)
        {
            throw new NotImplementedException();
        }
    }
}
