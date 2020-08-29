using SamsSoup.Data.Interfaces;
using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Data.Repositories
{
    public class SoupReviewRepository : ISoupReviewRepository
    {
        private readonly AppDbContext _appDbContext;

        public SoupReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddSoupReview(SoupReview soupReview)
        {
            _appDbContext.SoupReviews.Add(soupReview);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<SoupReview> GetSoupReviewsForPie(int soupId)
        {
            return _appDbContext.SoupReviews.Where(s => s.Soup.Id == soupId);
        }
    }
}
