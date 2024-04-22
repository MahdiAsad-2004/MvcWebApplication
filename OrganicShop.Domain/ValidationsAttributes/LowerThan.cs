using MD.PersianDateTime;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace OrganicShop.Domain.ValidationsAttributes
{
    public class LowerThan : Attribute, IClientModelValidator
    {
        public string IndicatorPropertyName { get; set; }
        public string IndicatorPropertyDisplayName { get; set; }
        public string Comparator { get; set; }

        public LowerThan(string indicatorPropertyName, string indicatorPropertyDisplayName, string? comparator = null)
        {
            IndicatorPropertyName = indicatorPropertyName;
            IndicatorPropertyDisplayName = indicatorPropertyDisplayName;
            Comparator = comparator;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            bool isDate = context.ModelMetadata.ModelType.IsAssignableFrom(typeof(DateTime)) || context.ModelMetadata.ModelType.IsAssignableFrom(typeof(DateTimeOffset))
                || context.ModelMetadata.ModelType.IsAssignableFrom(typeof(DateOnly)) || context.ModelMetadata.ModelType.IsAssignableFrom(typeof(PersianDateTime));
            context.Attributes.Add("data-val-lowerThan-type", isDate ? "date" : "number");
            context.Attributes.Add("data-val-lowerThan", $"'{context.ModelMetadata.DisplayName}' باید {Comparator ?? "کمتر"} از '{IndicatorPropertyDisplayName}' باشد");
            context.Attributes.Add("data-val-lowerThan-indicatorName", $"{IndicatorPropertyName}");
            context.Attributes.TryAdd("data-val", "true");
        }

    }
}
