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
    public class CatDecksController : Controller
    {
        private readonly TopTrumpsFinalContext _context;

        public CatDecksController(TopTrumpsFinalContext context)
        {
            _context = context;
        }

        // GET: CatDecks
        public async Task<IActionResult> Index()
        {
              return View(await _context.CatDeck.ToListAsync());
        }

        // GET: CatDecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatDeck == null)
            {
                return NotFound();
            }

            var catDeck = await _context.CatDeck
                .FirstOrDefaultAsync(m => m.CatDeckID == id);
            if (catDeck == null)
            {
                return NotFound();
            }

            return View(catDeck);
        }

        // GET: CatDecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatDecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatDeckID,Size,Rarity,GoodTemper,Cuteness,Rating,Name,ImageLink,Description")] CatDeck catDeck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catDeck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catDeck);
        }

        // GET: CatDecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatDeck == null)
            {
                return NotFound();
            }

            var catDeck = await _context.CatDeck.FindAsync(id);
            if (catDeck == null)
            {
                return NotFound();
            }
            return View(catDeck);
        }

        // POST: CatDecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatDeckID,Size,Rarity,GoodTemper,Cuteness,Rating,Name,ImageLink,Description")] CatDeck catDeck)
        {
            if (id != catDeck.CatDeckID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catDeck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatDeckExists(catDeck.CatDeckID))
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
            return View(catDeck);
        }

        // GET: CatDecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatDeck == null)
            {
                return NotFound();
            }

            var catDeck = await _context.CatDeck
                .FirstOrDefaultAsync(m => m.CatDeckID == id);
            if (catDeck == null)
            {
                return NotFound();
            }

            return View(catDeck);
        }

        // POST: CatDecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatDeck == null)
            {
                return Problem("Entity set 'TopTrumpsFinalContext.CatDeck'  is null.");
            }
            var catDeck = await _context.CatDeck.FindAsync(id);
            if (catDeck != null)
            {
                _context.CatDeck.Remove(catDeck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatDeckExists(int id)
        {
          return _context.CatDeck.Any(e => e.CatDeckID == id);
        }
    }
}
