using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.ProductItemDtos
{
    public class UpdateProductItemDto : BaseListDto<long>
    {
        public int Count { get; set; }
        public long? CartId { get; set; }
        public long? OrderId { get; set; }
        public bool IsOrdered { get; set; }

    }

}
