using AviationSupplier.Web.Models;

namespace AviationSupplier.Web.Data.Repositories
{
    public interface ISupplierRepository
    {
        int Create(Supplier supplier);
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        void Update(Supplier supplier);
    }
}
