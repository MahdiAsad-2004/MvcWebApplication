using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.ArticleDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;
using System.Xml.Schema;

namespace OrganicShop.Domain.IServices
{
    public interface IArticleService : IService<Article>
    {
        Task<ServiceResponse<PageDto<Article, ArticleListDto, int>>> GetAll(FilterArticleDto? filter = null ,PagingDto? paging = null);

        Task<ServiceResponse<ArticleDetailDto>> GetDetail(int? id = null, string? title = null);

        Task<ServiceResponse<Empty>> Create(CreateArticleDto create);

        Task<ServiceResponse<Empty>> Update(UpdateArticleDto update);
        
        Task<ServiceResponse<Empty>> Delete(int delete);
        
    }
}
