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
    [Authorize(Roles = "Admin,Manager")]
    public class Customers19118070Controller : Controller
    {
        private readonly CarRentalManagementContext _context;

        public Customers19118070Controller(CarRentalManagementContext context)
        {
            _context = context;
        }

        // GET: Customers19118070
        public async Task<IActionResult> Index()
        {
            var carRentalManagementContext = _context.Customers19118070s.Include(c => c.RentedCar);
            return View(await carRentalManagementContext.ToListAsync());
        }

        // GET: Customers19118070/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers19118070s == null)
            {
                return NotFound();
            }

            var customers19118070 = await _context.Customers19118070s
                .Include(c => c.RentedCar)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customers19118070 == null)
            {
                return NotFound();
            }

            return View(customers19118070);
        }
        [Authorize(Roles = "Admin,Manager")]
        // GET: Customers19118070/Create
        public IActionResult Create()
        {
            ViewData["RentedCarId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId");
            return View();
        }

        // POST: Customers19118070/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,MiddleName,LastName,RentedCarId,LastModified19118070")] Customers19118070 customers19118070)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers19118070);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RentedCarId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId", customers19118070.RentedCarId);
            return View(customers19118070);
        }

        // GET: Customers19118070/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers19118070s == null)
            {
                return NotFound();
            }

            var customers19118070 = await _context.Customers19118070s.FindAsync(id);
            if (customers19118070 == null)
            {
                return NotFound();
            }
            ViewData["RentedCarId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId", customers19118070.RentedCarId);
            return View(customers19118070);
        }
       
        // POST: Customers19118070/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,MiddleName,LastName,RentedCarId,LastModified19118070")] Customers19118070 customers19118070)
        {
            if (id != customers19118070.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers19118070);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Customers19118070Exists(customers19118070.CustomerId))
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
            ViewData["RentedCarId"] = new SelectList(_context.Cars19118070s, "CarId", "CarId", customers19118070.RentedCarId);
            return View(customers19118070);
        }
        [Authorize(Roles = "Admin,Manager")]
        // GET: Customers19118070/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers19118070s == null)
            {
                return NotFound();
            }

            var customers19118070 = await _context.Customers19118070s
                .Include(c => c.RentedCar)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customers19118070 == null)
            {
                return NotFound();
            }

            return View(customers19118070);
        }

        // POST: Customers19118070/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers19118070s == null)
            {
                return Problem("Entity set 'CarRentalManagementContext.Customers19118070s'  is null.");
            }
            var customers19118070 = await _context.Customers19118070s.FindAsync(id);
            if (customers19118070 != null)
            {
                _context.Customers19118070s.Remove(customers19118070);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Customers19118070Exists(int id)
        {
          return (_context.Customers19118070s?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
