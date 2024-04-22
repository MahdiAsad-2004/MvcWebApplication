using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ICommentService : IService<Comment>
    {
        Task<ServiceResponse<PageDto<Comment, CommentListDto, long>>> GetAll(FilterCommentDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<CommentListDto>> Get(long Id);

        Task<ServiceResponse<Empty>> Create(CreateCommentDto create);

        Task<ServiceResponse<Empty>> Update(UpdateCommentDto update);
        
        Task<ServiceResponse<Empty>> Delete(long delete);
        
    }
}
