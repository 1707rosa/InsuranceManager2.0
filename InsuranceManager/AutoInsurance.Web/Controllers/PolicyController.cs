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

        public IActionResult Index()
        {
            return View(_context.Policies
                .Include(p => p.Customer)
                .Include(p => p.Vehicle)
                .ToList());
        }

        public IActionResult Create()
        {
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "PlateNumber");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,PolicyNumber,CustomersId,VehicleId,CoverageAmount,PremiumAmount,StartDate,EndDate")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policy);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre", policy.CustomersId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "PlateNumber", policy.VehicleId);
            return View(policy);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = _context.Policies.Find(id);
            if (policy == null)
            {
                return NotFound();
            }
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre", policy.CustomersId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "PlateNumber", policy.VehicleId);
            return View(policy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,PolicyNumber,CustomersId,VehicleId,CoverageAmount,PremiumAmount,StartDate,EndDate")] Policy policy)
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
                    _context.SaveChanges();
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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = _context.Policies
                .Include(p => p.Customer)
                .Include(p => p.Vehicle)
                .FirstOrDefault(m => m.Id == id);
            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var policy = _context.Policies.Find(id);
            _context.Policies.Remove(policy);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicyExists(int id)
        {
            return _context.Policies.Any(e => e.Id == id);
        }
    }
}
