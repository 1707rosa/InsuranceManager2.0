using AutoInsurance.Domain;
using AutoInsurance.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoInsurance.Web.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly IClaimService _claimService;

        public ClaimsController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        // GET: Claims
        public IActionResult Index()
        {
            var claims = _claimService.GetAllClaims();
            return View(claims);
        }

        // GET: Claims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Claims/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Claim claim)
        {
            if (ModelState.IsValid)
            {
                _claimService.CreateClaim(claim);
                return RedirectToAction(nameof(Index));
            }
            return View(claim);
        }

        // GET: Claims/Edit/5
        public IActionResult Edit(int id)
        {
            var claim = _claimService.GetClaimById(id);
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }

        // POST: Claims/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Claim claim)
        {
            if (id != claim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _claimService.UpdateClaim(claim);
                return RedirectToAction(nameof(Index));
            }
            return View(claim);
        }

        // GET: Claims/Delete/5
        public IActionResult Delete(int id)
        {
            var claim = _claimService.GetClaimById(id);
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _claimService.DeleteClaim(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
