using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TopTrumpsFinal.Data;
using TopTrumpsFinal.Models;

namespace TopTrumpsFinal.Controllers
{
    public class DinoDecksController : Controller
    {
        private readonly TopTrumpsFinalContext _context;

        public DinoDecksController(TopTrumpsFinalContext context)
        {
            _context = context;
        }

        // GET: DinoDecks
        public async Task<IActionResult> Index()
        {
              return View(await _context.DinoDeck.ToListAsync());
        }

        // GET: DinoDecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DinoDeck == null)
            {
                return NotFound();
            }

            var dinoDeck = await _context.DinoDeck
                .FirstOrDefaultAsync(m => m.DinoDeckID == id);
            if (dinoDeck == null)
            {
                return NotFound();
            }

            return View(dinoDeck);
        }

        // GET: DinoDecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DinoDecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DinoDeckID,Height,Weight,GoodTemper,KillerRating,Rating,Name,ImageLink,Description")] DinoDeck dinoDeck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dinoDeck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dinoDeck);
        }

        // GET: DinoDecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DinoDeck == null)
            {
                return NotFound();
            }

            var dinoDeck = await _context.DinoDeck.FindAsync(id);
            if (dinoDeck == null)
            {
                return NotFound();
            }
            return View(dinoDeck);
        }

        // POST: DinoDecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DinoDeckID,Height,Weight,GoodTemper,KillerRating,Rating,Name,ImageLink,Description")] DinoDeck dinoDeck)
        {
            if (id != dinoDeck.DinoDeckID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dinoDeck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DinoDeckExists(dinoDeck.DinoDeckID))
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
            return View(dinoDeck);
        }

        // GET: DinoDecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DinoDeck == null)
            {
                return NotFound();
            }

            var dinoDeck = await _context.DinoDeck
                .FirstOrDefaultAsync(m => m.DinoDeckID == id);
            if (dinoDeck == null)
            {
                return NotFound();
            }

            return View(dinoDeck);
        }

        // POST: DinoDecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DinoDeck == null)
            {
                return Problem("Entity set 'TopTrumpsFinalContext.DinoDeck'  is null.");
            }
            var dinoDeck = await _context.DinoDeck.FindAsync(id);
            if (dinoDeck != null)
            {
                _context.DinoDeck.Remove(dinoDeck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DinoDeckExists(int id)
        {
          return _context.DinoDeck.Any(e => e.DinoDeckID == id);
        }
    }
}
