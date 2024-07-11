using FluentValidation;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.ProductItemValidators
{
    public class CreateProductItemValidator : BaseValidator<CreateProductItemDto>
    {
        public CreateProductItemValidator()
        {


        }
    }


    public class UpdateProductItemValidator : BaseValidator<UpdateProductItemDto>
    {
        public UpdateProductItemValidator()
        {
         

        }
    }



}
