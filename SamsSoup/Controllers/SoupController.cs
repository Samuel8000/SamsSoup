using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamsSoup.Data.Interfaces;
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

        public ViewResult List()
        {
            SoupsListViewModel soupsListViewModel = new SoupsListViewModel();
            soupsListViewModel.Soups = _soupRepository.AllSoups;
            soupsListViewModel.CurrentCategory = "Clear Soups";

            return View(soupsListViewModel);
        }
    }
}
