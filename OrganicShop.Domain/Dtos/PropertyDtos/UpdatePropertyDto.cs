using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.PropertyDtos
{
    public class UpdatePropertyDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public int Priority { get; set; }
    }

}
