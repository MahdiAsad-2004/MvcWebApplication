using MD.PersianDateTime;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace OrganicShop.Domain.Validation.Attributes
{
    public class GreaterThan : Attribute, IClientModelValidator
    {
        public string IndicatorPropertyName { get; set; }
        public string IndicatorPropertyDisplayName { get; set; }
        public string Comparator { get; set; }

        public GreaterThan(string indicatorPropertyName, string indicatorPropertyDisplayName, string? comparator = null)
        {
            IndicatorPropertyName = indicatorPropertyName;
            IndicatorPropertyDisplayName = indicatorPropertyDisplayName;
            Comparator = comparator;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            //context.Attributes.Add("data-val-lowerThan", $"000 باید از {PropertyDisplayName} {Comparator ?? "کمتر"} باشد");
            bool isDate = context.ModelMetadata.ModelType.IsAssignableFrom(typeof(DateTime)) || context.ModelMetadata.ModelType.IsAssignableFrom(typeof(DateTimeOffset))
               || context.ModelMetadata.ModelType.IsAssignableFrom(typeof(DateOnly)) || context.ModelMetadata.ModelType.IsAssignableFrom(typeof(PersianDateTime));
            context.Attributes.Add("data-val-greaterThan-type", isDate ? "date" : "number");
            context.Attributes.Add("data-val-greaterThan", $"'{context.ModelMetadata.DisplayName}' باید {Comparator ?? "بیشتر"} از '{IndicatorPropertyDisplayName}' باشد");
            context.Attributes.Add("data-val-greaterThan-indicatorName", $"{IndicatorPropertyName}");
            context.Attributes.TryAdd("data-val", "true");
        }

    }
}
