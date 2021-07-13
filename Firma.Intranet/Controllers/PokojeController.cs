using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.CMS;

namespace Firma.Intranet.Controllers
{
    public class PokojeController : Controller
    {
        private readonly HotelContext _context;

        public PokojeController(HotelContext context)
        {
            _context = context;
        }

        // GET: Pokoje
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pokoje.ToListAsync());
        }

        // GET: Pokoje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoje = await _context.Pokoje
                .FirstOrDefaultAsync(m => m.IdPokoju == id);
            if (pokoje == null)
            {
                return NotFound();
            }

            return View(pokoje);
        }

        // GET: Pokoje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokoje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPokoju,Nazwa,Powierzchnia,IloscLozek,IloscOsob,UrlZdjecia,Cena")] Pokoje pokoje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokoje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokoje);
        }

        // GET: Pokoje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoje = await _context.Pokoje.FindAsync(id);
            if (pokoje == null)
            {
                return NotFound();
            }
            return View(pokoje);
        }

        // POST: Pokoje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPokoju,Nazwa,Powierzchnia,IloscLozek,IloscOsob,UrlZdjecia,Cena")] Pokoje pokoje)
        {
            if (id != pokoje.IdPokoju)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokoje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokojeExists(pokoje.IdPokoju))
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
            return View(pokoje);
        }

        // GET: Pokoje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoje = await _context.Pokoje
                .FirstOrDefaultAsync(m => m.IdPokoju == id);
            if (pokoje == null)
            {
                return NotFound();
            }

            return View(pokoje);
        }

        // POST: Pokoje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokoje = await _context.Pokoje.FindAsync(id);
            _context.Pokoje.Remove(pokoje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokojeExists(int id)
        {
            return _context.Pokoje.Any(e => e.IdPokoju == id);
        }
    }
}
