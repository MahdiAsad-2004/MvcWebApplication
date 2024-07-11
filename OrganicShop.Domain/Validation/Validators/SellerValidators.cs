using FluentValidation;
using OrganicShop.Domain.Dtos.SellerDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.SellerValidators
{
    public class CreateSellerValidator : BaseValidator<CreateSellerDto>
    {
        public CreateSellerValidator()
        {


        }
    }


    public class UpdateSellerValidator : BaseValidator<UpdateSellerDto>
    {
        public UpdateSellerValidator()
        {
         

        }
    }



}
