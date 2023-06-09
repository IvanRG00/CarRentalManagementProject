using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalManagementProject.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CarRentalManagementProject.Controllers
{
    public class Cars19118070Controller : Controller
    {
        private readonly CarRentalManagementContext _context;

        public Cars19118070Controller(CarRentalManagementContext context)
        {
            _context = context;
        }

        // GET: Cars19118070
        public async Task<IActionResult> Index()
        {
              return _context.Cars19118070s != null ? 
                          View(await _context.Cars19118070s.ToListAsync()) :
                          Problem("Entity set 'CarRentalManagementContext.Cars19118070s'  is null.");
        }

        // GET: Cars19118070/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cars19118070s == null)
            {
                return NotFound();
            }

            var cars19118070 = await _context.Cars19118070s
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (cars19118070 == null)
            {
                return NotFound();
            }

            return View(cars19118070);
        }

        // GET: Cars19118070/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars19118070/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,CarMake,CarModel,CarColor,CarHorsePower,LastModified19118070")] Cars19118070 cars19118070)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cars19118070);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cars19118070);
        }

        // GET: Cars19118070/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cars19118070s == null)
            {
                return NotFound();
            }

            var cars19118070 = await _context.Cars19118070s.FindAsync(id);
            if (cars19118070 == null)
            {
                return NotFound();
            }
            return View(cars19118070);
        }
        
        // POST: Cars19118070/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,CarMake,CarModel,CarColor,CarHorsePower,LastModified19118070")] Cars19118070 cars19118070)
        {
            if (id != cars19118070.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cars19118070);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cars19118070Exists(cars19118070.CarId))
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
            return View(cars19118070);
        }
        [Authorize(Roles = "Admin")]
        // GET: Cars19118070/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cars19118070s == null)
            {
                return NotFound();
            }

            var cars19118070 = await _context.Cars19118070s
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (cars19118070 == null)
            {
                return NotFound();
            }

            return View(cars19118070);
        }

        // POST: Cars19118070/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cars19118070s == null)
            {
                return Problem("Entity set 'CarRentalManagementContext.Cars19118070s'  is null.");
            }
            var cars19118070 = await _context.Cars19118070s.FindAsync(id);
            if (cars19118070 != null)
            {
                _context.Cars19118070s.Remove(cars19118070);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cars19118070Exists(int id)
        {
          return (_context.Cars19118070s?.Any(e => e.CarId == id)).GetValueOrDefault();
        }
    }
}
