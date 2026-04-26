namespace AviationSupplier.Web.Models
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public int AddressType { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int CountryId { get; set; }
        public int StatusId { get; set; }
    }
}
