using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.ValidationsAttributes
{
    public class DuplicateEmail : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-duplicateEmail", $"{context.ModelMetadata.DisplayName} از قبل وجود دارد");
            context.Attributes.TryAdd("-val", "true");
        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }

        //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        //{
        //    //_fieldName = validationContext.DisplayName;

        //    validationContext.Items.Add("asdf", 123);

        //    return ValidationResult.Success;

        //    //return new ValidationResult(ErrorMessage ?? $"{_fieldName} Is Not Valid !!!");
        //}
    }
}
