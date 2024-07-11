using FluentValidation;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.ProductValidators
{
    public class CreateProductValidator : BaseValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {


        }
    }


    public class UpdateProductValidator : BaseValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
         

        }
    }



}
