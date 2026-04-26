using AviationSupplier.Web.Data.Dapper;
using AviationSupplier.Web.Models;
using Dapper;

namespace AviationSupplier.Web.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnectionFactory _dbFactory;

        public CustomerRepository(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public int Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            using var db = _dbFactory.CreateConnection();

            return db.Query<Customer>(
                "SELECT * FROM Tbl_Customer ORDER BY CompanyName"
            );
        }

        public Customer GetById(int id)
        {
            using var db = _dbFactory.CreateConnection();

            var customerDict = new Dictionary<int, Customer>();

            var sql = @" SELECT c.*,ca.Id, ca.CustomerId, ca.CompanyName, ca.ContactName,ca.AddressType, ca.Address1, ca.Address2, ca.Address3,
                            ca.City, ca.State, ca.PostCode, ca.Phone, ca.Email,ca.CountryId, ca.StatusId
                        FROM Tbl_Customer c
                        LEFT JOIN Tbl_CustomerAddress ca ON c.Id = ca.CustomerId
                        WHERE c.Id = @Id";

            var result = db.Query<Customer, CustomerAddress, Customer>(
                sql,
                (customer, address) =>
                {
                    if (!customerDict.TryGetValue(customer.Id, out var currentCustomer))
                    {
                        currentCustomer = customer;
                        currentCustomer.CustomerAddresses = new List<CustomerAddress>();
                        customerDict.Add(currentCustomer.Id, currentCustomer);
                    }

                    // Add address if exists (LEFT JOIN can return null)
                    if (address != null && address.Id != 0)
                    {
                        currentCustomer.CustomerAddresses.Add(address);
                    }

                    return currentCustomer;
                },
                new { Id = id },
                splitOn: "Id" // ⚠️ important
            );

            return customerDict?.Values.FirstOrDefault();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
