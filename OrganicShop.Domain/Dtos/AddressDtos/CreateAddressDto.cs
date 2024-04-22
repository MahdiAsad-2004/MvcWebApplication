using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.AddressDtos
{
    public class CreateAddressDto : BaseDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public long UserId { get; set; }
    }




}
