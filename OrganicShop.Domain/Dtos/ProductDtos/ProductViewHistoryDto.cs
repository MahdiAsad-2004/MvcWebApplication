using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class ProductHistoryViewDto : BaseDto
    {
        public long ProductId { get; set; }

        public DateTime ViewDate { get; set; }


    }


}
