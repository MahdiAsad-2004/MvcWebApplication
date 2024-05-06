using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.NewsLetterDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface INewsLetterService : IService<NewsLetter>
    {
        Task<ServiceResponse<PageDto<NewsLetter, NewsLetterListDto, int>>> GetAll(FilterNewsLetterDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<UpdateNewsLetterDto>> Get(int Id);

        Task<ServiceResponse<Empty>> Create(CreateNewsLetterDto create);

        Task<ServiceResponse<Empty>> Update(UpdateNewsLetterDto update);
        
        Task<ServiceResponse<Empty>> Delete(int delete);

    }
}
