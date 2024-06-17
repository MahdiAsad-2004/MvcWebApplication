using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Validation.Attributes
{
    public class FilesCount : ValidationAttribute, IClientModelValidator
    {
        public int MaxCount { get; set; }
        public int MinCount { get; set; }

        public FilesCount(int minCount, int maxCount)
        {
            MaxCount = maxCount;
            MinCount = minCount;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            //context.Attributes.Add("data-val-filesCount", $"حداکثر تعداد {context.ModelMetadata.DisplayName} {MaxCount} است");
            context.Attributes.Add("data-val-filesCount", $"حداقل تعداد {context.ModelMetadata.DisplayName} {MinCount} و حداکثر {MaxCount} است");
            context.Attributes.Add("data-val-filesCount-max", $"{MaxCount}");
            context.Attributes.Add("data-val-filesCount-min", $"{MinCount}");
            context.Attributes.TryAdd("data-val", "true");

        }

    }
}
