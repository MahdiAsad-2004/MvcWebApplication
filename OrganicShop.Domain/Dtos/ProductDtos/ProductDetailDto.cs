using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class ProductDetailDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string MainImage { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<Picture> ProductImages { get; set; }
        public Discount Discount { get; set; } = new Discount { IsDefault = true };

    }


}
