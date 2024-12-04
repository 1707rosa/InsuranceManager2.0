using AutoInsurance.Domain;
using AutoInsurance.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoInsurance.Web.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly IPolicyService _policyService;
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;

        public PoliciesController(IPolicyService policyService, ICustomerService customerService, IVehicleService vehicleService)
        {
            _policyService = policyService;
            _customerService = customerService;
            _vehicleService = vehicleService;
        }

        // GET: Policies
        public IActionResult Index()
        {
            var policies = _policyService.GetAllPolicies();
            return View(policies);
        }

        // GET: Policies/Create
        public IActionResult Create()
        {
            ViewBag.Customers = _customerService.GetAllCustomers();
            ViewBag.Vehicles = _vehicleService.GetAllVehicles();
            return View();
        }

        // POST: Policies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Policy policy)
        {
            if (ModelState.IsValid)
            {
                _policyService.CreatePolicy(policy);
                return RedirectToAction(nameof(Index));
            }
            return View(policy);
        }

        // GET: Policies/Edit/5
        public IActionResult Edit(int id)
        {
            var policy = _policyService.GetPolicyById(id);
            if (policy == null)
            {
                return NotFound();
            }

            ViewBag.Customers = _customerService.GetAllCustomers();
            ViewBag.Vehicles = _vehicleService.GetAllVehicles();

            return View(policy);
        }

        // POST: Policies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Policy policy)
        {
            if (id != policy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _policyService.UpdatePolicy(policy);
                return RedirectToAction(nameof(Index));
            }
            return View(policy);
        }

        // GET: Policies/Delete/5
        public IActionResult Delete(int id)
        {
            var policy = _policyService.GetPolicyById(id);
            if (policy == null)
            {
                return NotFound();
            }
            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _policyService.DeletePolicy(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
