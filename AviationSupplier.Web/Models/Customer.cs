namespace AviationSupplier.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int? AccountNo { get; set; }
        public string CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? VAT { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostCode { get; set; }
        public string? DocumentPath { get; set; }
        public int CountryId { get; set; }
        public int StatusId { get; set; }
        public List<CustomerAddress> CustomerAddresses { get; set; }
    }

}

//Load Customer + Addresses in one query (Dapper multi-mapping)
//🔥 Build Create/Edit form with multiple addresses
//🔥 Save Customer + Addresses (master-detail insert)