using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.ContactUsDtos;
using AutoMapper;

namespace OrganicShop.BLL.Mappers
{
    public class ContactUsProfile : Profile
    {
        public ContactUsProfile()
        {

            CreateMap<UpdateContactUsDto, ContactUs>().ReverseMap();

        }

    }

}
