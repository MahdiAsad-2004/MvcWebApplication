using FluentValidation;
using System.ComponentModel;
using System.Reflection;

namespace OrganicShop.Domain.Validation.Validators.Base
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        public BaseValidator()
        {

            ValidatorOptions.Global.LanguageManager = new CustomLanguageManager();

            ValidatorOptions.Global.DisplayNameResolver = (type, member, expression) =>
            {
                string? dispalyName = member?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                if (dispalyName != null)
                {
                    return dispalyName;
                }
                if(member != null)
                {
                    return member.Name;
                }
                return null;
            };



            //ValidatorOptions.Global.DisplayNameResolver = (type, member, expression) =>
            //{
            //    string? dispalyName = member?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
            //    if (dispalyName != null)
            //        return dispalyName;

            //    if(member != null)
            //        return member.Name;

            //    return null;
            //};

        }

    }
}
