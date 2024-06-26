﻿using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.SellerDtos
{
    public class SellerSummaryDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string AddressText { get; set; }
        public string AddressProvince { get; set; }
        public string AddressPhone { get; set; }
        public string MainImageName { get; set; }
        public PersianDateTime RegisterDate { get; set; }
        public int ProductsCount { get; set; }
        public float CommentsRate { get; set; }
        public int CommentsCount { get; set; }


    }





}
