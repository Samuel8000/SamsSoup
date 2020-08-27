using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamsSoup.Data.Interfaces;
using SamsSoup.Models;
using SamsSoup.ViewModels;

namespace SamsSoup.Controllers
{
    public class SoupController : Controller
    {
        private readonly ISoupRepository _soupRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISoupReviewRepository _soupReviewRepository;
        private readonly HtmlEncoder _htmlEncoder;

        public SoupController(ISoupRepository soupRepository, ICategoryRepository categoryRepository, ISoupReviewRepository soupReviewRepository, HtmlEncoder htmlEncoder)
        {
            _soupRepository = soupRepository;
            _categoryRepository = categoryRepository;
            _soupReviewRepository = soupReviewRepository;
            _htmlEncoder = htmlEncoder;
        }

        //public ViewResult List()
        //{
        //    SoupsListViewModel soupsListViewModel = new SoupsListViewModel();
        //    soupsListViewModel.Soups = _soupRepository.AllSoups;
        //    soupsListViewModel.CurrentCategory = "Clear Soups";

        //    return View(soupsListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Soup> soups;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                soups = _soupRepository.AllSoups.OrderBy(s => s.Id);
                currentCategory = "All Soups";
            }
            else
            {
                soups = _soupRepository.AllSoups.Where(p => p.Category.CategoryName == category).OrderBy(s => s.Id);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new SoupsListViewModel
            {
                Soups = soups,
                CurrentCategory = currentCategory
            });

        }

        [Route("{controller}/Details/{id}")]
        public IActionResult Details(int id)
        {
            var soup = _soupRepository.GetSoupById(id);
            if (soup == null) return NotFound();
            return View(soup);
        }
        [Route("{controller}/Details/{id}")]
        [HttpPost]
        public IActionResult Details (int id, string review)
        {
            var soup = _soupRepository.GetSoupById(id);
            if (soup == null) return NotFound();

            string encodedReview = _htmlEncoder.Encode(review);
            _soupReviewRepository.AddSoupReview(new SoupReview() { Soup = soup, Review = encodedReview });

            return View(new SoupDetailViewModel() { Soup = soup });
        }
    }
}
