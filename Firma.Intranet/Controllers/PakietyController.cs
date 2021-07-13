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
    public class PakietyController : Controller
    {
        private readonly HotelContext _context;

        public PakietyController(HotelContext context)
        {
            _context = context;
        }

        // GET: Pakiety
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pakiety.ToListAsync());
        }

        // GET: Pakiety/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pakiety = await _context.Pakiety
                .FirstOrDefaultAsync(m => m.IdPokoju == id);
            if (pakiety == null)
            {
                return NotFound();
            }

            return View(pakiety);
        }

        // GET: Pakiety/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pakiety/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPokoju,Tytul,Czas,Posilki,IloscOsob,UrlZdjecia,Cena")] Pakiety pakiety)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pakiety);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pakiety);
        }

        // GET: Pakiety/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pakiety = await _context.Pakiety.FindAsync(id);
            if (pakiety == null)
            {
                return NotFound();
            }
            return View(pakiety);
        }

        // POST: Pakiety/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPokoju,Tytul,Czas,Posilki,IloscOsob,UrlZdjecia,Cena")] Pakiety pakiety)
        {
            if (id != pakiety.IdPokoju)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pakiety);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PakietyExists(pakiety.IdPokoju))
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
            return View(pakiety);
        }

        // GET: Pakiety/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pakiety = await _context.Pakiety
                .FirstOrDefaultAsync(m => m.IdPokoju == id);
            if (pakiety == null)
            {
                return NotFound();
            }

            return View(pakiety);
        }

        // POST: Pakiety/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pakiety = await _context.Pakiety.FindAsync(id);
            _context.Pakiety.Remove(pakiety);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PakietyExists(int id)
        {
            return _context.Pakiety.Any(e => e.IdPokoju == id);
        }
    }
}
