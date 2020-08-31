using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SamsSoup.Data.Interfaces;
using SamsSoup.ViewModels;

namespace SamsSoup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISoupRepository _soupRepository;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        public HomeController(ISoupRepository soupRepository, IStringLocalizer<HomeController> stringLocalizer)
        {
            _soupRepository = soupRepository;
            _stringLocalizer = stringLocalizer;
        }
        public IActionResult Index()
        {
            ViewData["PageTitle"] = _stringLocalizer["Welcome to Sam's Soup Shop"];
            var homeViewModel = new HomeViewModel
            {
                SoupsOfTheWeek = _soupRepository.SoupsOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
