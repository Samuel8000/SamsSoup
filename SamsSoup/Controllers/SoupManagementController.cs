using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SamsSoup.Data.Interfaces;
using SamsSoup.Models;
using SamsSoup.ViewModels;

namespace SamsSoup.Controllers
{

    public class SoupManagementController : Controller
    {
        private readonly ISoupRepository _soupRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SoupManagementController(ISoupRepository soupRepository, ICategoryRepository categoryRepository)
        {
            _soupRepository = soupRepository;
            _categoryRepository = categoryRepository;
        }
        public ViewResult Index()
        {
            var pies = _soupRepository.AllSoups.OrderBy(p => p.Id);
            return View(pies);
        }

        public IActionResult AddSoup()
        {
            var categories = _categoryRepository.AllCategories;
            var soupEditViewModel = new SoupEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.Id.ToString() }).ToList(),
                CategoryId = categories.FirstOrDefault().Id
            };
            return View(soupEditViewModel);
        }

        [HttpPost]
        public IActionResult AddSoup(SoupEditViewModel soupEditViewModel)
        {
            //Basic validation
            if (ModelState.IsValid)
            {
                _soupRepository.CreateSoup(soupEditViewModel.Soup);
                return RedirectToAction("Index");
            }
            return View(soupEditViewModel);
        }

        public IActionResult EditSoup(int soupId)
        {
            var categories = _categoryRepository.AllCategories;

            var soup = _soupRepository.AllSoups.FirstOrDefault(p => p.Id == soupId);

            var soupEditViewModel = new SoupEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.Id.ToString() }).ToList(),
                Soup = soup,
                CategoryId = soup.CategoryId
            };

            var item = soupEditViewModel.Categories.FirstOrDefault(c => c.Value == soup.CategoryId.ToString());
            item.Selected = true;

            return View(soupEditViewModel);
        }

        [HttpPost]
        public IActionResult EditSoup(SoupEditViewModel soupEditViewModel)
        {
            soupEditViewModel.Soup.CategoryId = soupEditViewModel.CategoryId;

            if (ModelState.IsValid)
            {
                _soupRepository.UpdateSoup(soupEditViewModel.Soup);
                return RedirectToAction("Index");
            }
            return View(soupEditViewModel);
        }

        [HttpPost]
        public IActionResult DeleteSoup(string soupId)
        {
            return View();
        }

        public IActionResult QuickEdit()
        {
            var soupNames = _soupRepository.AllSoups.Select(s => s.SoupName).ToList();
            return View(soupNames);
        }

        [HttpPost]
        public IActionResult QuickEdit(List<string> soups)
        {
            var soupNames = _soupRepository.AllSoups.Select(s => s.SoupName).ToList();

            for (var i = 0; i < soupNames.Count; i++)
            {
                soupNames[i] = soups[i];
            }

            _soupRepository.UpdateSoupNames(soups);
            return View(soups);
        }

        //[HttpPost]
        //public IActionResult QuickEdit(List<string> soups)
        //{
        //    var soupNames = _soupRepository.AllSoups.Select(s => s.SoupName).ToList();


        //    for (var i = 0; i < soupNames.Count; i++)
        //    {
        //        soupNames[i].Add
        //    }
        //    return View(soups);
        //}
    }
}
