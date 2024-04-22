using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.ValidationsAttributes
{
    public class MaxDate : ValidationAttribute, IClientModelValidator
    {
        public DateTime Date { get; set; }

        public MaxDate(string dateString)
        {
            Date = DateTime.Parse(dateString);

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-maxDate", $"{context.ModelMetadata.DisplayName} باید بعد از {Date.ToShortDateString()} باشد");
            context.Attributes.Add("data-val-maxDate-max", $"{Date}");
            context.Attributes.TryAdd("data-val", "true");
        }

    }
}
