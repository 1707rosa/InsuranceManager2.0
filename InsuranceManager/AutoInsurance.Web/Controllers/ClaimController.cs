using Autoinsurance.Domain.Entities;
using Autoinsurance.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoInsurance.Web.Controllers
{
    public class ClaimController : Controller
    {
        private readonly AutoinsuranceDbContext _context;

        public ClaimController(AutoinsuranceDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_context.Claims.Include(c => c.Policy).ToList());
        }


        public IActionResult Create()
        {
            ViewData["Policies"] = _context.Policies.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ClaimNumber,PolicyId,ClaimAmount,ClaimDate,Status")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claim);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Policies"] = _context.Policies.ToList();
            return View(claim);
        }


        public IActionResult Edit(int id)
        {
            var claim = _context.Claims
                                .Include(c => c.Policy)  
                                .FirstOrDefault(c => c.Id == id);

            if (claim == null)
            {
                return NotFound();
            }

            ViewBag.Policies = _context.Policies.ToList();  
            return View(claim);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Claim claim)
        {
            if (_context.Policies.Any(p => p.Id == claim.PolicyId))
            {
                _context.Update(claim);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Póliza no válida.");
                ViewBag.Policies = _context.Policies.ToList();  
                return View(claim);
            }
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = _context.Claims
                .Include(c => c.Policy)
                .FirstOrDefault(m => m.Id == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var claim = _context.Claims.Find(id);
            _context.Claims.Remove(claim);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimExists(int id)
        {
            return _context.Claims.Any(e => e.Id == id);
        }
    }
}
