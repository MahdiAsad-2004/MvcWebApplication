using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.BLL.Extensions;
using OrganicShop.BLL.Providers;
using OrganicShop.BLL.Services;
using OrganicShop.BLL.Utils;
using OrganicShop.Domain.Dtos.ArticleDtos;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Enums.SortTypes;
using OrganicShop.Domain.IServices;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class BlogController : BaseController<ProductController>
    {
        #region ctor

        private readonly IArticleService _ArticleService;
        private readonly ICategoryService _CategoryService;
        private readonly ITagService _TagService;
        private readonly IProductService _ProductService;
        public BlogController(IArticleService ArticleService, ICategoryService categoryService, ITagService tagService, IProductService productService)
        {
            _ArticleService = ArticleService;
            _CategoryService = categoryService;
            _TagService = tagService;
            _ProductService = productService;
        }

        #endregion


        [HttpGet("Blogs")]
        public async Task<IActionResult> Index(FilterArticleDto filter)
        {
            ViewData["Categories"] = (await _CategoryService.GetAllSummary(new FilterCategoryDto { Type = CategoryType.Article })).Data!.List;
            ViewData["TagCombos"] = (await _TagService.GetCombos()).Data;
            ViewData["MostSellProducts"] = (await _ProductService
                .GetAll(new FilterProductDto { SortBy = ProductSortType.SoldCountDesc }, new PagingDto { PageItemsCount = 3 })).Data!.List;
            ViewData["LastBlogs"] = (await _ArticleService.GetAll(new FilterArticleDto { SortBy = BaseSortType.Newest }, new PagingDto { PageItemsCount = 4 })).Data.List;
            ViewData["FilterArticleDto"] = filter;

            var response = await _ArticleService.GetAll(filter);
            return View("blogs" , response.Data);
        }



        [HttpGet("Blogs/Category/{categoryTitle}")]
        public async Task<IActionResult> Index1(FilterArticleDto filter,[FromRoute]string categoryTitle)
        {
            categoryTitle = TextExtensions.DecodePersianString(categoryTitle);
            var allCategories = (await _CategoryService.GetAllSummary(new FilterCategoryDto { Type = CategoryType.Article })).Data!.List;
            int? categoryId = allCategories.FirstOrDefault(a => a.Title == categoryTitle)?.Id;
            
            if(categoryId == null)
                return Redirect("/Error/404");
            
            ViewData["Categories"] = allCategories;
            ViewData["TagCombos"] = (await _TagService.GetCombos()).Data;
            ViewData["MostSellProducts"] = (await _ProductService
                .GetAll(new FilterProductDto { SortBy = ProductSortType.SoldCountDesc }, new PagingDto { PageItemsCount = 3 })).Data!.List;
            ViewData["LastBlogs"] = (await _ArticleService.GetAll(new FilterArticleDto { SortBy = BaseSortType.Newest }, new PagingDto { PageItemsCount = 4 })).Data.List;
            ViewBag.CategoruTitle = categoryTitle;
            ViewData["FilterArticleDto"] = filter;
            filter.CategoryId = categoryId;

            var response = await _ArticleService.GetAll(filter);
            return View("blogs", response.Data);
        }


        [HttpGet("/Blog/{title}")]
        public async Task<IActionResult> Blog(string title)
        {
            title = TextExtensions.DecodePersianString(title);
            var response = await _ArticleService.GetDetail(title:title);
            if(response.Result == ResponseResult.Success)
            {
                ViewData["Categories"] = (await _CategoryService.GetAllSummary(new FilterCategoryDto { Type = CategoryType.Article})).Data!.List;
                ViewData["TagCombos"] = (await _TagService.GetCombos()).Data;
                ViewData["MostSellProducts"] = (await _ProductService
                    .GetAll(new FilterProductDto { SortBy = ProductSortType.SoldCountDesc }, new PagingDto { PageItemsCount = 3 })).Data!.List;
                ViewData["LastBlogs"] = (await _ArticleService.GetAll(new FilterArticleDto { SortBy = BaseSortType.Newest }, new PagingDto { PageItemsCount = 4 })).Data.List;
                return View("blog", response.Data);
            }
            return Redirect("/Error/404");
        }


        [HttpGet("/Blog1")]
        public async Task<IActionResult> Blog()
        {
            return View("blog1");
        }






    }
}
