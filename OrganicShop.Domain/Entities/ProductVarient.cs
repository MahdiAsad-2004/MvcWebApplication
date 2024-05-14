﻿using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("متغیر محصول")]
    public class ProductVarient : EntityId<long>
    {
        public VarientType Type { get; set; }
        public string Value { get; set; }
        public int Count { get; set; }
        public int? Price { get; set; }
        public long ProductId { get; set; }



        public Product Product { get; set; }
        
    }
}
