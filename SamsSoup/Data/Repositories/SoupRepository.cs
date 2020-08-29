using Microsoft.EntityFrameworkCore;
using SamsSoup.Data.Interfaces;
using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Data.Repositories
{
    public class SoupRepository : ISoupRepository
    {
        private readonly AppDbContext _appDbContext;

        public SoupRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Soup> AllSoups
        {
            get
            {
                return _appDbContext.Soups
                    .Include(c => c.Category);
            }
        }

        public IEnumerable<Soup> SoupsOfTheWeek
        {
            get
            {
                return _appDbContext.Soups
                    .Include(c => c.Category)
                    .Where(s => s.IsSoupOfTheWeek == true);
            }
        }

        public void CreateSoup(Soup soup)
        {
            _appDbContext.Soups.Add(soup);
            _appDbContext.SaveChanges();
        }

        public void DeleteSoup(Soup soup)
        {
            _appDbContext.Soups.Remove(soup);
            _appDbContext.SaveChanges();

        }

        public Soup GetSoupById(int soupId)
        {
            return _appDbContext.Soups.FirstOrDefault(s => s.Id == soupId);
        }

        public void UpdateSoup(Soup soup)
        {
            _appDbContext.Soups.Update(soup);
            _appDbContext.SaveChanges();
        }

        public void UpdateSoupNames(List<Soup> models)
        {
            _appDbContext.Soups.UpdateRange(models);
            _appDbContext.SaveChanges();

        }

    }
}
