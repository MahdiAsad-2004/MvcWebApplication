
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.WishItemDtos
{
    public class WishItemListDto : BaseListDto<long>
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }

    }
}
