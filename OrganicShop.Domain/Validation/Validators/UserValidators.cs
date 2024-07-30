using FluentValidation;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.UserValidators
{

    public class CreateUserValidator : BaseValidator<CreateUserDto>
    {
        private readonly int FileSizeKb = 500;
        private readonly string[] FileFormats = { "jpg", "png", "jpeg" }; 
        
        public CreateUserValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .NotEmpty()
                .Length(2, 30);

            RuleFor(a => a.Password)
               .NotNull()
               .NotEmpty()
               .MinimumLength(6);

            RuleFor(a => new { a.Password, a.PasswordRepeat })
               .NotNull()
               .Must(a => a.Password == a.PasswordRepeat).WithMessage("رمز عبور و تکرار آن برابر نیستند");


            RuleFor(a => a.PhoneNumber)
               .NotNull()
               .NotEmpty()
               .Length(11, 11)
               .WithMessage("#PropertyName معتبر نیست");


            RuleFor(a => a.Email)
               .NotNull()
               .NotEmpty()
               .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            RuleFor(a => a.Role)
                .NotNull()
                .NotEmpty()
                .IsInEnum();


            //RuleFor(a => a.ProfileImage)
            //    .Must(a => true)
            //    .When(file => file != null)
            //    .Must(file => file.Length < FileSizeKb * 1024).WithMessage("").WithMessage($"حداکثر سایز #PropertyName {FileSizeKb} KB است")
            //    .Must(file => FileFormats.Contains(Path.GetExtension(file.FileName).Replace(".", "")))
            //        .WithMessage($"فرمت #PropertyName {string.Join(" / ", FileFormats)} نیست");            

        }

    }


    public class UpdateUserValidator : BaseValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .Length(2, 30);
        }
    }


    public class ChangePasswordValidator : BaseValidator<ChangePasswordDto>
    {
        public ChangePasswordValidator()
        {
            RuleFor(a => a.Password)
             .NotNull()
             .NotEmpty();

            RuleFor(a => a.NewPassword)
              .NotNull()
              .NotEmpty()
              .MinimumLength(8);

            RuleFor(a => new { a.NewPassword, a.NewPasswordRepeat })
               .NotNull()
               .Must(a => a.NewPassword == a.NewPasswordRepeat).WithMessage("رمز عبور و تکرار آن برابر نیستند");
        }
    }

}
