using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamsSoup.Data.Interfaces;
using SamsSoup.ViewModels;

namespace SamsSoup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISoupRepository _soupRepository;

        public HomeController(ISoupRepository soupRepository)
        {
            _soupRepository = soupRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                SoupsOfTheWeek = _soupRepository.SoupsOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
