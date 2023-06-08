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
    public class Staff19118070Controller : Controller
    {
        private readonly CarRentalManagementContext _context;

        public Staff19118070Controller(CarRentalManagementContext context)
        {
            _context = context;
        }

        // GET: Staff19118070
        public async Task<IActionResult> Index()
        {
            var carRentalManagementContext = _context.Staff19118070s.Include(s => s.MaintainingVehicle);
            return View(await carRentalManagementContext.ToListAsync());
        }

        // GET: Staff19118070/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Staff19118070s == null)
            {
                return NotFound();
            }

            var staff19118070 = await _context.Staff19118070s
                .Include(s => s.MaintainingVehicle)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff19118070 == null)
            {
                return NotFound();
            }

            return View(staff19118070);
        }

        // GET: Staff19118070/Create
        public IActionResult Create()
        {
            ViewData["MaintainingVehicleId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId");
            return View();
        }

        // POST: Staff19118070/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,FirstName,LastName,MaintainingVehicleId,LastModified19118070")] Staff19118070 staff19118070)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff19118070);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaintainingVehicleId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId", staff19118070.MaintainingVehicleId);
            return View(staff19118070);
        }

        // GET: Staff19118070/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Staff19118070s == null)
            {
                return NotFound();
            }

            var staff19118070 = await _context.Staff19118070s.FindAsync(id);
            if (staff19118070 == null)
            {
                return NotFound();
            }
            ViewData["MaintainingVehicleId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId", staff19118070.MaintainingVehicleId);
            return View(staff19118070);
        }

        // POST: Staff19118070/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,FirstName,LastName,MaintainingVehicleId,LastModified19118070")] Staff19118070 staff19118070)
        {
            if (id != staff19118070.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff19118070);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Staff19118070Exists(staff19118070.StaffId))
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
            ViewData["MaintainingVehicleId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId", staff19118070.MaintainingVehicleId);
            return View(staff19118070);
        }

        // GET: Staff19118070/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Staff19118070s == null)
            {
                return NotFound();
            }

            var staff19118070 = await _context.Staff19118070s
                .Include(s => s.MaintainingVehicle)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff19118070 == null)
            {
                return NotFound();
            }

            return View(staff19118070);
        }

        // POST: Staff19118070/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Staff19118070s == null)
            {
                return Problem("Entity set 'CarRentalManagementContext.Staff19118070s'  is null.");
            }
            var staff19118070 = await _context.Staff19118070s.FindAsync(id);
            if (staff19118070 != null)
            {
                _context.Staff19118070s.Remove(staff19118070);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Staff19118070Exists(int id)
        {
          return (_context.Staff19118070s?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
    }
}
