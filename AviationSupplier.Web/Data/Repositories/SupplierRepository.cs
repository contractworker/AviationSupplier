using AviationSupplier.Web.Data.Dapper;
using AviationSupplier.Web.Models;
using Dapper;

namespace AviationSupplier.Web.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IDbConnectionFactory _dbFactory;

        public SupplierRepository(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public int Create(Supplier supplier)
        {
            var sql = @"
                INSERT INTO Tbl_Supplier
                (
                    Name,
                    Address1,
                    Address2,
                    City,
                    PostCode,
                    CountryId,
                    Phone,
                    Mobile,
                    Website,
                    Email,
                    Note,
                    OEM,
                    Username,
                    Password,
                    StatusId
                )
                VALUES
                (
                    @Name,
                    @Address1,
                    @Address2,
                    @City,
                    @PostCode,
                    @CountryId,
                    @Phone,
                    @Mobile,
                    @Website,
                    @Email,
                    @Note,
                    @OEM,
                    @Username,
                    @Password,
                    @StatusId
                );

                SELECT CAST(SCOPE_IDENTITY() as int);
            ";

            using var db = _dbFactory.CreateConnection();
            return db.QuerySingle<int>(sql, supplier);
        }

        // =========================
        // GET ALL
        // =========================
        public IEnumerable<Supplier> GetAll()
        {
            using var db = _dbFactory.CreateConnection();

            return db.Query<Supplier>(
                "SELECT * FROM Tbl_Supplier ORDER BY Name"
            );
        }

        // =========================
        // GET BY ID
        // =========================
        public Supplier GetById(int id)
        {
            var sql = @"
                SELECT *
                FROM Tbl_Supplier
                WHERE Id = @Id
            ";

            using var db = _dbFactory.CreateConnection();
            return db.QueryFirstOrDefault<Supplier>(sql, new { Id = id });
        }

        // =========================
        // UPDATE
        // =========================
        public void Update(Supplier supplier)
        {
            var sql = @"
                UPDATE Tbl_Supplier
                SET
                    Name = @Name,
                    Address1 = @Address1,
                    Address2 = @Address2,
                    City = @City,
                    PostCode = @PostCode,
                    CountryId = @CountryId,
                    Phone = @Phone,
                    Mobile = @Mobile,
                    Website = @Website,
                    Email = @Email,
                    Note = @Note,
                    OEM = @OEM,
                    Username = @Username,
                    Password = @Password,
                    StatusId = @StatusId
                WHERE Id = @Id
            ";

            using var db = _dbFactory.CreateConnection();
            db.Execute(sql, supplier);
        }
    }
}