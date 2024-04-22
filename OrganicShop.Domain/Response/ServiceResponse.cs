using OrganicShop.Domain.Enums.Response;
using System.Data.SqlTypes;
using System.Runtime.Serialization;

namespace OrganicShop.Domain.Response
{
    public class ServiceResponse<TData> where TData : class
    {
        public ResponseResult Result { get; set; }
        public string Message { get; set; } = string.Empty;
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
    }


    public class Empty
    {

    }

}
