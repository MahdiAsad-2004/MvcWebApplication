using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.BLL.Extensions;
using AutoMapper;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Enums;

namespace OrganicShop.BLL.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<Product, ProductListDto>()
                .ForMember(m => m.CategoryTitle, a => a.MapFrom(b => b.Categories.Last().Title))
                .ForMember(m => m.MainImageName, a => a.MapFrom(b => b.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage))
                .ForMember(m => m.IsActive, a => a.MapFrom(b => b.BaseEntity.IsActive));


            CreateMap<Product, ProductSummaryDto>()
               .ForMember(m => m.DiscountedPrice, a => a.MapFrom(b => b.DiscountedPrice))
               .ForMember(m => m.CategoryTitle, a => a.MapFrom(b => b.Categories.Last().Title))
               .ForMember(m => m.MainImageName, a => a.MapFrom(b => b.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage))
               .ForMember(m => m.ImageNames, a => a.MapFrom(b => b.Pictures.Select(p => p.Name).ToArray()))
               .ForMember(m => m.CommentsRate, a => a.MapFrom(b => 
                    b.Comments.Where(c => c.Status == CommentStatus.Accepted).Any() ?   
                    ((float)b.Comments.Where(c => c.Status == CommentStatus.Accepted).Sum(c => c.Rate) / 
                    (float)b.Comments.Where(c => c.Status == CommentStatus.Accepted).Count()) : 0))
               .ForMember(m => m.CommentsCount, a => a.MapFrom(b => b.Comments.Where(c => c.Status == CommentStatus.Accepted).Count()))
               .ForMember(m => m.Properties, a => a.MapFrom(b => b.Properties.OrderBy(p => p.Priority).Take(4).ToArray()))
               .ForMember(m => m.IsActive, a => a.MapFrom(b => b.BaseEntity.IsActive))
               .ForMember(m => m.Varients, a => a.MapFrom(b => b.ProductVarients.ToArray()));


            CreateMap<Product, ProductDetailDto>()
               .ForMember(m => m.DiscountedPrice, a => a.MapFrom(b => b.DiscountedPrice))
               .ForMember(m => m.MainImageName, a => a.MapFrom(b => b.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage))
               .ForMember(m => m.ImageNames, a => a.MapFrom(b => b.Pictures.Select(p => p.Name).ToArray()))
               .ForMember(m => m.Properties, a => a.MapFrom(b => b.Properties.OrderBy(p => p.Priority).ToArray()))
               .ForMember(m => m.Comments, a => a.MapFrom(b => b.Comments.Where(c => c.Status == CommentStatus.Accepted).Select(c => c.ToListDto()).ToList()))
               .ForMember(m => m.Discount, a => a.MapFrom(b => b.GetDefaultDiscount()))
               .ForMember(m => m.CategoryId, a => a.MapFrom(b => b.Categories.First().Id))
               .ForMember(m => m.SellerInfo, a => a.MapFrom(b => b.Seller == null ? default(object) : 
                    ValueTuple.Create(
                        b.Seller.Title,
                        b.Seller.Description,
                        b.Seller.Picture != null ? b.Seller.Picture.Name:PathExtensions.SellerDefaultImage,
                        b.Seller.Address.Text,
                        b.Seller.Address.Phone,
                        b.Seller.Comments.Count,
                        b.Seller.Comments.Any() ? (float)b.Seller.Comments.Sum(a => a.Rate) / (float)b.Seller.Comments.Count() : 0
                        )))
               .ForMember(m => m.Varients, a => a.MapFrom(b => b.ProductVarients.ToArray()));


            CreateMap<CreateProductDto, Product>()
                .ForMember(m => m.Description , a => a.MapFrom(b => string.IsNullOrEmpty(b.Description) ? string.Empty : b.Description));



            CreateMap<UpdateProductDto, Product>()
                .ForMember(m => m.Description, a => a.MapFrom(b => string.IsNullOrEmpty(b.Description) ? string.Empty : b.Description));


            CreateMap<Product, UpdateProductDto>()
                .ForMember(m => m.TagIds, a => a.MapFrom(b => b.TagProducts.Select(t => t.TagId).ToArray()))
                .ForMember(m => m.UpdatedPrice, a => a.MapFrom(b => b.GetDefaultDiscountedPriceProduct()))
                .ForMember(m => m.DiscountCount, a => a.MapFrom(b => b.GetDefaultDiscountProduct() != null ? b.GetDefaultDiscountProduct().Count : null))
                .ForMember(m => m.DiscountId, a => a.MapFrom(b => b.GetDefaultDiscountProduct() != null ? b.GetDefaultDiscountProduct().Id : default(int?)))
                .ForMember(m => m.PropertiesDic, a => a.MapFrom(b => b.Properties.ToDictionary(k => k.BaseId.Value,v => new EditPropertyDto {Id = v.Id ,Value = v.Value})))
                .ForMember(m => m.MainPictureName, a => a.MapFrom(b => b.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage))
                .ForMember(m => m.CategoryId, a => a.MapFrom(b => b.Categories.Last().Id))
                .ForMember(m => m.OldPicturesDic, a => a.MapFrom(b => b.Pictures.Where(a => a.IsMain == false).ToDictionary(k => k.Id , v => v.Name)));



            CreateMap<Product, ComboDto<Product>>()
             .ForMember(m => m.Value, a => a.MapFrom(b => b.Id))
             .ForMember(m => m.Text, a => a.MapFrom(b => b.Title));

        }

    }


    public static class ProductMappers
    {
        public static Product ToModel(this Product product)
        {
            return new Product
            {
                BaseEntity = product.BaseEntity,
                Categories = product.Categories != null ? product.Categories!.OrderByDescending(a => a.Id).ToList() : product.Categories,
                Comments = product.Comments/*.Where(a => a.Status == CommentStatus.Accepted).ToList()*/,
                Description = product.Description,
                DiscountProducts = product.DiscountProducts,
                Id = product.Id,
                Pictures = product.Pictures,
                Price = product.Price,
                ProductItems = product.ProductItems,
                Properties = product.Properties,
                ShortDescription = product.ShortDescription,
                SoldCount = product.SoldCount,
                Stock = product.ProductVarients.Any() ? product.ProductVarients.Sum(b => b.Stock) : product.Stock,
                TagProducts = product.TagProducts,
                Title = product.Title,
                //DiscountedPrice = product.GetDefaultDiscountedPrice(),
                DiscountedPrice = product.GetDefaultDiscountedPrice(),
            };
        }

    }
}