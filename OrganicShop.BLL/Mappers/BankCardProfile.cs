using AutoMapper;
using OrganicShop.Domain.Dtos.BankCardDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public class BankCardProfile : Profile
    {
        public BankCardProfile()
        {

            CreateMap<BankCard, BankCardListDto>();


            CreateMap<CreateBankCardDto, BankCard>();


            CreateMap<UpdateBankCardDto, BankCard>();

        }









    }
}
