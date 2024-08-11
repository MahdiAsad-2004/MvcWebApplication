using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.BLL.Extensions;

namespace OrganicShop.BLL.Mappers
{
    public class ProductItemProfile : Profile
    {
        public ProductItemProfile()
        {

            CreateMap<ProductItem, ProductItemListDto>()
                .ForMember(m => m.Id, a => a.MapFrom(b => b.Id))
                .ForMember(m => m.ProductTitle, a => a.MapFrom(b => b.Product.Title))
                .ForMember(m => m.ProductPrice, a => a.MapFrom(b => b.Product.Price))
                .ForMember(m => m.ProductStock, a => a.MapFrom(b => b.Product.Stock))
                .ForMember(m => m.ProductMainImageName, a => a.MapFrom(b => b.Product.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage))
                //.ForMember(m => m.DiscountedPrice , a => a.MapFrom(b => b.Product.ToModel().DiscountedPrice))
                .ForMember(m => m.ProductDiscountedPrice, a => a.MapFrom(b => b.Product.DiscountedPrice))
                .ForMember(m => m.ProductBarcode, a => a.MapFrom(b => b.Product.Barcode));


            CreateMap<CreateProductItemDto, ProductItem>();


            CreateMap<UpdateProductItemDto, ProductItem>();



            CreateMap<CreateProductItemDto, ProductItemCookieDto>();

        }


    }


    public static class ProductItemMappers
    {
        public static OrderItemDto ToOrderItemDto(this ProductItem productItem)
        {
            return new OrderItemDto
            {
                Barcode = productItem.Product.Barcode,
                Count = productItem.Count,
                Id = productItem.Id,
                MainImageName = productItem.Product.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage,
                PurchasedPrice = productItem.PurchasedPrice,
                Title = productItem.Product.Title,
            };
        }

        public static ProductItemListDto ToListDto(this ProductItem productItem)
        {
            return new ProductItemListDto
            {
                ProductBarcode = productItem.Product.Barcode,
                Count = productItem.Count,
                Id = productItem.Id,
                ProductMainImageName = productItem.Product.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage,
                ProductPrice = productItem.Product.Price,
                ProductTitle = productItem.Product.Title,
                CartId = productItem.CartId,
                ProductDiscountedPrice = productItem.Product.DiscountedPrice,
                ProductId = productItem.ProductId,
                ProductStock = productItem.Product.Stock,
                ProductDiscounteId = productItem.Product.GetDiscountId()
            };
        }
        
        public static ProductItemListDto ToListDto(this ProductItemCookieDto productItemCookie , Product product)
        {
            return new ProductItemListDto
            {
                Id = product.Id,
                Count = productItemCookie.Count > product.Stock ? product.Stock : productItemCookie.Count,
                ProductId = productItemCookie.ProductId,
                ProductPrice = product.Price,
                ProductTitle = product.Title,
                ProductStock = product.Stock,
                ProductBarcode = product.Barcode,
                ProductDiscounteId = product.GetDiscountId(),
                ProductDiscountedPrice = product.DiscountedPrice,
                ProductMainImageName = product.Pictures != null ? 
                    (product.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage) : PathExtensions.ProductDefaultImage,
                CartId = 0,
            };
        }

        public static List<ProductItemListDto> ToListDtos(this List<ProductItemCookieDto> productItemCookies, List<Product> products)
        {
            List<ProductItemListDto> productItemListDtos = new List<ProductItemListDto>();
            Product? product = null;
            foreach (var productItemCookieDto in productItemCookies)
            {
                product = products.First(a => a.Id == productItemCookieDto.ProductId);
                productItemListDtos.Add(productItemCookieDto.ToListDto(product));
            }
            return productItemListDtos;
        }




    }

}
