using FluentValidation;
using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.FaqValidators
{
    public class CreateFaqValidator : BaseValidator<CreateFaqDto>
    {
        public CreateFaqValidator()
        {


        }
    }


    public class UpdateFaqValidator : BaseValidator<UpdateFaqDto>
    {
        public UpdateFaqValidator()
        {
         

        }
    }



}
