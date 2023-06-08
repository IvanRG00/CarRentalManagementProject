using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalManagementProject.Models;

namespace CarRentalManagementProject.Controllers
{
    public class Log19118070Controller : Controller
    {
        private readonly CarRentalManagementContext _context;

        public Log19118070Controller(CarRentalManagementContext context)
        {
            _context = context;
        }

        // GET: Log19118070
        public async Task<IActionResult> Index()
        {
              return _context.Log19118070s != null ? 
                          View(await _context.Log19118070s.ToListAsync()) :
                          Problem("Entity set 'CarRentalManagementContext.Log19118070s'  is null.");
        }

        // GET: Log19118070/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Log19118070s == null)
            {
                return NotFound();
            }

            var log19118070 = await _context.Log19118070s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (log19118070 == null)
            {
                return NotFound();
            }

            return View(log19118070);
        }

        // GET: Log19118070/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Log19118070/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TableName,OperationType,DateTime")] Log19118070 log19118070)
        {
            if (ModelState.IsValid)
            {
                _context.Add(log19118070);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(log19118070);
        }

        // GET: Log19118070/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Log19118070s == null)
            {
                return NotFound();
            }

            var log19118070 = await _context.Log19118070s.FindAsync(id);
            if (log19118070 == null)
            {
                return NotFound();
            }
            return View(log19118070);
        }

        // POST: Log19118070/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TableName,OperationType,DateTime")] Log19118070 log19118070)
        {
            if (id != log19118070.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(log19118070);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Log19118070Exists(log19118070.Id))
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
            return View(log19118070);
        }

        // GET: Log19118070/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Log19118070s == null)
            {
                return NotFound();
            }

            var log19118070 = await _context.Log19118070s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (log19118070 == null)
            {
                return NotFound();
            }

            return View(log19118070);
        }

        // POST: Log19118070/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Log19118070s == null)
            {
                return Problem("Entity set 'CarRentalManagementContext.Log19118070s'  is null.");
            }
            var log19118070 = await _context.Log19118070s.FindAsync(id);
            if (log19118070 != null)
            {
                _context.Log19118070s.Remove(log19118070);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Log19118070Exists(int id)
        {
          return (_context.Log19118070s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
