using FluentValidation;
using OrganicShop.Domain.Dtos.NewsLetterDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.NewsLetterValidators
{
    public class CreateNewsLetterValidator : BaseValidator<CreateNewsLetterDto>
    {
        public CreateNewsLetterValidator()
        {


        }
    }


    public class UpdateNewsLetterValidator : BaseValidator<UpdateNewsLetterDto>
    {
        public UpdateNewsLetterValidator()
        {
         

        }
    }



}
