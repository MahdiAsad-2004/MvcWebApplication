using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.BankCardDtos
{
    public class FilterBankCardDto : BaseFilterDto<Entities.BankCard, long>
    {
        public long? UserId { get; set; }

        public BaseSortType SortBy { get; set; } = BaseSortType.None;
    }



}
