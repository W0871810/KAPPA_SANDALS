using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KAPPA_SANDALS.Data;
using KAPPA_SANDALS.Models;

namespace KAPPA_SANDALS.Controllers
{
    public class SandalsController : Controller
    {
        private readonly KAPPA_SANDALSContext _context;

        public SandalsController(KAPPA_SANDALSContext context)
        {
            _context = context;
        }

        // GET: Sandals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sandal.ToListAsync());
        }

        // GET: Sandals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sandal = await _context.Sandal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sandal == null)
            {
                return NotFound();
            }

            return View(sandal);
        }

        // GET: Sandals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sandals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Color,Design,Price,Age,Size")] Sandal sandal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sandal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sandal);
        }

        // GET: Sandals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sandal = await _context.Sandal.FindAsync(id);
            if (sandal == null)
            {
                return NotFound();
            }
            return View(sandal);
        }

        // POST: Sandals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Color,Design,Price,Age,Size")] Sandal sandal)
        {
            if (id != sandal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sandal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SandalExists(sandal.Id))
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
            return View(sandal);
        }

        // GET: Sandals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sandal = await _context.Sandal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sandal == null)
            {
                return NotFound();
            }

            return View(sandal);
        }

        // POST: Sandals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sandal = await _context.Sandal.FindAsync(id);
            if (sandal != null)
            {
                _context.Sandal.Remove(sandal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SandalExists(int id)
        {
            return _context.Sandal.Any(e => e.Id == id);
        }
    }
}
