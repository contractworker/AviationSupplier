using AutoMapper;
using AviationSupplier.Web.Models;
using AviationSupplier.Web.ViewModel;

namespace AviationSupplier.Web.ViewModel.AutoMapper
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            // =========================
            // ENTITY → VIEWMODEL
            // =========================
            CreateMap<Supplier, SupplierViewModel>()
                .ForMember(d => d.Id,
                    opt => opt.MapFrom(src => src.Id))

                // optional UI helper field
                .ForMember(d => d.RowId,
                    opt => opt.MapFrom(src => src.Id))

                // no naming mismatch here, but kept pattern consistent
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(src => src.Name))

                .ForMember(d => d.Website,
                    opt => opt.MapFrom(src => src.Website))

                // Ignore UI-only fields
                .ForMember(d => d.CountryName, opt => opt.Ignore())
                .ForMember(d => d.CountryViewModels, opt => opt.Ignore());

            // =========================
            // VIEWMODEL → ENTITY
            // =========================
            CreateMap<SupplierViewModel, Supplier>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Address1, opt => opt.MapFrom(s => s.Address1))
                .ForMember(d => d.Address2, opt => opt.MapFrom(s => s.Address2))
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.City))
                .ForMember(d => d.PostCode, opt => opt.MapFrom(s => s.PostCode))
                .ForMember(d => d.CountryId, opt => opt.MapFrom(s => s.CountryId))
                .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.Phone))
                .ForMember(d => d.Mobile, opt => opt.MapFrom(s => s.Mobile))
                .ForMember(d => d.Website, opt => opt.MapFrom(s => s.Website))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.Note, opt => opt.MapFrom(s => s.Note))
                .ForMember(d => d.OEM, opt => opt.MapFrom(s => s.OEM))
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(d => d.StatusId, opt => opt.MapFrom(s => s.StatusId));
        }
    }
}