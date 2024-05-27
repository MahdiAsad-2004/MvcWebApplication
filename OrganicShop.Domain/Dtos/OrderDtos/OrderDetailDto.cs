using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class OrderDetailDto : BaseListDto<long>
    {
        public string TrackingCode { get; set; }
        public int TotalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int DeliveryPrice { get; set; }
        public int FinalPrice { get; set; }
        public string DeliveryType { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


        public Address Address { get; set; }
        public OrderItemDto[] OrderItems { get; set; }


    }




}
