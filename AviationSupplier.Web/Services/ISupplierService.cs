using AviationSupplier.Web.ViewModel;

namespace AviationSupplier.Web.Services
{
    public interface ISupplierService
    {
        IEnumerable<SupplierViewModel> GetAll();
        SupplierViewModel GetById(int id);
        int Create(SupplierViewModel model);
        void Update(SupplierViewModel model);
    }
}
