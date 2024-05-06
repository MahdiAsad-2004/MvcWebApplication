using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.AddressDtos
{
    public class UpdateAddressDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public long UserId { get; set; }
    }

}
