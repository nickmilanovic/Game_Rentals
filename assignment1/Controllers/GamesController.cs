using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment1.Data;
using assignment1.Models;

namespace assignment1.Controllers
{
    public class GamesController : Controller
    {
        private readonly assignment1Context _context;

        public GamesController(assignment1Context context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
              return View(await _context.Game.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Game == null)
            {
                ViewBag.ErrorMessage = "Game ID is invalid.";
                return View("Error", new ErrorViewModel());
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                ViewBag.ErrorMessage = $"Unable to find game with id={id}.";
                return View("Error", new ErrorViewModel());
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameId,Title,Developer,Genre,ReleaseYear,PurchaseDate,Rating")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Game == null)
            {
                ViewBag.ErrorMessage = "Game ID invalid.";
                return View("Error", new ErrorViewModel());
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                ViewBag.ErrorMessage = $"Unable to find game with id={id}";
                return View("Error", new ErrorViewModel());
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameId,Title,Developer,Genre,ReleaseYear,PurchaseDate,Rating")] Game game)
        {
            if (id != game.GameId)
            {
                ViewBag.ErrorMessage = $"Game IDs don't match, id={id} not equal to Game.GameId={game.GameId}.";
                return View("Error", new ErrorViewModel());
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.GameId))
                    {
                        ViewBag.ErrorMessage = $"Unable to find game with id={game.GameId}.";
                        return View("Error", new ErrorViewModel());
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Game == null)
            {
                ViewBag.ErrorMessage = "Game ID invalid.";
                return View("Error", new ErrorViewModel());
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                ViewBag.ErrorMessage = $"Unable to find game with id={id}.";
                return View("Error", new ErrorViewModel());
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Game == null)
            {
                return Problem("Entity set 'assignment1Context.Game'  is null.");
            }
            var game = await _context.Game.FindAsync(id);
            if (game != null)
            {
                _context.Game.Remove(game);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
          return _context.Game.Any(e => e.GameId == id);
        }
    }
}
