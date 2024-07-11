
using FluentValidation;
using OrganicShop.Domain.Dtos.ShippingMethodDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.ShippingMethodValidators
{
    public class CreateShippingMethodValidator : BaseValidator<CreateShippingMethodDto>
    {
        public CreateShippingMethodValidator()
        {


        }
    }


    public class UpdateShippingMethodValidator : BaseValidator<UpdateShippingMethodDto>
    {
        public UpdateShippingMethodValidator()
        {
         

        }
    }



}
