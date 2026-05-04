using AviationSupplier.Web.Models;
using AviationSupplier.Web.Services;
using AviationSupplier.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AviationSupplier.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly ILookupService _lookupService;

        public CustomerController(ICustomerService service, ILookupService lookupService)
        {
            _service = service;
            _lookupService = lookupService;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _service.GetById(id);
            model.CountryViewModels = _lookupService.GetAll();
            return View("Create",model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CustomerViewModel();
            model.CountryViewModels = _lookupService.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult Save(CustomerViewModel customerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (customerViewModel.Id > 0)
                    {
                        _service.Update(customerViewModel);
                    }
                    else
                    {
                        //customerViewModel = _service.Create(customerViewModel);
                    }
                    return Content("Record added successfully");
                }
                else
                {
                    var errors = string.Join("<br/>", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    return Content($"Validation failed: <br/> {errors}");
                }
            }
            catch (Exception ex)
            {
                //_logger.Error(ex.ToString());
                return Content(ex.ToString());
            }
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                
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
