
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OrganicShop.BLL.Extensions
{
    public static class BasicExtensions
    {
        public static string? GetPropertyDisplayName(this object obj , string propertyName)
        {
            var type = obj.GetType();
            var Property = type.GetProperty(propertyName);
            
            string? displayName = Property?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
            
            if (displayName == null)
                displayName = Property?.GetCustomAttribute<DisplayAttribute>()?.Name;

            return displayName;
        }
    }
}
