using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Firma.Intranet.Controllers
{
    public class TowarController : Controller
    {
        private readonly HotelContext _context;

        public TowarController(HotelContext context)
        {
            _context = context;
        }

        // GET: Towars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Towar.ToListAsync());
        }

        // GET: Towars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var towar = await _context.Towar
                .FirstOrDefaultAsync(m => m.IdTowaru == id);
            if (towar == null)
            {
                return NotFound();
            }

            return View(towar);
        }

        // GET: Towars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Towars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTowaru,Nazwa,Cena,UrlZdjecia,Opis,KrotkiOpis,IdRodzaju")] Towar towar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(towar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(towar);
        }

        // GET: Towars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var towar = await _context.Towar.FindAsync(id);
            if (towar == null)
            {
                return NotFound();
            }
            return View(towar);
        }

        // POST: Towars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTowaru,Nazwa,Cena,UrlZdjecia,Opis,KrotkiOpis,IdRodzaju")] Towar towar)
        {
            if (id != towar.IdTowaru)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(towar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TowarExists(towar.IdTowaru))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(towar);
        }

        // GET: Towars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var towar = await _context.Towar
                .FirstOrDefaultAsync(m => m.IdTowaru == id);
            if (towar == null)
            {
                return NotFound();
            }

            return View(towar);
        }

        // POST: Towars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var towar = await _context.Towar.FindAsync(id);
            _context.Towar.Remove(towar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TowarExists(int id)
        {
            return _context.Towar.Any(e => e.IdTowaru == id);
        }
    }
}
