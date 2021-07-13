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
    public class PosilkiController : Controller
    {
        private readonly HotelContext _context;

        public PosilkiController(HotelContext context)
        {
            _context = context;
        }

        // GET: Posilki
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posilki.ToListAsync());
        }

        // GET: Posilki/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posilki = await _context.Posilki
                .FirstOrDefaultAsync(m => m.IdPosilku == id);
            if (posilki == null)
            {
                return NotFound();
            }

            return View(posilki);
        }

        // GET: Posilki/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posilki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPosilku,NazwaPolska,NazwaAngielska,UrlZdjecia")] Posilki posilki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posilki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posilki);
        }

        // GET: Posilki/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posilki = await _context.Posilki.FindAsync(id);
            if (posilki == null)
            {
                return NotFound();
            }
            return View(posilki);
        }

        // POST: Posilki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPosilku,NazwaPolska,NazwaAngielska,UrlZdjecia")] Posilki posilki)
        {
            if (id != posilki.IdPosilku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posilki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosilkiExists(posilki.IdPosilku))
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
            return View(posilki);
        }

        // GET: Posilki/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posilki = await _context.Posilki
                .FirstOrDefaultAsync(m => m.IdPosilku == id);
            if (posilki == null)
            {
                return NotFound();
            }

            return View(posilki);
        }

        // POST: Posilki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posilki = await _context.Posilki.FindAsync(id);
            _context.Posilki.Remove(posilki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosilkiExists(int id)
        {
            return _context.Posilki.Any(e => e.IdPosilku == id);
        }
    }
}
