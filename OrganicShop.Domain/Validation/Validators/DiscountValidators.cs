using FluentValidation;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.DiscountValidators
{
    public class CreateDiscountValidator : BaseValidator<CreateDiscountDto>
    {
        public CreateDiscountValidator()
        {


        }
    }


    public class UpdateDiscountValidator : BaseValidator<UpdateDiscountDto>
    {
        public UpdateDiscountValidator()
        {
         

        }
    }



}
