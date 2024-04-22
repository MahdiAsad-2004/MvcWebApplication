﻿using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("محصول")]
    public class ProductItem : EntityId<long>
    {
        public string Title { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int? UpdatedPrice { get; set; }
        public long? CartId { get; set; }
        public long? OrderId { get; set; }
        public bool IsOrdered { get; set; }




        public Product Product { get; set; }
        public Cart? Cart { get; set; }
        public Order? Order { get; set; }
    }
}
