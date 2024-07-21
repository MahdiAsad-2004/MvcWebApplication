
using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Models;

namespace OrganicShop.BLL.Utils
{
    public class AppCookies
    {
        public static readonly CookieItem<List<ProductItemCookieDto>> UnknownUserCartItems = 
            new () { Key = "OrganicShopUnknownUserCartItems"};
     
        public static readonly CookieItem<long[]> ProductViewHistory = 
            new () { Key = "OrganicShopUserProductViewHistory"};

        public static readonly CookieItem<(string Name , string Email)?> NameAndEmailForComment = 
            new () { Key = "OrganicShopUserNameAndEmailForComment" , Options = new CookieOptions {Expires = DateTime.UtcNow.AddMonths(2)}};

      

    }
}
