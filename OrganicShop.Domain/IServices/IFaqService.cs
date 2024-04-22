using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IFaqService : IService<Faq>
    {
        Task<ServiceResponse<PageDto<Faq, FaqListDto, byte>>> GetAll(FilterFaqDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateFaqDto create);

        Task<ServiceResponse<Empty>> Update(UpdateFaqDto update);
        
        Task<ServiceResponse<Empty>> Delete(byte delete);
        
    }
}
