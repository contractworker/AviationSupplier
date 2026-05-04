namespace AviationSupplier.Web.ViewModel
{
    public class CustomerAddressViewModel
    {
        public int? AddressId { get; set; }
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullAddress { get; set; }
        public int StatusId { get; set; }
    }
}
