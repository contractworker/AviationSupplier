using AviationSupplier.Web.Data.Repositories;
using AviationSupplier.Web.Models;

namespace AviationSupplier.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _repo.GetAll();
        }

        public Customer GetById(int id)
        {
            return _repo.GetById(id);
        }
        
        public int Create(Customer customer)
        {
            // 🔥 Business rule example
            if (string.IsNullOrWhiteSpace(customer.CompanyName))
                throw new Exception("Company Name is required");

            // You can add more rules here later

            return _repo.Create(customer);
        }

        public void Update(Customer customer)
        {
            if (customer.Id <= 0)
                throw new Exception("Invalid customer");

            _repo.Update(customer);
        }
        
    }
}
