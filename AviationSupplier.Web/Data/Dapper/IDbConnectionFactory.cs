using System.Data;

namespace AviationSupplier.Web.Data.Dapper
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
