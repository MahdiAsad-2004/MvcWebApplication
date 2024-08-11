using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.ComplexTypes;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class OrderDetailDto : BaseListDto<long>
    {
        public string TrackingCode { get; set; }
        public int TotalPrice { get; set; }
        public int CouponAmount { get; set; }
        public int ShippingPrice { get; set; }
        public int FinalPrice { get; set; }
        public string ShippingMethodName { get; set; }
        public PersianDateTime SendDate { get; set; }
        public PersianDateTime CreateDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderAddress OrderAddress { get; set; }




        public OrderItemDto[] OrderItems { get; set; }


    }




}
