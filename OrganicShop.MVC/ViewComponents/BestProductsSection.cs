using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Enums.SortTypes;
using OrganicShop.Domain.IServices;


namespace OrganicShop.Mvc.ViewComponents
{

    public class BestProductsSection : ViewComponent
    {
        #region ctor
        
        private readonly IProductService _ProductService;
        public BestProductsSection(IProductService productService)
        {
            _ProductService = productService;
        }

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var paging = new PagingDto { PageItemsCount = 16 };
            var response = await _ProductService.GetAllSummary(new FilterProductDto { SortBy = ProductSortType.RateDesc }, new PagingDto { PageItemsCount = 16 });
            return View("BestProductsSection" , response.Data.List);
        }
    }


   
}
