using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autoinsurance.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Autoinsurance.Infrastructure.Data;

namespace AutoInsurance.Controllers
{
    public class VehicleController : Controller
    {
        private readonly AutoinsuranceDbContext _context;

        public VehicleController(AutoinsuranceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Vehicles.Include(v => v.Customer).ToList());
        }

        public IActionResult Create()
        {
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Make,Model,Year,PlateNumber,CustomersId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre", vehicle.CustomersId);
            return View(vehicle);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = _context.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre", vehicle.CustomersId);
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Make,Model,Year,PlateNumber,CustomersId")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
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
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Nombre", vehicle.CustomersId);
            return View(vehicle);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = _context.Vehicles
                .FirstOrDefault(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
