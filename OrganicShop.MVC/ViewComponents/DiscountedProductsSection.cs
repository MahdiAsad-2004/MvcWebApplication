using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.NotificationDtos;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;


namespace OrganicShop.Mvc.ViewComponents
{
    public class DiscountedProductsSection : ViewComponent
    {
        #region ctor

        private readonly IProductService _ProductService;
        public DiscountedProductsSection(IProductService productService)
        {
            _ProductService = productService;
        }

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _ProductService.HotDiscountProducts();
            if (response.Result == ResponseResult.Success)
            {
                return View("DiscountedProductsSection", response.Data);
            }
            return View("DiscountedProductsSection", new List<ProductSummaryDto>());
        }


    }



}
