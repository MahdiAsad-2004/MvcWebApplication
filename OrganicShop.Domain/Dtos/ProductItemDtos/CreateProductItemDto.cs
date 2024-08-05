using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ProductItemDtos
{
    public class CreateProductItemDto : BaseDto
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
    }

}
