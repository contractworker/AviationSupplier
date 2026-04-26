using AviationSupplier.Web.Data.Dapper;
using AviationSupplier.Web.Models;
using Dapper;
using System.Data;

namespace AviationSupplier.Web.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IDbConnectionFactory _dbFactory;

        public CountryRepository(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
                       
        public IEnumerable<Country> GetAll()
        {
            using (var db = _dbFactory.CreateConnection())
            {
                return db.Query<Country>(@"SELECT Id, CountryName, CountryCode FROM Tbl_Country ORDER BY CountryName");
            }
        }

        public Country GetById(int id)
        {
            using (var db = _dbFactory.CreateConnection())
            {
                return db.QueryFirstOrDefault<Country>(@"SELECT Id, CountryName, CountryCode FROM Tbl_Country WHERE Id = @Id", new { Id = id });
            }
        }

    }
}
