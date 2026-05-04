using AviationSupplier.Web.Models;
using AviationSupplier.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AviationSupplier.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILookupService _lookupService;
              
        public HomeController(ILookupService lookupService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _lookupService = lookupService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Ajax
        public JsonResult GetCountry()
        {
            var data = _lookupService.GetAll();
            return Json(data);
        }
        #endregion
    }
}