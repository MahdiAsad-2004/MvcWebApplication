using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface INewsLetterMemberService : IService<NewsLetterMember>
    {
        Task<ServiceResponse<PageDto<NewsLetterMember, NewsLetterMemberListDto, int>>> GetAll(FilterNewsLetterMemberDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateNewsLetterMemberDto create);
        
        Task<ServiceResponse<Empty>> Update(UpdateNewsLetterMemberDto create);
        
        Task<ServiceResponse<Empty>> Delete(int delete);

        Task<bool> IsMemberOfNewsLetter(long UserId);


    }
}
