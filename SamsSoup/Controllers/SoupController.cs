using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        public SoupController(ISoupRepository soupRepository, ICategoryRepository categoryRepository)
        {
            _soupRepository = soupRepository;
            _categoryRepository = categoryRepository;
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

        public IActionResult Details(int id)
        {
            var soup = _soupRepository.GetSoupById(id);
            if (soup == null) return NotFound();
            return View(soup);
        }
    }
}
