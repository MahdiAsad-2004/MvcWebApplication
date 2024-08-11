using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Dtos.CouponDtos
{
    public class CouponApplyingDto : BaseListDto<int>
    {
        [DisplayName("کد نخفیف")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(10 , MinimumLength = 3 , ErrorMessage = "کد تخفیف نادرست است")]
        public string Code { get; set; }

        public long UserId { get; set; }
        
        public int? Count { get; set; }
        public int UsedCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaxCost { get; set; }
        public int? MinCost { get; set; }
        public CouponCategories[] CouponCategories { get; set; }


        public int? TotalCost { get; set; }
        public Product[]? TargetProducts { get; set; }
    
  
    
    }



}
