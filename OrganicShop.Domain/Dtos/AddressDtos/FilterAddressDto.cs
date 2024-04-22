using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.AddressDtos
{
    public class FilterAddressDto : BaseFilterDto<Entities.Address, long>
    {
        public long? UserId { get; set; }

        public BaseSortType SortBy { get; set; } = BaseSortType.None;

    }




}
