using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OrganicShop.BLL.Providers;
using OrganicShop.BLL.Utily;
using OrganicShop.Domain.Dtos.NotificationDtos;
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
        public CategorizedProducts(IProductService productService,IOptions<AesKeys> aesKeys)
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
            string? productsHistoryStr = Request.Cookies["ProductsViewHistory"];
            List<ProductSummaryDto> productsHistory = new();
            if(productsHistoryStr != null)
            {
                try
                {
                    productsHistory = JsonSerializer.Deserialize<List<ProductSummaryDto>>(AesOperation.Decrypt(productsHistoryStr, _AesKeys.Cookie)) ?? new();
                }
                catch (Exception ex)
                {
                    productsHistory = new();
                    Console.WriteLine("Error: an error in 'ProductsMenuSection' component");
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
            ViewData["ProductsHistory"] = productsHistory;
            var response = await _ProductService.GetAllSummary(new FilterProductDto {CategoryIds = categoryIds });
            if (response.Result == ResponseResult.Success)
            {
                return View("DiscountedProductsSection", response.Data);
            }
            return View("DiscountedProductsSection", new List<ProductSummaryDto>());
        }


    }



}
