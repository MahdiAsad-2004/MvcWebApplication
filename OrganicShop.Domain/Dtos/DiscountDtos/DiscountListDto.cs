using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.DiscountDtos
{
    public class DiscountListDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public bool IsFixDiscount { get; set; }
        public DateTime CreateDate { get; set; }
        //public string Period { get; set; }
        public string? Code { get; set; }
        public int? Count { get; set; }
        public int? FixValue { get; set; }
        public int? Percent { get; set; }
        public PersianDateTime? StartDate { get; set; }
        public PersianDateTime? EndDate { get; set; }
        public int Priority { get; set; }
    }



}
