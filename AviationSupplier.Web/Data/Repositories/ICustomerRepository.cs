using AviationSupplier.Web.Models;
using AviationSupplier.Web.ViewModel;

namespace AviationSupplier.Web.Data.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        int Create(Customer customer);
        void Update(Customer customer);
        IEnumerable<CustomerAddress> GetAllAddresses(int id);
        CustomerAddress GetAddressById(int id);
        int CreateAddress(CustomerAddress address);
        void UpdateAddress(CustomerAddress address);

    }
}
