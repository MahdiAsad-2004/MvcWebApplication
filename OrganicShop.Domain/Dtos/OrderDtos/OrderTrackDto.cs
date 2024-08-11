using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.ComplexTypes;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class OrderTrackDto : BaseListDto<long>
    {
        public string TrackingCode { get; set; }
        public int TotalPrice { get; set; }
        public int CouponAmount { get; set; }
        public int ShippingPrice { get; set; }
        public int FinalPrice { get; set; }
        public string ShippingMethodName { get; set; }
        public DateTime DeliveryDateEstimated { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderAddress OrderAddress { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string UserName { get; set; }
        public string UserMainImageName { get; set; }


        public TrackingStatus[] TrackingStatuses { get; set; }
        public TrackingDescription[] TrackingDescriptions { get; set; }


    }




}
