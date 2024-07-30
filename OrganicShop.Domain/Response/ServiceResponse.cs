using FluentValidation.Results;
using OrganicShop.Domain.Enums.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Runtime.Serialization;
using System.Reflection;
using OrganicShop.Domain.Response.Messages;

namespace OrganicShop.Domain.Response
{
    public class ServiceResponse<TData> where TData : class
    {
        public ResponseResult Result { get; set; }
        public string Message { get; set; } = string.Empty;

        public Dictionary<string,string> ValidationErrors = new Dictionary<string,string>();

        public List<ValidationFailure> ValidationFailures = new();
        public TData? Data { get; set; } 
       

        public ServiceResponse(ResponseResult result,TData? data = null )
        {
            Result = result;
            Data = result != ResponseResult.Success ? null : data;
        }

        public ServiceResponse(ResponseResult result, string message, TData? data = null)
        {
            Result = result;
            Message = message;
            Data = result != ResponseResult.Success ? null : data;
        }

        public ServiceResponse(string propertyName, string errorMessage , string message)
        {
            Result = ResponseResult.ValidationError;
            Message = message ?? "داده های ارسال شده معتبر نیستند";
            ValidationErrors.Add(propertyName, errorMessage);
        }

        public ServiceResponse(object dto, FluentValidation.Results.ValidationResult validationResult, string? message = null)
        {
            Result = ResponseResult.ValidationError;
            Message = message ?? "داده های ارسال شده معتبر نیستند";

            //ValidationErrors = validationResult.Errors
            //    .ToDictionary(
            //        a => a.PropertyName, 
            //        a => a.ErrorMessage.Replace("#PropertyName" , DisplayNameExtension.GetPropName(dto , a.PropertyName)));

            ValidationFailures = validationResult.Errors
                .Select(a => new ValidationFailure()
                {
                    AttemptedValue = a.AttemptedValue,
                    CustomState = a.CustomState,
                    ErrorCode = a.ErrorCode,
                    ErrorMessage = a.ErrorMessage.Replace("#PropertyName", DisplayNameExtension.GetPropName(dto, a.PropertyName)),
                    FormattedMessagePlaceholderValues = a.FormattedMessagePlaceholderValues,
                    PropertyName = a.PropertyName,
                    Severity = a.Severity
                })
                .ToList();

            
        }

    }


    public class Empty
    {

    }

    public static class DisplayNameExtension
    {
        public static string GetPropName(object obj, string propertyName)
        {
            var type = obj.GetType();
            var Property = type.GetProperty(propertyName);
            
            if (Property == null)
                return propertyName;

            string? displayName = Property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;

            if (displayName == null)
                displayName = Property.GetCustomAttribute<DisplayAttribute>()?.Name;

            if(displayName != null)
                return displayName;

            return Property.Name;
        }
    }

}
