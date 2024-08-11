
using FluentValidation;
using OrganicShop.Domain.Dtos.CouponDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.CouponValidators
{
    public class CreateCouponValidator : BaseValidator<CreateCouponDto>
    {
        public CreateCouponValidator()
        {


        }
    }


    public class UpdateCouponValidator : BaseValidator<UpdateCouponDto>
    {
        public UpdateCouponValidator()
        {
         

        }
    }


    public class CouponApplyingValidator : BaseValidator<CouponApplyingDto>
    {
        public CouponApplyingValidator()
        {
            RuleFor(a => new { a.Count, a.UsedCount })
                .Must(a => a.Count != null ? a.Count > a.UsedCount : true).WithMessage("کد تخفیف ناموجود است");

            
            RuleFor(a => a.StartDate)
                .Must(startDate => startDate != null ? startDate.Value < DateTime.Now : true).WithMessage("کد تخفیف در حال حاضر قابل استفاده نیست");
            
            
            RuleFor(a => a.EndDate)
                .Must(endDate => endDate != null ? endDate.Value > DateTime.Now : true).WithMessage("انقضای کد تخفیف به پایان رسیده است");
            

            RuleFor(a => new {a.MinCost , a.TotalCost })
                .Must(a => a.TotalCost != null && a.MinCost != null ? a.MinCost.Value < a.TotalCost : true).WithMessage("حداقل ارزش سبد رعایت نشده است");
            

            RuleFor(a => new {a.MaxCost , a.TotalCost })
                .Must(a => a.TotalCost != null && a.MaxCost != null ? a.MaxCost.Value > a.TotalCost : true).WithMessage("حداکثر ارزش سبد رعایت نشده است");
            

            RuleFor(a => new 
            { 
                acceptedCategoryIds = a.CouponCategories.Select(b => b.CategoryId).ToArray() ,
                targetProducts = a.TargetProducts != null ? a.TargetProducts.ToList() : new List<Product>() 
            })
                .Must(a => a.targetProducts.Any() && a.acceptedCategoryIds.Any() ? Coupon.IsAcceptableForProducts(a.acceptedCategoryIds,a.targetProducts) : true)
                .WithMessage("محصولات مورد نظر شامل کد تخفیف نمیشود");



        }
    }
}
