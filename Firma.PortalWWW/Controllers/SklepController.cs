using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly HotelContext _context;
        public SklepController(HotelContext context)
        {
            _context = context; // tu inicjalizujemy baze danych
        }
        public async Task<IActionResult> Index(int? id)//w id bedzie przechowywany id rodzaju ktorego towary mamy wyswietlic
        {
            //do viewbag zapisuje wszytskie rodzaje z bazy danych asynchronicznie
            ViewBag.Rodzaje = await _context.Rodzaj.ToListAsync();
            //przy pierwszym uruchomieniu sklepu nie ma , wiec po rodzaj podstawimy pierwszy rodzaj z bazy danych
            if (id == null)
            {
                var pierwszy = await _context.Rodzaj.FirstAsync();
                id = pierwszy.IdRodzaju;
            }
            //do widoku przekazuje wszystkie towary danego rodzaju ktorego mamy id 
            return View(await _context.Towar.Where(t=>t.IdRodzaju==id).ToListAsync());
        }
        //funkcja zwraca do widoku towar o id danym jako parametr
        public async Task<IActionResult> Szczegoly(int id)
        {
            ViewBag.Rodzaje = await _context.Rodzaj.ToListAsync();
            return View(await _context.Towar.Where(t=>t.IdTowaru==id).FirstOrDefaultAsync());
        }
    }
}
