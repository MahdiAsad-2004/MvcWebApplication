using OrganicShop.Domain.Dtos.CouponDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ICouponService : IService<Coupon>
    {
        Task<ServiceResponse<PageDto<Coupon, CouponListDto, int>>> GetAll(FilterCouponDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<UpdateCouponDto>> Get(int Id);

        Task<ServiceResponse<Empty>> Create(CreateCouponDto create);

        Task<ServiceResponse<Empty>> Update(UpdateCouponDto update);
        
        Task<ServiceResponse<Empty>> Delete(int id);
        
    }
}
