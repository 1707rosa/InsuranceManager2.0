using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autoinsurance.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Autoinsurance.Infrastructure.Data;

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
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "PolicyNumber");
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
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "PolicyNumber", claim.PolicyId);
            return View(claim);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = _context.Claims.Find(id);
            if (claim == null)
            {
                return NotFound();
            }
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "PolicyNumber", claim.PolicyId);
            return View(claim);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ClaimNumber,PolicyId,ClaimAmount,ClaimDate,Status")] Claim claim)
        {
            if (id != claim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claim);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimExists(claim.Id))
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
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "PolicyNumber", claim.PolicyId);
            return View(claim);
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
