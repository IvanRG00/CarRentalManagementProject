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
    public class RentedCars19118070Controller : Controller
    {
        private readonly CarRentalManagementContext _context;

        public RentedCars19118070Controller(CarRentalManagementContext context)
        {
            _context = context;
        }

        // GET: RentedCars19118070
        public async Task<IActionResult> Index()
        {
            var carRentalManagementContext = _context.RentedCars19118070s.Include(r => r.Car).Include(r => r.Customer);
            return View(await carRentalManagementContext.ToListAsync());
        }

        // GET: RentedCars19118070/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RentedCars19118070s == null)
            {
                return NotFound();
            }

            var rentedCars19118070 = await _context.RentedCars19118070s
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (rentedCars19118070 == null)
            {
                return NotFound();
            }

            return View(rentedCars19118070);
        }

        // GET: RentedCars19118070/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId");
            ViewData["CustomerId"] = new SelectList(_context.Customers19118070s, "CustomerId", "CustomerId");
            return View();
        }

        // POST: RentedCars19118070/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalId,CarId,CustomerId,RentalDate,ReturnDate,LastModified19118070")] RentedCars19118070 rentedCars19118070)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentedCars19118070);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId", rentedCars19118070.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers19118070s, "CustomerId", "CustomerId", rentedCars19118070.CustomerId);
            return View(rentedCars19118070);
        }

        // GET: RentedCars19118070/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RentedCars19118070s == null)
            {
                return NotFound();
            }

            var rentedCars19118070 = await _context.RentedCars19118070s.FindAsync(id);
            if (rentedCars19118070 == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId", rentedCars19118070.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers19118070s, "CustomerId", "CustomerId", rentedCars19118070.CustomerId);
            return View(rentedCars19118070);
        }

        // POST: RentedCars19118070/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalId,CarId,CustomerId,RentalDate,ReturnDate,LastModified19118070")] RentedCars19118070 rentedCars19118070)
        {
            if (id != rentedCars19118070.RentalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentedCars19118070);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentedCars19118070Exists(rentedCars19118070.RentalId))
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
            ViewData["CarId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId", rentedCars19118070.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers19118070s, "CustomerId", "CustomerId", rentedCars19118070.CustomerId);
            return View(rentedCars19118070);
        }

        // GET: RentedCars19118070/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RentedCars19118070s == null)
            {
                return NotFound();
            }

            var rentedCars19118070 = await _context.RentedCars19118070s
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (rentedCars19118070 == null)
            {
                return NotFound();
            }

            return View(rentedCars19118070);
        }

        // POST: RentedCars19118070/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RentedCars19118070s == null)
            {
                return Problem("Entity set 'CarRentalManagementContext.RentedCars19118070s'  is null.");
            }
            var rentedCars19118070 = await _context.RentedCars19118070s.FindAsync(id);
            if (rentedCars19118070 != null)
            {
                _context.RentedCars19118070s.Remove(rentedCars19118070);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentedCars19118070Exists(int id)
        {
          return (_context.RentedCars19118070s?.Any(e => e.RentalId == id)).GetValueOrDefault();
        }
    }
}
