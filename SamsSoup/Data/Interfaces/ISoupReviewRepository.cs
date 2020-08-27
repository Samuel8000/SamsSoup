using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Data.Interfaces
{
    public interface ISoupReviewRepository
    {
        void AddSoupReview(SoupReview soupReview);
        IEnumerable<SoupReview> GetSoupReviewsForPie(int soupId);
    }
}
