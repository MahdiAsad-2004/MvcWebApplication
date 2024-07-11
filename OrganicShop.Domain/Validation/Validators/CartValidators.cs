using FluentValidation;
using OrganicShop.Domain.Dtos.CartDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.CartValidators
{
    public class CreateCartValidator : BaseValidator<CreateCartDto>
    {
        public CreateCartValidator()
        {


        }
    }


    public class UpdateCartValidator : BaseValidator<UpdateCartDto>
    {
        public UpdateCartValidator()
        {
         

        }
    }



}
