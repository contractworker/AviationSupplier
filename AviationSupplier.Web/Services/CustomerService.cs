using AutoMapper;
using AviationSupplier.Web.Data.Repositories;
using AviationSupplier.Web.Models;
using AviationSupplier.Web.ViewModel;

namespace AviationSupplier.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;
        

        public CustomerService(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            var c = _repo.GetAll();
            var viewModel = _mapper.Map<List<CustomerViewModel>>(c);
            return viewModel;
        }

        public CustomerViewModel GetById(int id)
        {
            var c= _repo.GetById(id);
            var viewModel = _mapper.Map<CustomerViewModel>(c);
            return viewModel;
        }
        
        public int Create(CustomerViewModel customer)
        {
            // 🔥 Business rule example
            if (string.IsNullOrWhiteSpace(customer.CompanyName))
                throw new Exception("Company Name is required");

            // You can add more rules here later

            //return _repo.Create(customer);
            return 1;
        }

        public void Update(CustomerViewModel customer)
        {
            if (customer.Id <= 0)
                throw new Exception("Invalid customer");

            var model = _mapper.Map<Customer>(customer);

            _repo.Update(model);
        }
        
    }
}
