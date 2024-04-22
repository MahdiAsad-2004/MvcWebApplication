using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.Page
{
    public class PagingDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageItemsCount { get; set; } = 12;
    }
}
