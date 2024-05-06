using AutoMapper;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {

            CreateMap<Address,AddressListDto>();


            CreateMap<CreateArticleDto,Address>();
            

            CreateMap<UpdateArticleDto,Address>();
        
        }


    }
}
