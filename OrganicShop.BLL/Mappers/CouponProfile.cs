using AutoMapper;
using OrganicShop.Domain.Dtos.CouponDtos;
using OrganicShop.Domain.Dtos.CouponDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {

            CreateMap<Coupon, CouponListDto>();


            CreateMap<CreateCouponDto, Coupon>();


            CreateMap<UpdateCouponDto, Coupon>();

        }
    }



    public static class CouponMappers
    {
        public static CouponApplyingDto ToApplyDto(this Coupon coupon, int? totalCost, Product[]? targetProducts)
        {
            return new CouponApplyingDto
            {
                Count = coupon.Count,
                EndDate = coupon.EndDate,
                Id = coupon.Id,
                MaxCost = coupon.MaxCost,
                MinCost = coupon.MinCost,
                StartDate = coupon.StartDate,
                TotalCost = totalCost,
                UsedCount = coupon.UsedCount,
                CouponCategories = coupon.CouponCategories.ToArray(),
                TargetProducts = targetProducts,
                Code = coupon.Code,
            };
        }


    }


}
