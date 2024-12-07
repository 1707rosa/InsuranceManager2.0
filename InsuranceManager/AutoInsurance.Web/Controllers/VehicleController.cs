using Autoinsurance.Domain.Entities;
using Autoinsurance.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
           ViewBag.Clientes = _context.Customers.ToList();
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
            ViewBag.Clientes = _context.Customers.ToList();
            return View(vehicle);
        }

        public IActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles
                .Include(v => v.Customer)  
                .FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            ViewBag.Clientes = _context.Customers.ToList();  

            return View(vehicle);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                var customer = _context.Customers.FirstOrDefault(c => c.Id == vehicle.CustomersId);
                if (customer == null)
                {
                    ModelState.AddModelError("", "Cliente no válido.");
                    ViewBag.Clientes = _context.Customers.ToList();
                    return View(vehicle);
                }

                _context.Update(vehicle);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Clientes = _context.Customers.ToList();
            return View(vehicle);
        }



        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
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

       
    }
}
