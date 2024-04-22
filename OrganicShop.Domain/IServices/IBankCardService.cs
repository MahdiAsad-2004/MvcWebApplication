using OrganicShop.Domain.Dtos.BankCardDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IBankCardService : IService<BankCard>
    {
        Task<ServiceResponse<PageDto<BankCard, BankCardListDto, long>>> GetAll(FilterBankCardDto? filter = null, PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateBankCardDto create);

        Task<ServiceResponse<Empty>> Update(UpdateBankCardDto update);
        
        Task<ServiceResponse<Empty>> Delete(long delete);
        
    }
}
