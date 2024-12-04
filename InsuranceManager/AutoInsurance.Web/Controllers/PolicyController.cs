using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autoinsurance.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Autoinsurance.Infrastructure.Data;

namespace AutoInsurance.Web.Controllers
{
    public class PolicyController : Controller
    {
        private readonly AutoinsuranceDbContext _context;

        public PolicyController(AutoinsuranceDbContext context)
        {
            _context = context;
        }

        // GET: Policies
        public async Task<IActionResult> Index()
        {
            var policies = await _context.Policies
                .Include(p => p.Customer)
                .Include(p => p.Vehicle)
                .ToListAsync();
            return View(policies);
        }

        // GET: Policies/Create
        public IActionResult Create()
        {
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "PlateNumber");
            return View();
        }

        // POST: Policies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PolicyNumber,CustomersId,VehicleId,CoverageAmount,PremiumAmount,StartDate,EndDate")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre", policy.CustomersId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "PlateNumber", policy.VehicleId);
            return View(policy);
        }

        // GET: Policies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Policies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre", policy.CustomersId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "PlateNumber", policy.VehicleId);
            return View(policy);
        }

        // POST: Policies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PolicyNumber,CustomersId,VehicleId,CoverageAmount,PremiumAmount,StartDate,EndDate")] Policy policy)
        {
            if (id != policy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicyExists(policy.Id))
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
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre", policy.CustomersId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "PlateNumber", policy.VehicleId);
            return View(policy);
        }

        // GET: Policies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Policies
                .Include(p => p.Customer)
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            _context.Policies.Remove(policy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicyExists(int id)
        {
            return _context.Policies.Any(e => e.Id == id);
        }
    }
}
