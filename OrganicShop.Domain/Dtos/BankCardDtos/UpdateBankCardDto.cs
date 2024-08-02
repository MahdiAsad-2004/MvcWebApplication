using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.BankCardDtos
{
    public class UpdateBankCardDto : BaseListDto<long>
    {
        public string Cvv2 { get; set; }
        public string Number { get; set; }
        public string ExpireDate { get; set; }
        public string OwnerName { get; set; }
    }



}
