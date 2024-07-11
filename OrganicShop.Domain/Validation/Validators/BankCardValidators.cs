using FluentValidation;
using OrganicShop.Domain.Dtos.BankCardDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.BankCardValidators
{
    public class CreateBankCardValidator : BaseValidator<CreateBankCardDto>
    {
        public CreateBankCardValidator()
        {


        }
    }


    public class UpdateBankCardValidator : BaseValidator<UpdateBankCardDto>
    {
        public UpdateBankCardValidator()
        {
         

        }
    }



}
