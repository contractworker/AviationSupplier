using System.Collections.Generic;
using AviationSupplier.Web.Data.Dapper;
using AviationSupplier.Web.Models;
using Dapper;

namespace AviationSupplier.Web.Data.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private readonly IDbConnectionFactory _dbFactory;

        public LookupRepository(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public IEnumerable<Country> GetAll()
        {
            using var db = _dbFactory.CreateConnection();

            return db.Query<Country>("SELECT * FROM Tbl_Country ORDER BY CountryName");
        }
    }
}
