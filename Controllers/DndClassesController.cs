#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dndgenesis.Data;
using dndgenesis.Models;

namespace dndgenesis.Controllers
{
    public class DndClassesController : Controller
    {
        private readonly dndgenesisContext _context;

        public DndClassesController(dndgenesisContext context)
        {
            _context = context;
        }

        // GET: DndClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.DndClass.ToListAsync());
        }

        // GET: DndClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndClass = await _context.DndClass
                .FirstOrDefaultAsync(m => m.DndClassId == id);
            if (dndClass == null)
            {
                return NotFound();
            }

            return View(dndClass);
        }

        // GET: DndClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DndClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DndClassId,DndClassName")] DndClass dndClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dndClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dndClass);
        }

        // GET: DndClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndClass = await _context.DndClass.FindAsync(id);
            if (dndClass == null)
            {
                return NotFound();
            }
            return View(dndClass);
        }

        // POST: DndClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DndClassId,DndClassName")] DndClass dndClass)
        {
            if (id != dndClass.DndClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dndClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DndClassExists(dndClass.DndClassId))
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
            return View(dndClass);
        }

        // GET: DndClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndClass = await _context.DndClass
                .FirstOrDefaultAsync(m => m.DndClassId == id);
            if (dndClass == null)
            {
                return NotFound();
            }

            return View(dndClass);
        }

        // POST: DndClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dndClass = await _context.DndClass.FindAsync(id);
            _context.DndClass.Remove(dndClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DndClassExists(int id)
        {
            return _context.DndClass.Any(e => e.DndClassId == id);
        }
    }
}
