using OrganicShop.Domain.Dtos.OrderDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IOrderService : IService<Order>
    {
        Task<ServiceResponse<PageDto<Order, OrderListDto, long>>> GetAll(FilterOrderDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<OrderDetailDto>> GetDetail(string trackingCode);

        Task<ServiceResponse<string>> Create(CreateOrderDto create);

        Task<ServiceResponse<Empty>> Update(UpdateOrderDto update);
        
        Task<ServiceResponse<Empty>> Delete(long id);
        
    }
}
