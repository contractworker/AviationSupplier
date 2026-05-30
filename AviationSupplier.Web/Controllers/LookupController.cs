using AviationSupplier.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AviationSupplier.Web.Controllers
{
    public class LookupController : Controller
    {
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var data = _lookupService.GetAll();

            return Json(data);
        }
    }
}
