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
    public class ServiceResponse<TData>
    {
        public ResponseResult Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();
        public TData? Data { get; set; }


        public ServiceResponse(ResponseResult result, TData? data = default(TData))
        {
            Result = result;
            Data = result != ResponseResult.Success ? default(TData) : data;
        }

        public ServiceResponse(ResponseResult result, string message, TData? data = default(TData))
        {
            Result = result;
            Message = message;
            Data = data;
        }

        public ServiceResponse(string propertyName, string errorMessage, string? message = null)
        {
            Result = ResponseResult.ValidationError;
            Message = message ?? "داده های ارسال شده معتبر نیستند";
            ValidationErrors.Add(new ValidationError(propertyName, errorMessage));
        }

        public ServiceResponse(object dto, FluentValidation.Results.ValidationResult validationResult, string? message = null)
        {
            Result = ResponseResult.ValidationError;
            Message = message ?? "داده های ارسال شده معتبر نیستند";

            ValidationErrors = validationResult.Errors
                .Select(a => new ValidationError()
                {
                    ErrorMessage = a.ErrorMessage.Replace("#PropertyName", DisplayNameExtension.GetPropName(dto, a.PropertyName)),
                    PropertyName = a.PropertyName,
                })
                .ToList();
        }
        public ServiceResponse(string propertyName, FluentValidation.Results.ValidationResult validationResult, string? message = null)
        {
            Result = ResponseResult.ValidationError;
            Message = message ?? "داده های ارسال شده معتبر نیستند";

            ValidationErrors = validationResult.Errors
                .Select(a => new ValidationError()
                {
                    ErrorMessage = a.ErrorMessage,
                    PropertyName = propertyName,
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

            if (displayName != null)
                return displayName;

            return Property.Name;
        }
    }

    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }


        public ValidationError()
        {
                
        }
        public ValidationError(string propertyName , string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

    }

}
