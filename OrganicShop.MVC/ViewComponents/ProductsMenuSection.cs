using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Enums.SortTypes;
using OrganicShop.Domain.IServices;


namespace OrganicShop.Mvc.ViewComponents
{

    public class ProductsMenuSection : ViewComponent
    {
        #region ctor
        
        private readonly IProductService _ProductService;
        public ProductsMenuSection(IProductService productService)
        {
            _ProductService = productService;
        }

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var paging = new PagingDto { PageItemsCount = 11 };
            ViewData["NewestProducts"] = (await _ProductService.GetAllSummary(new FilterProductDto { SortBy = ProductSortType.Newest }, paging))?.Data!.List;
            ViewData["SpecialProducts"] = (await _ProductService.GetAllSummary(new FilterProductDto { SortBy = ProductSortType.DiscountDesc }, paging))?.Data!.List;
            ViewData["BestSellingProducts"] = (await _ProductService.GetAllSummary(new FilterProductDto { SortBy = ProductSortType.SoldCountDesc },paging))?.Data!.List;
            ViewData["LowestSellingProducts"] = (await _ProductService.GetAllSummary(new FilterProductDto { SortBy = ProductSortType.SoldCount },paging))?.Data!.List;
            return View("ProductsMenuSection");
        }
    }


   
}
