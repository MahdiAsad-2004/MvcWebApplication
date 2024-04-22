using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrganicShop.Domain.ValidationsAttributes
{
    public class FileFormat : ValidationAttribute, IClientModelValidator
    {
        public string[] Formats { get; set; }
        string FormatsString { get; set; }

        public FileFormat(string[] formats)
        {
            if (formats.Any(a => string.IsNullOrWhiteSpace(a)) || !formats.Any())
            {
                throw new ArgumentException("formats is empty.");
            }
            Formats = formats.Select(a => a.Trim().ToLower()).ToArray();
            FormatsString = string.Join("/", Formats);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-fileFormat", $"فرمت {context.ModelMetadata.DisplayName} {string.Join(" / ", Formats)} نیست");
            context.Attributes.Add("data-val-fileFormat-formats", $"{FormatsString}");
            context.Attributes.TryAdd("data-val", "true");

        }

    }
}
