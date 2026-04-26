using AviationSupplier.Web.Models;

namespace AviationSupplier.Web.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        
        int Create(Customer customer);
        void Update(Customer customer);
       
    }
}
