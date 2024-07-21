using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OrganicShop.BLL.Providers;
using OrganicShop.BLL.Utils;
using OrganicShop.Domain.Dtos.NotificationDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using System.Text.Json;


namespace OrganicShop.Mvc.ViewComponents
{
    public class CategorizedProducts : ViewComponent
    {
        #region ctor

        private readonly IProductService _ProductService;
        private readonly AesKeys _AesKeys;
        public CategorizedProducts(IProductService productService, IOptions<AesKeys> aesKeys)
        {
            _ProductService = productService;
            _AesKeys = aesKeys.Value;
        }

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            int[]? categoryIds = null;
            if (ViewComponentContext.Arguments.ContainsKey("categoryIds"))
                categoryIds = ViewComponentContext.Arguments.First().Value as int[];
            string? productsHistoryCryptedStr = Request.Cookies[AppCookies.ProductViewHistory.Key];
            List<ProductSummaryDto>? productsHistory = new();
            long[] productsHistoryIds;
            List<ProductSummaryDto> categoryproducts = new();
            if (productsHistoryCryptedStr != null)
            {
                productsHistoryIds = AppCookies.ProductViewHistory.GetModel(AesOperation.Decrypt(productsHistoryCryptedStr, _AesKeys.Cookie)) ?? new long[0];
                productsHistory = (await _ProductService.GetAllSummary(new FilterProductDto { Ids = productsHistoryIds }, new PagingDto { PageItemsCount = -1 })).Data?.List;
            }
            ViewData["ProductsHistory"] = productsHistory;
            var products = new List<ProductSummaryDto>();
            if (categoryIds != null)
            {
                foreach (var item in categoryIds)
                {
                    products = (await _ProductService.GetAllSummary(new FilterProductDto { CategoryId = item })).Data?.List;
                    if (products != null)
                    {
                        categoryproducts.AddRange(products);
                    }
                }
            }
            //var response = await _ProductService.GetAllSummary(new FilterProductDto { CategoryIds = categoryIds });
            //if (response.Result == ResponseResult.Success)
            //{
            //    return View("CategorizedProducts", response.Data);
            //}
            return View("CategorizedProducts", categoryproducts);
        }


    }



}
