using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OrganicShop.BLL.Extensions;
using OrganicShop.BLL.Providers;
using OrganicShop.BLL.Utils;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.CommentDtos;
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
    public class ProductController : BaseController<ProductController>
    {
        #region ctor

        private readonly IProductService _ProductService;
        private readonly ICategoryService _CategoryService;
        private readonly IProductItemService _ProductItemService;
        private readonly ICommentService _CommentService;
        private readonly AesKeys _AesKeys;
        private readonly IWishItemService _WishItemService;
        public ProductController(IProductService productService, ICategoryService categoryService,
            IProductItemService productItemService, IOptions<AesKeys> options, ICommentService commentService, IWishItemService wishItemService)
        {
            _ProductService = productService;
            _CategoryService = categoryService;
            _ProductItemService = productItemService;
            _AesKeys = options.Value;
            _CommentService = commentService;
            _WishItemService = wishItemService;
        }

        #endregion



        [HttpGet("/Products")]
        public async Task<IActionResult> Index(FilterProductDto filter, PagingDto paging)
        {
            paging.PageItemsCount = 24;
            var response = await _ProductService.GetAllSummary(filter, paging);
            ViewData["Categories"] = (await _CategoryService.GetAllSummary(new FilterCategoryDto { Type = CategoryType.Product })).Data.List;
            ViewData["FilterProductDto"] = filter;
            ViewData["PagingDto"] = paging;
            //ViewData["UserWishProductIds"] = await _WishItemService.GetUserWishProductIds();
            ViewData["UserWishProductIds"] = new long[11] { 1, 3, 6, 9, 12, 15, 18, 21, 24, 28, 30 };
            paging.LogAsync();
            filter.LogAsync();

            //return View("Index" , new PageDto<Product,ProductSummaryDto,long> ());

            return View("Index", response.Data);
        }


        [HttpGet("/Products/Category")]
        public async Task<IActionResult> Index1(FilterProductDto filter, PagingDto paging)
        {
            var allCategories = (await _CategoryService.GetAllSummary(new FilterCategoryDto { Type = CategoryType.Product })).Data.List;

            paging.PageItemsCount = 24;
            var response = await _ProductService.GetAllSummary(filter, paging);
            ViewData["Categories"] = allCategories;
            ViewData["FilterProductDto"] = filter;
            ViewData["PagingDto"] = paging;
            ViewData["CategoryChilds"] = allCategories.Where(a => a.ParentId == null).ToList();
            ViewData["UserWishProductIds"] = await _WishItemService.GetUserWishProductIds();

            return View("Index", response.Data);
        }



        [HttpGet("/Products/Category/{categoryTitle}")]
        public async Task<IActionResult> Index2(FilterProductDto filter, PagingDto paging, string categoryTitle)
        {
            categoryTitle = TextExtensions.DecodePersianString(categoryTitle);
            var allCategories = (await _CategoryService.GetAllSummary(new FilterCategoryDto { Type = CategoryType.Product })).Data.List;
            filter.CategoryId = allCategories.FirstOrDefault(c => c.Title == categoryTitle)?.Id;

            if (filter.CategoryId == null)
                return Redirect("/Error/404");

            paging.PageItemsCount = 24;
            var response = await _ProductService.GetAllSummary(filter, paging);
            ViewData["Categories"] = allCategories;
            ViewData["FilterProductDto"] = filter;
            ViewData["PagingDto"] = paging;
            ViewData["CategoryChilds"] = allCategories.Where(a => a.ParentId == filter.CategoryId).ToList();
            ViewData["UserWishProductIds"] = await _WishItemService.GetUserWishProductIds();
            ViewBag.CategoryTitle = categoryTitle;

            return View("Index", response.Data);
        }


        [HttpGet("/Product/{barcode}")]
        public async Task<IActionResult> Product(string barcode)
        {
            var response = await _ProductService.GetDetail(barcode: barcode);

            if (response.Result == ResponseResult.Success)
            {
                #region add product to view history

                var productViewHistoryDtoList = AppCookies.ProductViewHistory.GetModel(AesOperation.Decrypt(HttpContext.Request.Cookies[AppCookies.ProductViewHistory.Key], _AesKeys.Cookie));
                if (productViewHistoryDtoList != null)
                {
                    if (productViewHistoryDtoList.Any(a => a.ProductId == response.Data.Id))
                    {
                        productViewHistoryDtoList.First(a => a.ProductId == response.Data.Id).ViewDate = DateTime.UtcNow;
                    }
                    else
                    {
                        productViewHistoryDtoList.Add(new ProductHistoryViewDto { ProductId = response.Data.Id, ViewDate = DateTime.UtcNow });
                    }
                }
                else
                {
                    productViewHistoryDtoList = new List<ProductHistoryViewDto> { new ProductHistoryViewDto { ProductId = response.Data.Id, ViewDate = DateTime.UtcNow } };
                }
                HttpContext.Response.Cookies.Append(
                    AppCookies.ProductViewHistory.Key,
                    AesOperation.Encrypt(AppCookies.ProductViewHistory.GenerateJsonValue(productViewHistoryDtoList), _AesKeys.Cookie),
                    AppCookies.ProductViewHistory.Options);

                #endregion

                ViewData["SimilarProducts"] = (await _ProductService.GetAllSummary(new FilterProductDto { CategoryId = response.Data.CategoryId })).Data!.List ?? new List<ProductSummaryDto>(); ;
                //ViewData["UserWishProductIds"] = await _WishItemService.GetUserWishProductIds();
                ViewData["UserWishProductIds"] = new long[11] { 1, 3, 6, 9, 12, 15, 18, 21, 24, 28, 30 };
                return View("Product", response.Data);
            }

            return Redirect("/Error/404");
        }



        public async Task<IActionResult> Preview(long id)
        {
            if (id < 1)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, "محصول مورد نطر یافت نشد"));

            var reponse = await _ProductService.GetAllSummary(new FilterProductDto { Id = id });
            ProductSummaryDto model;
            if (reponse.Result == ResponseResult.Success)
            {
                model = reponse.Data.List[0];
                if (model != null)
                {
                    return _ClientHandleResult.Partial(HttpContext, PartialView("_PreviewProductModal", model));
                }
            }
            return StatusCode(404);
            //return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, "محصول مورد نطر یافت نشد"));
        }




        [HttpGet("/products/search/{searchText}")]
        public async Task<IActionResult> Search(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return Redirect("/Error/404");

            var model = (await _ProductService.GetAllSummary
                (new FilterProductDto { Title = searchText }, new PagingDto { PageItemsCount = 20 })).Data?.List ?? new List<ProductSummaryDto>();

            ViewData["UserWishProductIds"] = await _WishItemService.GetUserWishProductIds();
            ViewBag.SearchText = searchText;

            return View("Search", model);
        }




        [HttpPost("/products/search/{searchText}")]
        public async Task<IActionResult> Search_Post(string searchText)
        {
            return _ClientHandleResult.Redirect(HttpContext, $"search/{searchText}", "products", true);
        }




    }
}
