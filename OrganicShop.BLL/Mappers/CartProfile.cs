using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.CartDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.ProductItemDtos;

namespace OrganicShop.BLL.Mappers
{
    public class CartProfile : Profile
    {

        public CartProfile()
        {

            CreateMap<Cart, CartListDto>()
                .ForMember(m => m.ProductsCount, a => a.MapFrom(b => b.ProductItems.Count));


            CreateMap<Cart, CartDetailDto>()
                .ForMember(m => m.Bill, a => a.MapFrom(b => CartMappers.ToBillDto(b.ProductItems.ToArray(), null)))
                .ForMember(m => m.ProductItems, a => a.MapFrom(b => b.ProductItems.Select(a => a.ToListDto()).ToArray()));


            CreateMap<CreateCartDto, Cart>();


            CreateMap<UpdateCartDto, Cart>();

        }

    }


    public static class CartMappers
    {
        public static CartDetailDto ToDetailDto(List<ProductItemListDto> productItemListDtos, Coupon? coupon)
        {
            var cartDetailDto = new CartDetailDto
            {
                Id = productItemListDtos.First().CartId ?? 0,
                ProductItems = productItemListDtos.ToArray(),
                Bill = ToBillDto(productItemListDtos, coupon),
            };
            return cartDetailDto;
        }


        public static BillDto ToBillDto(ProductItem[] productItems, Coupon? coupon)
        {
            var billDto = new BillDto
            {
                TotalPrice = productItems
                    .Select(a => new { price = (a.Product.DiscountedPrice != null ? a.Product.DiscountedPrice.Value : a.Product.Price), count = a.Count })
                    .Sum(a => a.price * a.count),
                CouponCode = coupon != null ? coupon.Code : string.Empty,
                CouponId = coupon != null ? coupon.Id : 0,
            };
            billDto.CouponAmount = coupon != null ? coupon.GetAmount(billDto.TotalPrice) : 0;
            return billDto;
        }

        public static BillDto ToBillDto(List<ProductItemListDto> productItemListDtos, Coupon? coupon)
        {
            var billDto = new BillDto
            {
                TotalPrice = productItemListDtos.Sum(a => (a.ProductDiscountedPrice != null ? a.ProductDiscountedPrice.Value : a.ProductPrice) * a.Count),
                CouponCode = coupon != null ? coupon.Code : string.Empty,
                CouponId = coupon != null ? coupon.Id : 0,
            };
            billDto.CouponAmount = coupon != null ? coupon.GetAmount(billDto.TotalPrice) : 0;
            return billDto;
        }
        

    }
}
