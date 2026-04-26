using AviationSupplier.Web.Models;
using AviationSupplier.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AviationSupplier.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            var model = new Customer();
            return View(model);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // 🔥 This includes CustomerAddresses automatically
                _service.Create(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        #region Ajax

        public JsonResult GetCustomers()
        {
            var data = _service.GetAll();
            return Json(data);
        }

        #endregion
    }
}
