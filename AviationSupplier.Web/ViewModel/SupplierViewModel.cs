using System.ComponentModel.DataAnnotations;

namespace AviationSupplier.Web.ViewModel
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        public int RowId { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }

        public int? CountryId { get; set; }
        public string? CountryName { get; set; }

        public string? Phone { get; set; }
        public string? Mobile { get; set; }

        public string? Website { get; set; }

        public string? Email { get; set; }
        public string? Note { get; set; }
        public string? OEM { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }

        public int StatusId { get; set; }

        public IEnumerable<CountryViewModel>? CountryViewModels { get; set; }
    }
}
