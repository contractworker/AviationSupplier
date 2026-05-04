using AutoMapper;
using AviationSupplier.Web.Models;
using AviationSupplier.Web.ViewModel;

namespace AviationSupplier.Web.ViewModel.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerViewModel>()
                // Id (int → int?)
                .ForMember(d => d.Id,
                    opt => opt.MapFrom(src => src.Id))

                // RowId (not in source)
                .ForMember(d => d.RowId,
                    opt => opt.MapFrom(src => src.Id))

                // VAT → Vat (name mismatch)
                .ForMember(d => d.Vat,
                    opt => opt.MapFrom(src => src.VAT))

                // Nullable handling
                .ForMember(d => d.AccountNo,
                    opt => opt.MapFrom(src => src.AccountNo ?? 0))

                // Collections
                .ForMember(d => d.CustomerAddressViewModels,
                    opt => opt.MapFrom(src => src.CustomerAddresses))

                // Ignore properties not in source
                .ForMember(d => d.CountryName, opt => opt.Ignore())
                .ForMember(d => d.CountryViewModels, opt => opt.Ignore());

            CreateMap<CustomerAddress, CustomerAddressViewModel>();

            CreateMap<CustomerViewModel, Customer>()
           .ForMember(d => d.Id, opt => opt.MapFrom(s => s.RowId))
           .ForMember(d => d.VAT, opt => opt.MapFrom(s => s.Vat))
           .ForMember(d => d.AccountNo, opt => opt.MapFrom(s => s.AccountNo))
           .ForMember(d => d.CustomerAddresses,
               opt => opt.MapFrom(s => s.CustomerAddressViewModels));
        }
    }

    public class CustomerAddressProfile : Profile
    {
        public CustomerAddressProfile()
        {
            CreateMap<CustomerAddress, CustomerAddressViewModel>()
             .ForMember(d => d.AddressId, o => o.MapFrom(s => s.Id))
             .ForMember(d => d.FullAddress, o => o.MapFrom(s =>
                 string.Join(", ",
                     new[] { s.Address1, s.Address2, s.Address3, s.City, s.State, s.PostCode }
                     .Where(x => !string.IsNullOrWhiteSpace(x))
                 )))
             .ForMember(d => d.CountryName, o => o.Ignore());

            CreateMap<CustomerAddressViewModel, CustomerAddress>()
           .ReverseMap();
        }
    }
}