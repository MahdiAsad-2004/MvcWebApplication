using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using System.Security.Cryptography.Xml;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Mvc.Models.Toast;
using OrganicShop.BLL.Services;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController<ProductController>
    {
        #region ctor

        private readonly IProductService _ProductService;
        private readonly ICategoryService _CategoryService;
        private readonly IPropertyService _PropertyService;
        private readonly ITagService _TagService;

        public ProductController(IProductService productService, ICategoryService categoryService, IPropertyService propertyService, ITagService tagService)
        {
            _ProductService = productService;
            _CategoryService = categoryService;
            _PropertyService = propertyService;
            _TagService = tagService;
        }

        #endregion


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _ProductService.GetAll();
            if(response.Result == ResponseResult.Success)
            {
                ViewData["CategoryCombos"] = (await _CategoryService.GetCombos()).Data;
                ViewData["TagCombos"] = (await _TagService.GetCombos()).Data;
                return View(response.Data);
            }
            return ResolveNoSuccessResult(response.Result,response.Message);
        }



        [HttpPost]
        public async Task<IActionResult> Table(FilterProductDto filter, PagingDto paging)
        {
            var response = await _ProductService.GetAll(filter, paging);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Table", response.Data));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }



        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            ViewData["CategoryCombos"] = (await _CategoryService.GetCombos()).Data;
            //ViewData["PropertyCombos"] = (await _PropertyService.GetCombos(new FilterPropertyDto() { IsBase = true })).Data;
            ViewData["TagCombos"] = (await _TagService.GetCombos()).Data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto create)
        {
            //return _ClientHandleResult.Json(HttpContext, create);
            //return Json(create);
            var response = await _ProductService.Create(create);

            if (response.Result == ResponseResult.Success)
            {
                ToastOnTempData(new Toast(ToastType.Success, response.Message));
                return Redirect(nameof(Index));
            }
            ToastOnTempData(new Toast(ToastType.Error, response.Message));
            return Refresh();
        }




        [HttpGet("Admin/Product/Edit/{Id}")]
        public async Task<IActionResult> Edit(long Id)
        {
            var response = await _ProductService.Get(Id);
            if (response.Result == ResponseResult.Success)
            {
                ViewData["CategoryCombos"] = (await _CategoryService.GetCombos()).Data;
                //ViewData["PropertyCombos"] = (await _PropertyService.GetCombos(new FilterPropertyDto() { IsBase = true })).Data;
                ViewData["TagCombos"] = (await _TagService.GetCombos()).Data;
                return View(response.Data);
            }
            return ResolveNoSuccessResult(response.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductDto update)
        {
            //return Json(update);

            var response = await _ProductService.Update(update);

            if (response.Result == ResponseResult.Success)
            {
                ToastOnTempData(new Toast(ToastType.Success, response.Message));
                return Redirect(nameof(Index));
            }
            //return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, nameof(Index), new Toast(ToastType.Success, response.Message), true);

            ToastOnTempData(new Toast(ToastType.Error, response.Message));
            return Refresh();
            //return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(long Id)
        {
            var response = await _ProductService.Delete(Id);
            if (response.Result == ResponseResult.Success)
            {
                var response1 = await _ProductService.GetAll();
                //ViewData["CategoryCombos"] = (await _CategoryService.GetCombos()).Data;
                return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("_Table", response1.Data), new Toast(ToastType.Success, response.Message));
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }





    }
}
