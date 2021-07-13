using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Firma.PortalWWW.Models;
using Firma.Data.Data;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotelContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(HotelContext context)
        {
            _context = context; 
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OfertySpecjalne()
        {
            ViewBag.ModelPakiet = (
                  from item in _context.Pakiety
                  orderby item.IdPokoju
                  select item
                  ).ToList();

            return View();
        }
        public IActionResult Biznes()
        {
            return View();
        }

        public IActionResult Rezerwacje()
        {
            ViewBag.ModelPokoj = (
                  from item in _context.Pokoje
                  orderby item.IdPokoju
                  select item
                  ).ToList();

            return View();
        }
        
        public IActionResult Restauracja()
        {
            ViewBag.ModelPosilek = (
                  from item in _context.Posilki
                  orderby item.IdPosilku
                  select item
                  ).ToList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
