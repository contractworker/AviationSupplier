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
            if (string.IsNullOrWhiteSpace(customer.CompanyName))
                throw new Exception("Company Name is required");

            // You can add more rules here later
            var model = _mapper.Map<Customer>(customer);

            return _repo.Create(model);          
        }

        public void Update(CustomerViewModel customer)
        {
            if (customer.Id <= 0)
                throw new Exception("Invalid customer");

            var model = _mapper.Map<Customer>(customer);

            _repo.Update(model);
        }

        public IEnumerable<CustomerAddressViewModel> GetAllAddresses(int id)
        {
            var data = _repo.GetAllAddresses(id);
            var viewModel = _mapper.Map<List<CustomerAddressViewModel>>(data);
            return viewModel;
        }

        public CustomerAddressViewModel GetAddressById(int id)
        {
            var data = _repo.GetAddressById(id);
            var viewModel = _mapper.Map<CustomerAddressViewModel>(data);
            return viewModel;
        }

        public int CreateAddress(CustomerAddressViewModel address)
        {
            if (string.IsNullOrWhiteSpace(address.CompanyName))
                throw new Exception("Company Name is required");

            // You can add more rules here later
            var model = _mapper.Map<CustomerAddress>(address);

            return _repo.CreateAddress(model);
        }

        public void UpdateAddress(CustomerAddressViewModel address)
        {
            if (address.Id <= 0)
                throw new Exception("Invalid address");

            if (string.IsNullOrWhiteSpace(address.CompanyName))
                throw new Exception("Company Name is required");

            var model = _mapper.Map<CustomerAddress>(address);

            _repo.UpdateAddress(model);
        }
    }
}
