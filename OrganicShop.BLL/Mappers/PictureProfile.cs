using AutoMapper;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Crypto.Parameters;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;


namespace OrganicShop.BLL.Mappers
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {

            CreateMap<Picture, PictureListDto>();



            //CreateMap<CreatePictureDto, Picture>();

            
            //CreateMap<UpdatePictureDto, Picture>()
            //    .ForMember(m => m.SizeMB, a => a.MapFrom(b => b.ImageFIle != null ? b.ImageFIle.GetSizeMB() : ))
            //    .ForMember(m => m.Name , a => a.MapFrom(b => b.ImageFIle.GenerateFileName()));


            CreateMap<IFormFile, Picture>()
                .ForMember(m => m.Name, a => a.MapFrom(b => b.Name))
                .ForMember(m => m.SizeMB, a => a.MapFrom(b => b.Length / 1024 / 1000))
                .ForMember(m => m.BaseEntity, a => a.MapFrom(b => new BaseEntity(true)));


            CreateMap<Picture, UpdatePictureDto>();

        }
    }

    public static class PictreMapper
    {
        public static Picture ToPicture(this UpdatePictureDto update , Picture picture)
        {
            picture.ArticleId = update.ArticleId;
            picture.ProductId = update.ProductId;
            picture.CategoryId = update.CategoryId;
            picture.SellerId = update.SellerId;
            picture.IsMain = update.IsMain;
            if(update.ImageFIle != null)
            {
                picture.Name = update.ImageFIle.GenerateFileName();
                picture.SizeMB = update.ImageFIle.GetSizeMB();
            }
            return picture;
        }

    }


}
