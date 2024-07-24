
using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Models;

namespace OrganicShop.BLL.Utils
{
    public class AppCookies
    {
        public static readonly CookieItem<List<ProductItemCookieDto>> UnknownUserCartItems = 
            new () { Key = "OrganicShopUnknownUserCartItems"};
     
        public static readonly CookieItem<List<ProductHistoryViewDto>> ProductViewHistory = 
            new () { Key = "OrganicShopUserProductViewHistory"};

        public static readonly CookieItem<CredentialForCommentDto> NameAndEmailForComment = 
            new () { Key = "OrganicShopUserNameAndEmailForComment" , Options = new CookieOptions {Expires = DateTime.UtcNow.AddMonths(2)}};

      

    }
}
