using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            var soups = _soupRepository.AllSoups.OrderBy(p => p.Id);
            return View(soups);
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
        public IActionResult AddSoup([Bind("Soup")]SoupEditViewModel soupEditViewModel)
        {
            //Custom Validation
            if(ModelState.GetValidationState("Soup.Price") == ModelValidationState.Valid
                && soupEditViewModel.Soup.Price < 0)
            {
                ModelState.AddModelError(nameof(soupEditViewModel.Soup.Price), "The price of the soup must be higher than zero");
            }
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
        public IActionResult DeleteSoup(int soupId)
        {
            var categories = _categoryRepository.AllCategories;

            var soup = _soupRepository.AllSoups.FirstOrDefault(s => s.Id == soupId);
            _soupRepository.DeleteSoup(soup);
            return RedirectToAction("Index");
        }
        public IActionResult QuickEdit()
        {
            var soupNames = _soupRepository.AllSoups.Select(s => s.SoupName).ToList();
            return View(soupNames);
        }

        [HttpPost]
        public IActionResult QuickEdit(List<string> soups)
        {
            var models = _soupRepository.AllSoups.ToList();

            for (var i = 0; i < models.Count; i++)
            {
                models[i].SoupName = soups[i];
            }

            _soupRepository.UpdateMultipleSoups(models);
            return View(soups);
        }
        public IActionResult BulkEditSoups()
        {
            var soups = _soupRepository.AllSoups.ToList();
            return View(soups);
        }

        [HttpPost]
        public IActionResult BulkEditSoups(List<Soup> soups)
        {
            var models = _soupRepository.AllSoups.ToList();
            for(var i = 0; i < models.Count; i++)
            {
                models[i].SoupName = soups[i].SoupName;
                models[i].Price = soups[i].Price;
                models[i].ShortDescription = soups[i].ShortDescription;
            }
            _soupRepository.UpdateMultipleSoups(models);
            return View(models);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckIfSoupNameAlreadyExists([Bind(Prefix = "Soup.SoupName")]string soupName)
        {
            var soup = _soupRepository.AllSoups.FirstOrDefault(s => s.SoupName == soupName);
            return soup == null ? Json(true) : Json("The soup name is already taken");
        }

    }
}
