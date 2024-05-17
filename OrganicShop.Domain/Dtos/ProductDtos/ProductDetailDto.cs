using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class ProductDetailDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int? DiscountedPrice { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string MainImageName { get; set; }
        public string[] ImageNames { get; set; }
        public List<CommentListDto> Comments { get; set; }
        public List<ProductVarient> Varients { get; set; }
        public Discount? Discount { get; set; }
        public Dictionary<string, string> PropertiesDictionary { get; set; }




    }


}
