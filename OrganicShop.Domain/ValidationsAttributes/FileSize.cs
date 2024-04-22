using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.ValidationsAttributes
{
    public class FileSize : ValidationAttribute, IClientModelValidator
    {
        public int Size { get; set; }

        public FileSize(int sizeKB)
        {
            Size = sizeKB;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-fileSize", $"حداکثر سایز {context.ModelMetadata.DisplayName} {Size} KB است");
            context.Attributes.Add("data-val-fileSize-max", $"{Size}");
            context.Attributes.TryAdd("data-val", "true");

        }

    }
}
