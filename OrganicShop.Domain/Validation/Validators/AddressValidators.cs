using FluentValidation;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.AddressValidators
{
    public class CreateAddressValidator : BaseValidator<CreateAddressDto>
    {
        public CreateAddressValidator()
        {
            RuleFor(a => a.Title)
                .NotNull()
                .NotEmpty()
                .Length(2, 30);

            RuleFor(a => a.ReceiverName)
                .NotNull()
                .NotEmpty()
                .Length(2, 30);

            RuleFor(a => a.Text)
                .NotNull()
                .NotEmpty()
                .Length(2, 100);

            RuleFor(a => a.PostCode)
                .NotNull()
                .NotEmpty()
                .Length(10, 10).WithMessage("#PropertyName معتبر نیست");

            RuleFor(a => a.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .Length(11, 11).WithMessage("#PropertyName معتبر نیست");

            RuleFor(a => a.Province)
              .NotNull()
              .NotEmpty()
              .IsInEnum();

            RuleFor(a => a.UserId)
                .GreaterThanOrEqualTo(1).WithMessage("#PropertyName معتبر نیست");



        }
    }


    public class UpdateAddressValidator : BaseValidator<UpdateAddressDto>
    {
        public UpdateAddressValidator()
        {
            RuleFor(a => a.Title)
                .NotNull()
                .NotEmpty()
                .Length(2, 30);

            RuleFor(a => a.ReceiverName)
                .NotNull()
                .NotEmpty()
                .Length(2, 30);

            RuleFor(a => a.Text)
                .NotNull()
                .NotEmpty()
                .Length(2, 100);

            RuleFor(a => a.PostCode)
                .NotNull()
                .NotEmpty()
                .Length(10, 10).WithMessage("#PropertyName معتبر نیست");

            RuleFor(a => a.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .Length(11, 11).WithMessage("#PropertyName معتبر نیست");

            RuleFor(a => a.Province)
              .NotNull()
              .NotEmpty()
              .IsInEnum();




        }
    }



}
