using Microsoft.AspNetCore.Connections;
using System.Data;
using System.Data.SqlClient;

namespace AviationSupplier.Web.Data.Dapper
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            return new SqlConnection(connectionString);
        }
    }
}
