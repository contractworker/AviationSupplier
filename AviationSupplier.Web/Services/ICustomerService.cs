using AviationSupplier.Web.Models;
using AviationSupplier.Web.ViewModel;

namespace AviationSupplier.Web.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerViewModel> GetAll();

        CustomerViewModel GetById(int id);
        
        int Create(CustomerViewModel customer);

        void Update(CustomerViewModel customer);
       
    }
}
