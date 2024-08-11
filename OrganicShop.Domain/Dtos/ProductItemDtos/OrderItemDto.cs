﻿using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.ProductItemDtos
{
    public class OrderItemDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public string Barcode { get; set; }
        public string MainImageName { get; set; }
        public int PurchasedPrice { get; set; }
        public int Count { get; set; }






    }




}
