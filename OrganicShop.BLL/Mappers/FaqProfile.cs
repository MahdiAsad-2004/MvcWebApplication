using AutoMapper;
using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public class FaqProfile : Profile
    {
        public FaqProfile()
        {

            CreateMap<Faq, FaqListDto>();


            CreateMap<CreateFaqDto, Faq>();


            CreateMap<UpdateFaqDto, Faq>();

        }


    }
}
