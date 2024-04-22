using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.CommentDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.CommentDtos;
using AutoMapper.Execution;

namespace OrganicShop.BLL.Mappers
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentListDto>()
                .ForMember(m => m.Date, a => a.MapFrom(b => b.BaseEntity.CreateDate.ToPersianDate()))
                .ForMember(m => m.UserName, a => a.MapFrom(b => b.User.Name))
                .ForMember(m => m.ProductName, a => a.MapFrom(b => b.Product.Title));


            CreateMap<CreateCommentDto, Comment>();


            CreateMap<UpdateCommentDto, Comment>();

        }

    }
}
