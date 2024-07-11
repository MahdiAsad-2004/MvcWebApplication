
using FluentValidation;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.PropertyValidators
{
    public class CreatePropertyValidator : BaseValidator<CreatePropertyDto>
    {
        public CreatePropertyValidator()
        {


        }
    }


    public class UpdatePropertyValidator : BaseValidator<UpdatePropertyDto>
    {
        public UpdatePropertyValidator()
        {
         

        }
    }



}
