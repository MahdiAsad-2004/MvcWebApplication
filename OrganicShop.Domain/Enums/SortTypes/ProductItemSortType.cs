﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums.SortTypes
{
    public enum ProductItemSortType
    {
        None,

        Newest,

        LatestChange,

        Oldest,


        PurchasedPrice,

        PurchasedPriceDesc,

        Count,

        CountDesc,
    }
}
