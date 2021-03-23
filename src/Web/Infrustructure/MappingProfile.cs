using AutoMapper;
using Domain.Dtos;
using Domain.Entities.AggregatesModel;
using Web.Models;

namespace Web.Infrustructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapFromDomainObject();
            MapToDomainObject();
            MapToViewModel();
            MapFromViewModel();
        }

        private void MapFromDomainObject()
        {
            CreateMap<Contact, ContactDto>()
                .ForMember(dest => dest.FullName, opts => opts.MapFrom(src => src.FullName.ToString()))

                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber.Value))

                .ForMember(dest => dest.EmailAddress, opts => opts.MapFrom(src => src.EmailAddress.Value))

                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.Address.ToString()))

                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FullName.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.FullName.LastName))

                .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.Address.State))
                .ForMember(dest => dest.Street, opts => opts.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.ZipCode, opts => opts.MapFrom(src => src.Address.ZipCode));

        }

        private void MapToDomainObject()
        {
            CreateMap<ContactDto, Contact>();
        }


        private void MapToViewModel()
        {
            CreateMap<ContactDto, ContactFormModel>();
        }

        private void MapFromViewModel()
        {
            CreateMap<ContactFormModel, ContactDto>();
        }
    }
}
