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
    public class StarWarsDecksController : Controller
    {
        private readonly TopTrumpsFinalContext _context;

        public StarWarsDecksController(TopTrumpsFinalContext context)
        {
            _context = context;
        }

        // GET: StarWarsDecks
        public async Task<IActionResult> Index()
        {
              return View(await _context.StarWarsDeck.ToListAsync());
        }

        // GET: StarWarsDecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StarWarsDeck == null)
            {
                return NotFound();
            }

            var starWarsDeck = await _context.StarWarsDeck
                .FirstOrDefaultAsync(m => m.StarWarsDeckID == id);
            if (starWarsDeck == null)
            {
                return NotFound();
            }

            return View(starWarsDeck);
        }

        // GET: StarWarsDecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StarWarsDecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StarWarsDeckID,Size,Speed,FirePower,Maneuvering,ForceFactor,Name,ImageLink,Description")] StarWarsDeck starWarsDeck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(starWarsDeck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starWarsDeck);
        }

        // GET: StarWarsDecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StarWarsDeck == null)
            {
                return NotFound();
            }

            var starWarsDeck = await _context.StarWarsDeck.FindAsync(id);
            if (starWarsDeck == null)
            {
                return NotFound();
            }
            return View(starWarsDeck);
        }

        // POST: StarWarsDecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StarWarsDeckID,Size,Speed,FirePower,Maneuvering,ForceFactor,Name,ImageLink,Description")] StarWarsDeck starWarsDeck)
        {
            if (id != starWarsDeck.StarWarsDeckID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starWarsDeck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarWarsDeckExists(starWarsDeck.StarWarsDeckID))
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
            return View(starWarsDeck);
        }

        // GET: StarWarsDecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StarWarsDeck == null)
            {
                return NotFound();
            }

            var starWarsDeck = await _context.StarWarsDeck
                .FirstOrDefaultAsync(m => m.StarWarsDeckID == id);
            if (starWarsDeck == null)
            {
                return NotFound();
            }

            return View(starWarsDeck);
        }

        // POST: StarWarsDecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StarWarsDeck == null)
            {
                return Problem("Entity set 'TopTrumpsFinalContext.StarWarsDeck'  is null.");
            }
            var starWarsDeck = await _context.StarWarsDeck.FindAsync(id);
            if (starWarsDeck != null)
            {
                _context.StarWarsDeck.Remove(starWarsDeck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarWarsDeckExists(int id)
        {
          return _context.StarWarsDeck.Any(e => e.StarWarsDeckID == id);
        }
    }
}
