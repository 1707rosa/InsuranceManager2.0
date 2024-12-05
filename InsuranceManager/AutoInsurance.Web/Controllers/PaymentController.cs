using Microsoft.AspNetCore.Mvc;
using Autoinsurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Autoinsurance.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "PolicyNumber");
            return View();
        }

        // POST: Payments/Create
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

        // GET: Payments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _context.Payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "PolicyNumber", payment.PolicyId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,PaymentNumber,PolicyId,Amount,PaymentDate")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.Id))
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
            ViewData["PolicyId"] = new SelectList(_context.Policies, "Id", "PolicyNumber", payment.PolicyId);
            return View(payment);
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
