using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.SellerDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.NotificationDtos;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.EnumValues;

namespace OrganicShop.BLL.Mappers
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {

            CreateMap<Seller, SellerListDto>();


            CreateMap<Seller, SellerSummaryDto>()
                .ForMember(m => m.RegisterDate, a => a.MapFrom(b => b.BaseEntity.CreateDate.ToPersianDate()))
                .ForMember(m => m.CommentsCount, a => a.MapFrom(b => b.Comments.Count()))
                .ForMember(m => m.CommentsCount, a => a.MapFrom(b => b.Comments.Count()))
                .ForMember(m => m.CommentsRate, a => a.MapFrom(b => b.Comments.Any() ? (float)b.Comments.Sum(c => c.Rate)/(float)b.Comments.Count : 0))
                .ForMember(m => m.AddressProvince, a => a.MapFrom(b => b.Address.Province.ToStringValue()))
                .ForMember(m => m.AddressPhone, a => a.MapFrom(b => b.Address.PhoneNumber))
                .ForMember(m => m.MainImageName, a => a.MapFrom(b => b.Picture != null ? b.Picture.Name : PathExtensions.SellerDefaultImage))
                .ForMember(m => m.AddressText, a => a.MapFrom(b => b.Address.Text));


            CreateMap<UpdateSellerDto, Seller>() //;
                .ForPath(m => m.BaseEntity.IsActive, a => a.MapFrom(b => b.IsActive));


            CreateMap<Seller, UpdateSellerDto>()
                .ForMember(m => m.IsActive, a => a.MapFrom(b => b.BaseEntity.IsActive));

        }
    }


    public static class SellerMappers
    {
        public static Seller ToModel(this Seller seller)
        {
            return new Seller
            {
                Address = seller.Address,
                BaseEntity = seller.BaseEntity,
                Comments = seller.Comments.Where(a => a.Status == CommentStatus.Accepted).ToList(),
                Description = seller.Description,
                Id = seller.Id,
                Picture = seller.Picture,
                Products = seller.Products,
                Title = seller.Title,
                User = seller.User,
                UserId = seller.UserId,
            };
        }
    }

}
