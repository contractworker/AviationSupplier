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
        
    }
}
