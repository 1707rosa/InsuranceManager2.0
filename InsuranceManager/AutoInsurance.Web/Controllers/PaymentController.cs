using Autoinsurance.Domain.Entities;
using Autoinsurance.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoInsurance.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly AutoinsuranceDbContext _context;

        public PaymentController(AutoinsuranceDbContext context)
        {
            _context = context;
        }

        // GET: Payments
        public IActionResult Index()
        {
            return View(_context.Payments.Include(p => p.Policy).ToList());
        }

     
        public IActionResult Create()
        {
            ViewData["Policies"] = _context.Policies.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,PaymentNumber,PolicyId,Amount,PaymentDate")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "PolicyNumber", payment.PolicyId);
            return View(payment);
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var payment = _context.Payments
                                  .FirstOrDefault(p => p.Id == id.Value);

            if (payment == null)
            {
                return NotFound();
            }

            
            ViewBag.Policies = _context.Policies.ToList();

           
            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Payment payment)
        {
            
            if (!ModelState.IsValid)
            {
                
                ViewBag.Policies = _context.Policies.ToList();
                return View(payment);
            }

           
            _context.Update(payment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: Payments/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _context.Payments
                .Include(p => p.Policy)
                .FirstOrDefault(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var payment = _context.Payments.Find(id);
            _context.Payments.Remove(payment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}
