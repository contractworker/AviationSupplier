using AviationSupplier.Web.Services;
using AviationSupplier.Web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AviationSupplier.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _service;
        private readonly ILookupService _lookupService;

        public SupplierController(ISupplierService service, ILookupService lookupService)
        {
            _service = service;
            _lookupService = lookupService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new SupplierViewModel();
            model.CountryViewModels = _lookupService.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _service.GetById(id);

            if (model == null)
                return NotFound();

            model.CountryViewModels = _lookupService.GetAll();

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Save(SupplierViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        _service.Update(model);
                    }
                    else
                    {
                        model.Id = _service.Create(model);
                    }

                    return RedirectToAction("Index");
                }

                var errors = string.Join("<br/>", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                TempData["ErrorMessage"] =
                    $"Validation failed:<br/>{errors}";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Unable to save changes. Exception: {ex.Message}";
            }

            model.CountryViewModels = _lookupService.GetAll();

            return View("Create", model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #region Ajax

        [HttpGet]
        public JsonResult GetSuppliers()
        {
            var data = _service.GetAll();
            return Json(data);
        }

        #endregion
    }
}
