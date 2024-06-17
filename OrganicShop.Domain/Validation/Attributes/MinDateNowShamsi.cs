using MD.PersianDateTime;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Validation.Attributes
{
    public class MinDateNowShamsi : ValidationAttribute, IClientModelValidator
    {
        public PersianDateTime Date { get; set; }

        public MinDateNowShamsi()
        {
            Date = PersianDateTime.Now.Date;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-MinDate", $"{context.ModelMetadata.DisplayName} باید بعد از {Date.ToShortDateString()} باشد");
            context.Attributes.Add("data-val-MinDate-min", $"{Date}");
            context.Attributes.TryAdd("data-val", "true");
        }

    }
}
