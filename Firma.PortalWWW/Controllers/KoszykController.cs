using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.PortalWWW.Models.BusinessLogic;
using Firma.PortalWWW.Models.Sklep;
using Microsoft.AspNetCore.Mvc;

namespace Firma.PortalWWW.Controllers
{
    public class KoszykController : Controller
    {
        private readonly HotelContext _context;
        public KoszykController(HotelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            KoszykB koszyk = new KoszykB(_context, this.HttpContext);
            DaneDoKoszyka daneDoKoszyka = new DaneDoKoszyka
            {
                ElementyKoszyka = await koszyk.GetElementKoszyka(),
                Razem = await koszyk.GetRazem()
            };
            return View(daneDoKoszyka);
        }

        public async Task<ActionResult> DodajDoKoszyka(int id)
        {
            KoszykB koszyk = new KoszykB(_context, this.HttpContext);
            koszyk.DodajDoKoszyka(await _context.Towar.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
