using AutoMapper;
using Microsoft.AspNetCore.Http;
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

            //CreateMap<UpdatePictureDto, Picture>();

            CreateMap<IFormFile, Picture>()
                .ForMember(m => m.Name, a => a.MapFrom(b => b.Name))
                .ForMember(m => m.SizeMB, a => a.MapFrom(b => b.Length / 1024 / 1000))
                .ForMember(m => m.BaseEntity, a => a.MapFrom(b => new BaseEntity(true)));


            CreateMap<Picture, UpdatePictureDto>();

        }


    }
}
