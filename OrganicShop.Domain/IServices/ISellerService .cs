using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.SellerDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ISellerService : IService<Seller>
    {
        Task<ServiceResponse<PageDto<Seller, SellerListDto, int>>> GetAll(FilterSellerDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<PageDto<Seller, SellerSummaryDto, int>>> GetAllSummary(FilterSellerDto? filter = null, PagingDto? paging = null);

        Task<ServiceResponse<SellerDetailDto>> GetDetail(int Id);

        Task<ServiceResponse<Empty>> Create(CreateSellerDto create);

        Task<ServiceResponse<Empty>> Update(UpdateSellerDto update);
        
        Task<ServiceResponse<Empty>> Delete(int delete);


    }
}
