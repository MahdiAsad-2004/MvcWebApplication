using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.AddressDtos
{
    public class AddressListDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ReceiverName { get; set; }
        public Province Province { get; set; }




    }

}
