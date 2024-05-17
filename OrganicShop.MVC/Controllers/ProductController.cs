using Microsoft.AspNetCore.Mvc;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
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
            ViewData["Categories"] = (await _CategoryService.GetAll(new FilterCategoryDto { Type = CategoryType.Product})).Data.List;
            ViewData["FilterProductDto"] = filter;
            ViewData["PagingDto"] = paging;
            paging.LogAsync();
            filter.LogAsync();
            
            //return View("Index" , new PageDto<Product,ProductSummaryDto,long> ());
            
            return View("Index" , response.Data);
        }


        [HttpGet("/Category")]
        public async Task<IActionResult> Index1(FilterProductDto filter, PagingDto paging)
        {
            var allCategories = (await _CategoryService.GetAll(new FilterCategoryDto { Type = CategoryType.Product })).Data.List;

            paging.PageItemsCount = 24;
            var response = await _ProductService.GetAllSummary(filter, paging);
            ViewData["Categories"] = allCategories;
            ViewData["FilterProductDto"] = filter;
            ViewData["PagingDto"] = paging;
            ViewData["CategoryChilds"] = allCategories.Where(a => a.ParentId == null).ToList();

            return View("Index", response.Data);
        }



        [HttpGet("Category/{categoryTitle}")]
        public async Task<IActionResult> Index2(FilterProductDto filter, PagingDto paging, string categoryTitle)
        {
            categoryTitle = TextExtension.DecodePersianString(categoryTitle);
            var allCategories = (await _CategoryService.GetAll(new FilterCategoryDto { Type = CategoryType.Product })).Data.List;
            filter.CategoryId = allCategories.FirstOrDefault(c => c.Title == categoryTitle)?.Id;

            if (filter.CategoryId == null)
                return Redirect("/Error/404");

            paging.PageItemsCount = 24;
            var response = await _ProductService.GetAllSummary(filter, paging);
            ViewData["Categories"] = allCategories;
            ViewData["FilterProductDto"] = filter;
            ViewData["PagingDto"] = paging;
            ViewData["CategoryChilds"] = allCategories.Where(a => a.ParentId == filter.CategoryId).ToList();
            ViewBag.CategoryTitle = categoryTitle;

            return View("Index", response.Data);
        }


        [HttpGet("/Product/{barcode}")]
        public async Task<IActionResult> Product(string barcode)
        {
            var response = await _ProductService.GetDetail(barcode: barcode);
            
            if (response.Result == ResponseResult.Success)
                return View("Product", response.Data);

            return Redirect("/Error/404");
        }


    }
}
