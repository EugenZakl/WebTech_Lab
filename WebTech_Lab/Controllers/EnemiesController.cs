using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTech_Lab.Data;

namespace WebTech_Lab.Controllers
{
    public class EnemiesController : Controller
    {
        private readonly WebTechLabContext _context;

        public EnemiesController(WebTechLabContext context)
        {
            _context = context;
        }

        // GET: Enemies
        public async Task<IActionResult> Index()
        {
            var webTechLabContext = _context.Enemies.Include(e => e.EnemyType).Include(e => e.Photo);
            return View(await webTechLabContext.ToListAsync());
        }

        // GET: Enemies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemies
                .Include(e => e.EnemyType)
                .Include(e => e.Photo)
                .FirstOrDefaultAsync(m => m.EnemyId == id);
            if (enemy == null)
            {
                return NotFound();
            }

            return View(enemy);
        }

        // GET: Enemies/Create
        public IActionResult Create()
        {
            ViewData["EnemyTypeId"] = new SelectList(_context.EnemyTypes, "EnemyTypeId", "EnemyTypeId");
            ViewData["PhotoId"] = new SelectList(_context.Photos, "PhotoId", "PhotoId");
            return View();
        }

        // POST: Enemies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnemyId,EnemyName,EnemyHealth,EnemyDamage,EnemyTypeId,PhotoId")] Enemy enemy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enemy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnemyTypeId"] = new SelectList(_context.EnemyTypes, "EnemyTypeId", "EnemyTypeId", enemy.EnemyTypeId);
            ViewData["PhotoId"] = new SelectList(_context.Photos, "PhotoId", "PhotoId", enemy.PhotoId);
            return View(enemy);
        }

        // GET: Enemies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemies.FindAsync(id);
            if (enemy == null)
            {
                return NotFound();
            }
            ViewData["EnemyTypeId"] = new SelectList(_context.EnemyTypes, "EnemyTypeId", "EnemyTypeId", enemy.EnemyTypeId);
            ViewData["PhotoId"] = new SelectList(_context.Photos, "PhotoId", "PhotoId", enemy.PhotoId);
            return View(enemy);
        }

        // POST: Enemies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnemyId,EnemyName,EnemyHealth,EnemyDamage,EnemyTypeId,PhotoId")] Enemy enemy)
        {
            if (id != enemy.EnemyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enemy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnemyExists(enemy.EnemyId))
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
            ViewData["EnemyTypeId"] = new SelectList(_context.EnemyTypes, "EnemyTypeId", "EnemyTypeId", enemy.EnemyTypeId);
            ViewData["PhotoId"] = new SelectList(_context.Photos, "PhotoId", "PhotoId", enemy.PhotoId);
            return View(enemy);
        }

        // GET: Enemies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemies
                .Include(e => e.EnemyType)
                .Include(e => e.Photo)
                .FirstOrDefaultAsync(m => m.EnemyId == id);
            if (enemy == null)
            {
                return NotFound();
            }

            return View(enemy);
        }

        // POST: Enemies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enemy = await _context.Enemies.FindAsync(id);
            if (enemy != null)
            {
                _context.Enemies.Remove(enemy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnemyExists(int id)
        {
            return _context.Enemies.Any(e => e.EnemyId == id);
        }
    }
}
