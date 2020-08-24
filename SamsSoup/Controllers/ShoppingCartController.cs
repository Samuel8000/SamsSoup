using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamsSoup.Data.Interfaces;
using SamsSoup.Models;
using SamsSoup.ViewModels;

namespace SamsSoup.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ISoupRepository _soupRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ISoupRepository soupRepository, ShoppingCart shoppingCart)
        {
            _soupRepository = soupRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int soupId)
        {
            var selectedSoup = _soupRepository.AllSoups.FirstOrDefault(s => s.Id == soupId);

            if(selectedSoup != null)
            {
                _shoppingCart.AddToCart(selectedSoup, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int soupId)
        {
            var selectedSoup = _soupRepository.AllSoups.FirstOrDefault(s => s.Id == soupId);

            if(selectedSoup != null)
            {
                _shoppingCart.RemoveFromCart(selectedSoup);
            }
            return RedirectToAction("Index");
        }
    }
}
