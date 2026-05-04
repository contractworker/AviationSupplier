using AviationSupplier.Web.Models;

namespace AviationSupplier.Web.Data.Repositories
{
    public interface ILookupRepository
    {
        IEnumerable<Country> GetAll();
    }
}
