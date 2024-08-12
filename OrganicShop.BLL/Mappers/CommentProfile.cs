using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.CommentDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.CommentDtos;
using AutoMapper.Execution;
using OrganicShop.Domain.Enums;

namespace OrganicShop.BLL.Mappers
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentListDto>()
                .ForMember(m => m.Date, a => a.MapFrom(b => b.BaseEntity.CreateDate.ToPersianDate()))
                .ForMember(m => m.Email, a => a.MapFrom(b => b.User != null ? b.User.Email : b.Email))
                .ForMember(m => m.AuthorImageName, a => a.MapFrom(b => b.User != null ? b.User.Picture!.Name : PathExtensions.UserDefaultImageName))
                .ForMember(m => m.AuthorName, a => a.MapFrom(b => b.User != null ? b.User.Name : b.AuthorName));


            CreateMap<CreateCommentDto, Comment>()
                .ForMember(m => m.IsFeedback , a => a.MapFrom(b => false))
                .ForMember(m => m.Rate , a => a.MapFrom(b => 0))
                .ForMember(m => m.Email , a => a.MapFrom(b => b.UserId > 0 ? b.Email : null))
                .ForMember(m => m.AuthorName , a => a.MapFrom(b => b.UserId > 0 ? b.AuthorName : null))
                .ForMember(m => m.Status , a => a.MapFrom(b => CommentStatus.Unread));


            CreateMap<CreateCommentFeedbackUserDto, Comment>()
                .ForMember(m => m.Status , a => a.MapFrom(b => CommentStatus.Unread))
                .ForMember(m => m.ArticleId , a => a.MapFrom(b => default(int?)))
                .ForMember(m => m.IsFeedback , a => a.MapFrom(b => true));


            CreateMap<UpdateCommentDto, Comment>();

        }
    }

    public static class CommentMappers
    {
        public static CommentListDto ToListDto(this Comment comment)
        {
            return new CommentListDto
            {
                Date = comment.BaseEntity.CreateDate.ToPersianDate(),
                Id = comment.Id,
                Rate = comment.Rate,
                Status = comment.Status,
                Text = comment.Text,
                AuthorName = comment.User != null ? comment.User.Name : comment.AuthorName!,
                Email = comment.User != null ? comment.User.Email : comment.Email!,
                AuthorImageName = comment.User != null ? comment.User.Picture!.Name : PathExtensions.UserDefaultImageName,
            };
        }
    }


}
