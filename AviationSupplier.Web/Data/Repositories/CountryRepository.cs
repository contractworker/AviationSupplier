using AviationSupplier.Web.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AviationSupplier.Web.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IConfiguration _config;

        public CountryRepository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));
               
        public IEnumerable<Country> GetAll()
        {
            using var db = Connection;

            return db.Query<Country>(@"SELECT Id, CountryName, CountryCode FROM Tbl_Country ORDER BY CountryName" );
        }

        public Country GetById(int id)
        {
            using var db = Connection;

            return db.QueryFirstOrDefault<Country>(@"SELECT Id, CountryName, CountryCode FROM Tbl_Country WHERE Id = @Id",new { Id = id } );
        }


    }
}
