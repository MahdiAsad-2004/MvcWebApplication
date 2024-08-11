using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CartDtos
{
    public class BillDto : BaseDto
    {
        public int TotalPrice { get; set; }
        public string CouponCode { get; set; }
        public int CouponAmount { get; set; }
        public int CouponId { get; set; }



    }
}
