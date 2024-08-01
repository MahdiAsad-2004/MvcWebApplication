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

    public static class BankCardMappers
    {
        public static BankCardListDto ToListDto(this BankCard bankCard) 
        {
            return new BankCardListDto
            {
                Id = bankCard.Id,
                Cvv2 = bankCard.Cvv2,
                Number = bankCard.Number,
                ExpireDate = bankCard.ExpireDate,
                OwnerName = bankCard.OwnerName,
            };
        } 



    }


}
