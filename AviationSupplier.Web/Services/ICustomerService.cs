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

        IEnumerable<CustomerAddressViewModel> GetAllAddresses(int id);

        CustomerAddressViewModel GetAddressById(int id);

        int CreateAddress(CustomerAddressViewModel address);

        void UpdateAddress(CustomerAddressViewModel address);
       
    }
}
