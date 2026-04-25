using AviationSupplier.Web.Models;

namespace AviationSupplier.Web.Data.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
        Country GetById(int id);
    }
}
