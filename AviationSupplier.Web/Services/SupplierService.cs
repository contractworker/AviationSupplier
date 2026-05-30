using AutoMapper;
using AviationSupplier.Web.Data.Repositories;
using AviationSupplier.Web.Models;
using AviationSupplier.Web.ViewModel;

namespace AviationSupplier.Web.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repo;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // =========================
        // GET ALL
        // =========================
        public IEnumerable<SupplierViewModel> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<List<SupplierViewModel>>(data);
        }

        // =========================
        // GET BY ID
        // =========================
        public SupplierViewModel GetById(int id)
        {
            var data = _repo.GetById(id);
            return _mapper.Map<SupplierViewModel>(data);
        }

        // =========================
        // CREATE
        // =========================
        public int Create(SupplierViewModel supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.Name))
                throw new Exception("Supplier Name is required");

            if (string.IsNullOrWhiteSpace(supplier.Website))
                throw new Exception("Website is required");

            var model = _mapper.Map<Supplier>(supplier);

            return _repo.Create(model);
        }

        // =========================
        // UPDATE
        // =========================
        public void Update(SupplierViewModel supplier)
        {
            if (supplier.Id <= 0)
                throw new Exception("Invalid supplier");

            if (string.IsNullOrWhiteSpace(supplier.Name))
                throw new Exception("Supplier Name is required");

            var model = _mapper.Map<Supplier>(supplier);

            _repo.Update(model);
        }
    }
}