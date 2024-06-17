using FluentValidation;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.Validators
{
    public class CreateUserValidator : BaseValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .Length(2, 30)
                .NotNull();








        }

    }

}
