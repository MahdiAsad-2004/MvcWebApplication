using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using System.Security.Cryptography.Xml;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Mvc.Models.Toast;
using OrganicShop.Mvc.Extensions;
using System.Text.Json;
using System.Text.Encodings.Web;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Dtos.ProductDtos;
using MD.PersianDateTime;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class DiscountController : BaseAdminController<DiscountController>
    {
        #region ctor

        private readonly IDiscountService _DiscountService;
        private readonly IProductService _ProductService;
        private readonly IUserService _UserService;
        private readonly ICategoryService _CategoryService;

        public DiscountController(IDiscountService DiscountService, IProductService productService, IUserService userService, ICategoryService categoryService)
        {
            _DiscountService = DiscountService;
            _ProductService = productService;
            _UserService = userService;
            _CategoryService = categoryService;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index(FilterDiscountDto filter, PagingDto paging)
        {
            filter.ActiveFilter = IsActiveFilter.All;
            var response = await _DiscountService.GetAll(filter, paging);
            if(response.Result == ResponseResult.Success)
            {
                return View(response.Data);
            }
            return ResolveNoSuccessResult(response.Result);
        }



        public async Task<IActionResult> DiscountsTable(FilterDiscountDto filter, PagingDto paging)
        {
            var response = await _DiscountService.GetAll(filter, paging);

            if(response.Result == ResponseResult.Success)
                    return _ClientHandleResult.Partial(HttpContext, PartialView("_PropertiesTable", response.Data));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }


        public async Task<IActionResult> ProductsPartial(FilterProductDto filter, PagingDto paging)
        {
            var response = await _ProductService.GetAll(filter, paging);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("ProductsPartial", response.Data));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }
        


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryCombos"] = (await _CategoryService.GetCombos()).Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountDto create)
        {
            //return _ClientHandleResult.Json(HttpContext,create);
            var response = await _DiscountService.Create(create);
            if (response.Result == ResponseResult.Success)
            {
                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, nameof(Index), new Toast(ToastType.Success, response.Message), false);
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }



        [HttpGet("/Admin/Discount/Edit/{id}")]
        public async Task<IActionResult> Edit(int Id)
        {
            var response = await _DiscountService.Get(Id);

            if(response.Result == ResponseResult.Success)
            {
                ViewData["CategoryCombos"] = (await _CategoryService.GetCombos()).Data;
                ViewData["SelectedProductCombos"] = (await _ProductService.GetCombos(response.Data.ProductIds)).Data;
                return View(response.Data);
            }
            return ResolveNoSuccessResult(response.Result);
        }


        [HttpPut]
        public async Task<IActionResult> Edit(UpdateDiscountDto update)
        {
            return Json(update);

            var response = await _DiscountService.Update(update);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, nameof(Index), new Toast(ToastType.Success, response.Message), true);

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }





        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _DiscountService.Delete(Id);
            if(response.Result == ResponseResult.Success)
            {
                var model = (await _DiscountService.GetAll(new FilterDiscountDto())).Data;
                return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("_Table", model), new Toast(ToastType.Success, response.Message));
                //return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, "Index", new Toast(ToastType.Success, response.Message), true);
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }
    }
}
