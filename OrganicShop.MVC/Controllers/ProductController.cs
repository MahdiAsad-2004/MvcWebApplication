using Microsoft.AspNetCore.Mvc;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class ProductController : BaseController<ProductController>
    {
        #region ctor

        private readonly IProductService _ProductService;
        private readonly ICategoryService _CategoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _ProductService = productService;
            _CategoryService = categoryService;
        }

        #endregion


        [HttpGet("Products")]
        public async Task<IActionResult> Index(FilterProductDto filter , PagingDto paging)
        {
            paging.PageItemsCount = 24;
            var response = await _ProductService.GetAllSummary();
            ViewData["Categories"] = (await _CategoryService.GetAll()).Data.List;
            ViewData["FilterProductDto"] = filter;
            ViewData["PagingDto"] = paging;
            paging.LogAsync();
            filter.LogAsync();
            
            //return View("Index" , new PageDto<Product,ProductSummaryDto,long> ());
            
            return View("Index" , response.Data);
        }




    }
}
