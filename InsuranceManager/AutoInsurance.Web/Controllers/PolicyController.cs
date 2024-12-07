using Autoinsurance.Domain.Entities;
using Autoinsurance.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            ViewBag.Customers = _context.Customers.Select(c => new { c.Id, c.Nombre }).ToList();
            ViewBag.Vehicles = _context.Vehicles.Select(v => new { v.Id, v.PlateNumber }).ToList();
            return View(policy);
        }

        public IActionResult Edit(int id)
        {
            var policy = _context.Policies
                                 .Include(p => p.Customer)  
                                 .Include(p => p.Vehicle)   
                                 .FirstOrDefault(p => p.Id == id);

            if (policy == null)
            {
                return NotFound();
            }

          
            ViewBag.Clientes = _context.Customers.ToList();
            ViewBag.Vehiculos = _context.Vehicles.ToList();

            return View(policy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Policy policy)
        {
            if (_context.Customers.Any(c => c.Id == policy.CustomersId) && _context.Vehicles.Any(v => v.Id == policy.VehicleId))
            {
                _context.Update(policy);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
               
                ModelState.AddModelError("", "Cliente o Vehículo no válidos.");
                ViewBag.Clientes = _context.Customers.ToList();
                ViewBag.Vehiculos = _context.Vehicles.ToList();
                return View(policy);
            }
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
