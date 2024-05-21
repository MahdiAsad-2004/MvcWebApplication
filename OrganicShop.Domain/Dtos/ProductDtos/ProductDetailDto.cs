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
        public int CategoryId { get; set; }
        public int? DiscountedPrice { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string MainImageName { get; set; }
        public string[] ImageNames { get; set; }

        public (
            string Title,
            string Description,
            string ImageName,
            string AddressText,
            string Phone,
            int CommentsCount,
            float CommentsRate)?
            SellerInfo { get; set; }
        
        public List<CommentListDto> Comments { get; set; }
        public ProductVarient[] Varients { get; set; }
        public Discount? Discount { get; set; }
        public Property[] Properties { get; set; }




    }


}
