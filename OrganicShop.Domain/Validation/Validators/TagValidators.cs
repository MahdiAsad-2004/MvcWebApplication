
using FluentValidation;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.TagValidators
{
    public class CreateTagValidator : BaseValidator<CreateTagDto>
    {
        public CreateTagValidator()
        {


        }
    }


    public class UpdateTagValidator : BaseValidator<UpdateTagDto>
    {
        public UpdateTagValidator()
        {
         

        }
    }



}
