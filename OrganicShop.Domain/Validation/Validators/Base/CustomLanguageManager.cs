using FluentValidation.Resources;

namespace OrganicShop.Domain.Validation.Validators.Base
{
    public class CustomLanguageManager : LanguageManager
    {
        public CustomLanguageManager()
        {
            Culture = new System.Globalization.CultureInfo("fa");


            AddTranslation("fa", "NotNullValidator", "'#PropertyName ضروری است");
            
            AddTranslation("fa", "NotEmptyValidator", "'#PropertyName ضروری است");

            AddTranslation("fa", "NotEqualValidator", "'#PropertyName نباید برابر ' {PrpertyValue} ' باشد");

            AddTranslation("fa", "EqualValidator", "'#PropertyName باید برابر ' {PrpertyValue} ' باشد");

            AddTranslation("fa", "LengthValidator", "#PropertyName باید حداقل {MinLength} و حداکثر {MaxLength} حرف داشته باشد");
            
            AddTranslation("fa", "MinimumLengthValidator", "#PropertyName باید حداقل {MinLength} حرف داشته باشد");

            AddTranslation("fa", "MaximumLengthValidator", "#PropertyName باید حداکثر {MaxLength} حرف داشته باشد");

            AddTranslation("fa", "LessThanValidator", "#PropertyName باید کوچک تر از {ComparisonValue} باشد");

            AddTranslation("fa", "LessThanOrEqualValidator", "#PropertyName باید کوچک تر یا مساوی از {ComparisonValue} باشد");

            AddTranslation("fa", "GreaterThanValidator", "#PropertyName باید بزرگ تر از {ComparisonValue} باشد");

            AddTranslation("fa", "GreaterThanOrEqualValidator", "#PropertyName باید بزرگ تر یا مساوی از {ComparisonValue} باشد");

            AddTranslation("fa", "PredicateValidator", "#PropertyName قابل قبول نیست");

            AddTranslation("fa", "RegularExpressionValidator", "#PropertyName معتبر نیست");

            AddTranslation("fa", "InclusiveBetweenValidator", "#PropertyName باید بین {From} و {To} باشد");

            AddTranslation("fa", "ExclusiveBetweenValidator", "#PropertyName باید از {From} بزرگتر و از {To} کوچکتر باشد");

            AddTranslation("fa", "EnumValidator", "#PropertyName معتبر نیست");

            AddTranslation("fa", "EnumNameValidator", "#PropertyName معتبر نیست");

            AddTranslation("fa", "EmailValidator", "#PropertyName معتبر نیست");




        }
    }
}
