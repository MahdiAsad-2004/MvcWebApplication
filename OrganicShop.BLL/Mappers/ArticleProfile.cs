using AutoMapper;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.ArticleDtos;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.BLL.Mappers
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {

            CreateMap<Article,ArticleListDto>()
                .ForMember(m => m.CreateDate , a => a.MapFrom(b => b.BaseEntity.CreateDate.ToPersianDate()))
                .ForMember(m => m.CategoryTitle , a => a.MapFrom(b => b.Category.Title))
                .ForMember(m => m.AuthorName , a => a.MapFrom(b => b.User.Name))
                .ForMember(m => m.AuthorName , a => a.MapFrom(b => b.User.Name))
                .ForMember(m => m.MainImageName , a => a.MapFrom(b => b.Pictures.GetMainPictureName() ?? string.Empty));


            CreateMap<Article, ArticleDetailDto>()
                .ForMember(m => m.CreateDate, a => a.MapFrom(b => b.BaseEntity.CreateDate.ToPersianDate()))
                .ForMember(m => m.CategoryTitle, a => a.MapFrom(b => b.Category.Title))
                .ForMember(m => m.AuthorName, a => a.MapFrom(b => b.User.Name))
                .ForMember(m => m.AuthorName, a => a.MapFrom(b => b.User.Name))
                .ForMember(m => m.MainImageName, a => a.MapFrom(b => b.Pictures.GetMainPictureName() ?? string.Empty))
                .ForMember(m => m.TagIds, a => a.MapFrom(b => b.TagArticles.Select(t => t.TagId).ToArray()))
                .ForMember(m => m.Comments, a => a.MapFrom(b => b.Comments.Where(c => c.Status == CommentStatus.Accepted).Select(c => c.ToListDto())));


            CreateMap<CreateArticleDto,Article>();
            

            CreateMap<UpdateArticleDto,Article>();


            CreateMap<Article, UpdateArticleDto>()
                .ForMember(m => m.MainPictureName , a => a.MapFrom(b => b.Pictures.GetMainPictureName() ?? string.Empty))
                .ForMember(m => m.TagIds , a => a.MapFrom(b => b.TagArticles.Select(a => a.TagId).ToArray()));
       
            


        }


    }
}
