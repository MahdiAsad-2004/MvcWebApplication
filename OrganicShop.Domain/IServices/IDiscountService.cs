using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IDiscountService : IService<Discount>
    {
        Task<ServiceResponse<PageDto<Discount, DiscountListDto, int>>> GetAll(FilterDiscountDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<UpdateDiscountDto>> Get(int Id);

        Task<ServiceResponse<Empty>> Create(CreateDiscountDto create);

        Task<ServiceResponse<Empty>> Update(UpdateDiscountDto update);
        
        Task<ServiceResponse<Empty>> Delete(int id);
        
    }
}
