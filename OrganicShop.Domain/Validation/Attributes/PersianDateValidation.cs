using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Validation.Attributes
{
    public class PersianDateValidation : ValidationAttribute, IClientModelValidator
    {

        public PersianDateValidation()
        {

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-PersianDate", $"تاریخ وارد شده معتبر نیست");
            context.Attributes.TryAdd("data-val", "true");
        }

    }
}
