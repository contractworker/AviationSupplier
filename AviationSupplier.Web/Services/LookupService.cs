using AviationSupplier.Web.Data.Repositories;
using AviationSupplier.Web.Models;
using AviationSupplier.Web.ViewModel;

namespace AviationSupplier.Web.Services
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository _repo;

        public LookupService(ILookupRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<CountryViewModel> GetAll()
        {
            return _repo.GetAll().Select(c=>new CountryViewModel()
            {
                CountryId = c.Id,
                CountryName = c.CountryName,
                CountryCode = c.CountryCode,
            });
        }
    }
}
