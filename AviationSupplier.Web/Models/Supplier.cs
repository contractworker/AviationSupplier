using System.ComponentModel.DataAnnotations;

namespace AviationSupplier.Web.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string? Address1 { get; set; }

        [StringLength(50)]
        public string? Address2 { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [StringLength(10)]
        public string? PostCode { get; set; }

        public int? CountryId { get; set; }

        [StringLength(50)]
        public string? Phone { get; set; }

        [StringLength(50)]
        public string? Mobile { get; set; }

        [Required]
        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? Note { get; set; }

        [StringLength(50)]
        public string? OEM { get; set; }

        [StringLength(50)]
        public string? Username { get; set; }

        [StringLength(50)]
        public string? Password { get; set; }

        [Required]
        public int StatusId { get; set; }

        // Navigation properties (optional)
        // public Country? Country { get; set; }
        // public Status? Status { get; set; }
    }

}

//Load Customer + Addresses in one query (Dapper multi-mapping)
//🔥 Build Create/Edit form with multiple addresses
//🔥 Save Customer + Addresses (master-detail insert)