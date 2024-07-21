using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace OrganicShop.Domain.Models
{
    public class CookieItem<TModel>
    {
        public string Key { get; init; }
        public CookieOptions Options { get; init; } = new CookieOptions() { Expires = DateTime.UtcNow.AddDays(15) };
        public Type ValueType { get; private set; } = typeof(TModel);
        //public TModel? DefaultModel { get; init; }



        public string GenerateJsonValue(TModel model)
        {
            return JsonSerializer.Serialize<TModel>(model);
        }

        public TModel? GetModel(string? JsonValue)
        {
            if (string.IsNullOrWhiteSpace(JsonValue))
                return default(TModel);
            try
            {
                return JsonSerializer.Deserialize<TModel>(JsonValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured at CookieItem.GetModel() while desrialize json value to model");
                Console.WriteLine(ex.Message);
                return default(TModel);
            }
        }



    }
}
