using AviationSupplier.Web.Models;
using AviationSupplier.Web.Services;
using AviationSupplier.Web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            //var data = _service.GetAll();
            return View();
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
                        customerViewModel.Id = _service.Create(customerViewModel);
                    }
                    //return Content("Record added successfully");
                    return RedirectToAction("Index");
                }
                else
                {
                    var errors = string.Join("<br/>", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    TempData["ErrorMessage"] = $"Validation failed: <br/> {errors}";                    
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Unable to save changes. " + " Exception " + ex.Message.ToString();
                customerViewModel.CountryViewModels = _lookupService.GetAll();
            }
            return View("Create", customerViewModel);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
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

        [HttpGet]
        public IActionResult GetAddresses(int customerId)
        {
            return Ok();
        }


        [HttpPost]
        public IActionResult SaveAddress([FromBody]CustomerAddressViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        _service.UpdateAddress(model);
                    }
                    else
                    {
                        model.Id = _service.CreateAddress(model);
                    }                    
                }
                else
                {
                    var errors = string.Join("<br/>", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    return Json(new
                    {
                        success = false,
                        errors = $"Validation failed: <br/> {errors}"
                });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    errors = "Unable to save changes. " + " Exception " + ex.Message.ToString()
                });
            }
            return Ok();
        }


        #endregion
    }
}
