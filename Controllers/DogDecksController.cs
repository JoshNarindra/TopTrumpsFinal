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
    public class DogDecksController : Controller
    {
        private readonly TopTrumpsFinalContext _context;

        public DogDecksController(TopTrumpsFinalContext context)
        {
            _context = context;
        }

        // GET: DogDecks
        public async Task<IActionResult> Index()
        {
              return View(await _context.DogDeck.ToListAsync());
        }

        // GET: DogDecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DogDeck == null)
            {
                return NotFound();
            }

            var dogDeck = await _context.DogDeck
                .FirstOrDefaultAsync(m => m.DogDeckID == id);
            if (dogDeck == null)
            {
                return NotFound();
            }

            return View(dogDeck);
        }

        // GET: DogDecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DogDecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DogDeckID,Size,Rarity,GoodTemper,Cuteness,Rating,Name,ImageLink,Description")] DogDeck dogDeck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogDeck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogDeck);
        }

        // GET: DogDecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DogDeck == null)
            {
                return NotFound();
            }

            var dogDeck = await _context.DogDeck.FindAsync(id);
            if (dogDeck == null)
            {
                return NotFound();
            }
            return View(dogDeck);
        }

        // POST: DogDecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DogDeckID,Size,Rarity,GoodTemper,Cuteness,Rating,Name,ImageLink,Description")] DogDeck dogDeck)
        {
            if (id != dogDeck.DogDeckID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogDeck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogDeckExists(dogDeck.DogDeckID))
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
            return View(dogDeck);
        }

        // GET: DogDecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DogDeck == null)
            {
                return NotFound();
            }

            var dogDeck = await _context.DogDeck
                .FirstOrDefaultAsync(m => m.DogDeckID == id);
            if (dogDeck == null)
            {
                return NotFound();
            }

            return View(dogDeck);
        }

        // POST: DogDecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DogDeck == null)
            {
                return Problem("Entity set 'TopTrumpsFinalContext.DogDeck'  is null.");
            }
            var dogDeck = await _context.DogDeck.FindAsync(id);
            if (dogDeck != null)
            {
                _context.DogDeck.Remove(dogDeck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogDeckExists(int id)
        {
          return _context.DogDeck.Any(e => e.DogDeckID == id);
        }
    }
}
