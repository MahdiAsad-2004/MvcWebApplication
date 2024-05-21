using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.SellerDtos
{
    public class SellerSummaryDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string AddressText { get; set; }
        public string Phone { get; set; }
        public PersianDateTime RegisterDate { get; set; }


    }





}
