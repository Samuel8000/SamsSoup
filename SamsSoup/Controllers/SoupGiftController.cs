using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamsSoup.Data.Interfaces;
using SamsSoup.Models;

namespace SamsSoup.Controllers
{
    public class SoupGiftController : Controller
    {
        private readonly ISoupRepository _soupRepository;
        private readonly IOrderRepository _orderRepository;

        public SoupGiftController(ISoupRepository soupRepository, IOrderRepository orderRepository)
        {
            _soupRepository = soupRepository;
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Index(SoupGiftOrder soupGiftOrder)
        {
            var soupOfTheWeek = _soupRepository.SoupsOfTheWeek.FirstOrDefault();
            if(soupOfTheWeek != null)
            {
                soupGiftOrder.Soup = soupOfTheWeek;
                _orderRepository.CreateSoupGiftOrder(soupGiftOrder);
                return RedirectToAction("SoupGiftOrderComplete");
            }
            return View();
        }

        public IActionResult SoupGiftOrderComplete()
        {
            ViewBag.SoupGiftOrderCompleteMessage = HttpContext.User.Identity.Name + ", thanks for ordering";
            return View();
        }
    }
}
