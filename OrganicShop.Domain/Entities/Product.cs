using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("محصول")]
    public class Product : EntityId<long>
    {
        public int Price { get; set; }
        public string Title { get; set; }
        //public int Stock { get; set; }
        public int SoldCount { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }



        //public int? DiscountedPrice { get; set; }


        public int? DiscountedPrice
        {
            get
            {
                if (DiscountProducts != null)
                {
                    return this.GetDiscountedPrice();
                }
                return null;
            }
            set { }
        }


        public int Stock { get; set; }


        public string Barcode { get; set; }
        public int? SellerId { get; set; }







        #region realtions

        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<DiscountProducts> DiscountProducts { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; }
        public ICollection<TagProducts> TagProducts { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Seller? Seller { get; set; }
        public ICollection<WishItem> WishItems { get; set; }


        #endregion





        #region methods

        public int? GetDiscountedPrice()
        {
            Discount? discount;
            discount = this.DiscountProducts
                .Select(a => a.Discount)
                .Where(a => a.IsValid())
                .OrderBy(a => a.Priority)
                .FirstOrDefault(a => true);

            if (discount != null)
                return discount.CalculateDiscountedPrice(this.Price);

            return null;
        }


        #endregion






    }
}
