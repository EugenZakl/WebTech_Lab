﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTech_Lab.Data;

namespace WebTech_Lab.Controllers
{
    public class EnemyTypesController : Controller
    {
        private readonly WebTechLabContext _context;

        public EnemyTypesController(WebTechLabContext context)
        {
            _context = context;
        }

        // GET: EnemyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnemyTypes.ToListAsync());
        }

        // GET: EnemyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemyType = await _context.EnemyTypes
                .FirstOrDefaultAsync(m => m.EnemyTypeId == id);
            if (enemyType == null)
            {
                return NotFound();
            }

            return View(enemyType);
        }

        // GET: EnemyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnemyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnemyTypeId,Type")] EnemyType enemyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enemyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enemyType);
        }

        // GET: EnemyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemyType = await _context.EnemyTypes.FindAsync(id);
            if (enemyType == null)
            {
                return NotFound();
            }
            return View(enemyType);
        }

        // POST: EnemyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnemyTypeId,Type")] EnemyType enemyType)
        {
            if (id != enemyType.EnemyTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enemyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnemyTypeExists(enemyType.EnemyTypeId))
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
            return View(enemyType);
        }

        // GET: EnemyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemyType = await _context.EnemyTypes
                .FirstOrDefaultAsync(m => m.EnemyTypeId == id);
            if (enemyType == null)
            {
                return NotFound();
            }

            return View(enemyType);
        }

        // POST: EnemyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enemyType = await _context.EnemyTypes.FindAsync(id);
            if (enemyType != null)
            {
                _context.EnemyTypes.Remove(enemyType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnemyTypeExists(int id)
        {
            return _context.EnemyTypes.Any(e => e.EnemyTypeId == id);
        }
    }
}
