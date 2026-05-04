using AviationSupplier.Web.Models;
using AviationSupplier.Web.ViewModel;

namespace AviationSupplier.Web.Services
{
    public interface ILookupService
    {
        IEnumerable<CountryViewModel> GetAll();
    }
}
