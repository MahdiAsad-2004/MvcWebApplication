using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OrganicShop.BLL.Extensions;
using OrganicShop.BLL.Providers;
using OrganicShop.BLL.Utils;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.Domain.Dtos.WishItemDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;
using System.Text.Json;

namespace OrganicShop.Mvc.Controllers
{
    public class CartController : BaseController<ProductController>
    {
        #region ctor

        private readonly IProductService _ProductService;
        private readonly ICategoryService _CategoryService;
        private readonly IProductItemService _ProductItemService;
        private readonly AesKeys _AesKeys;
        public CartController(IProductService productService, ICategoryService categoryService,
            IProductItemService productItemService, IOptions<AesKeys> options)
        {
            _ProductService = productService;
            _CategoryService = categoryService;
            _ProductItemService = productItemService;
            _AesKeys = options.Value;
        }

        #endregion


       

        public async Task<IActionResult> AddProduct(CreateProductItemDto createProductItem)
        {
            if(createProductItem.ProductVarientId < 1)
                createProductItem.ProductVarientId = 0;
            
            var successToast = new Toast(ToastType.Success, "محصول با موفقیت به سبد خربد افزوده شد");
            if (User.Identity.IsAuthenticated)
            {
                List<CreateProductItemDto> previousCreates = new();

                #region Get Cookie ProductItems

                var CookieCartItemsStrCoded = Request.Cookies["OrganocShopUnknownUserCartItems"];
                if (string.IsNullOrEmpty(CookieCartItemsStrCoded) == false)
                {
                    var CookieCartItemsStr = AesOperation.Decrypt(CookieCartItemsStrCoded, _AesKeys.Cookie);
                    if (string.IsNullOrEmpty(CookieCartItemsStr) == false)
                    {
                        previousCreates = JsonSerializer.Deserialize<List<CreateProductItemDto>>(CookieCartItemsStr) ?? new List<CreateProductItemDto>();
                    }
                }

                #endregion

                var response = await _ProductItemService.CreateForCookie(createProductItem, previousCreates);

                var jsonData = JsonSerializer.Serialize(response.Data);
                Response.Cookies.Append("OrganocShopUnknownUserCartItems", AesOperation.Encrypt(jsonData, _AesKeys.Cookie));
                return _ClientHandleResult.Toast(HttpContext, successToast);
            }
            else
            {
                var response = await _ProductItemService.Create(createProductItem);
                if (response.Result == ResponseResult.Success)
                {
                    return _ClientHandleResult.Toast(HttpContext, successToast);
                }
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
            }
        }


      


    }
}
