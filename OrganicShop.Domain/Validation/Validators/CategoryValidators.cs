using FluentValidation;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.CategoryValidators
{
    public class CreateCategoryValidator : BaseValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {


        }
    }


    public class UpdateCategoryValidator : BaseValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
         

        }
    }



}
