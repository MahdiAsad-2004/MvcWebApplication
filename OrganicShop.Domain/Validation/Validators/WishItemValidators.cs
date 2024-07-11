using FluentValidation;
using OrganicShop.Domain.Dtos.WishItemDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.WishItemValidators
{
    public class CreateWishItemValidator : BaseValidator<CreateWishItemDto>
    {
        public CreateWishItemValidator()
        {


        }
    }


}
