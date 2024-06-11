using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("محصول")]
    public class Product : EntityId<long>
    {
        public int Price { get; set; }
        public string Title { get; set; }
        public int Stock { get; set; }
        public int SoldCount { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int? DiscountedPrice { get; set; }
        public string BarCode { get; set; }
        public int? SellerId { get; set; }


        public ICollection<Category> Categories { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<DiscountProducts> DiscountProducts { get; set; }
        public ICollection<CouponProducts> CouponProducts { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; }
        public ICollection<TagProducts> TagProducts { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ProductVarient> ProductVarients { get; set; }
        public Seller? Seller { get; set; }
        public ICollection<WishItem> WishItems { get; set; }

    }
}
