using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums.SortTypes
{
    public enum DiscountSortType
    {
        None,

        Newest,

        LatestChange,

        Oldest,


        Percent,

        PercentDesc,

        FixedValue,

        FixedValueDesc,

        Count,

        CountDesc,
    }
}
