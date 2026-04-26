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

        #region Ajax

        public JsonResult GetCustomers()
        {
            var data = _service.GetAll();
            return Json(data);
        }

        #endregion
    }
}
