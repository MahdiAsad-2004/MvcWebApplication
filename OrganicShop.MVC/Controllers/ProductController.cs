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
        public ProductController(IProductService productService, ICategoryService categoryService,
            IProductItemService productItemService, IOptions<AesKeys> options, ICommentService commentService)
        {
            _ProductService = productService;
            _CategoryService = categoryService;
            _ProductItemService = productItemService;
            _AesKeys = options.Value;
            _CommentService = commentService;
        }

        #endregion


        [HttpGet("Products")]
        public async Task<IActionResult> Index(FilterProductDto filter, PagingDto paging)
        {
            paging.PageItemsCount = 24;
            var response = await _ProductService.GetAllSummary();
            ViewData["Categories"] = (await _CategoryService.GetAll(new FilterCategoryDto { Type = CategoryType.Product })).Data.List;
            ViewData["FilterProductDto"] = filter;
            ViewData["PagingDto"] = paging;
            paging.LogAsync();
            filter.LogAsync();

            //return View("Index" , new PageDto<Product,ProductSummaryDto,long> ());

            return View("Index", response.Data);
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
            {
                ViewData["SimilarProducts"] = (await _ProductService.GetAllSummary(new FilterProductDto { CategoryId = response.Data.CategoryId })).Data!.List;
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
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, "محصول مورد نطر یافت نشد"));
        }



        [Authorize]
        public async Task<IActionResult> AddComment(CreateCommentUserDto createCommentUser)
        {
            var response = await _CommentService.Create(createForUser: createCommentUser);
            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "نطر شما با موفقیت ثبت شد"));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }








        //[Authorize]
        //public async Task<IActionResult> AddToWishList(CreateWishItemDto createWishItem)
        //{
        //    var response = 
        //}




    }
}
