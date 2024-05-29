using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.SellerDtos
{
    public class SellerDetailDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string AddressText { get; set; }
        public string Phone { get; set; }
        public PersianDateTime RegisterDate { get; set; }
        public int ProductsCount { get; set; }
        public int CommentsRate { get; set; }
        public int CommentsCount { get; set; }


    }





}
