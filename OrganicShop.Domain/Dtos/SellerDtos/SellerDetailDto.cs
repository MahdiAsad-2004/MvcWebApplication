using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.SellerDtos
{
    public class SellerDetailDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string AddressText { get; set; }
        public string AddressPhone { get; set; }
        public string AddressProvince { get; set; }
        public PersianDateTime RegisterDate { get; set; }
        public int ProductsCount { get; set; }
        public string Description { get; set; }
        public string MainImageName { get; set; }



        public CommentListDto[] Comments { get; set; }


    }





}
