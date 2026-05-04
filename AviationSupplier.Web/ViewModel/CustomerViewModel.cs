using System.ComponentModel.DataAnnotations;

namespace AviationSupplier.Web.ViewModel
{
    public class CustomerViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public int RowId { get; set; }
        public int AccountNo { get; set; }
        public string CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? Vat { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string PostCode { get; set; }
        public string? DocumentPath { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public int StatusId { get; set; } = 0;
        public List<CustomerAddressViewModel>? CustomerAddressViewModels { get; set; }
       public IEnumerable<CountryViewModel>? CountryViewModels { get; set; }
        //public List<StatusViewModel> StatusViewModels { get; set; }
    }

    
}
