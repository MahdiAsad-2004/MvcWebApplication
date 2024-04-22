using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController<CategoryController>
    {
        #region ctor

        private readonly ICategoryService _CategoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        #endregion


        public async Task<IActionResult> Index(FilterCategoryDto filter, PagingDto paging)
        {
            var response = await _CategoryService.GetAll(filter,paging);
            if(response.Data != null)
            {
                return View(response.Data);
            }
            await Console.Out.WriteLineAsync(response.Result.ToString());
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Table(FilterCategoryDto filter, PagingDto paging)
        {
            var response = await _CategoryService.GetAll(filter,paging);
            
            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Table", response.Data));

            return _ClientHandleResult.Toast(HttpContext,new Toast(ToastType.Error,response.Message));
        }





        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = (await _CategoryService.GetCombos()).Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto? create)
        {
            if(create != null)
            {
                var response = await _CategoryService.Create(create);

                if (response.Result == ResponseResult.Success)
                {
                    ToastOnTempData(new Toast(ToastType.Success, response.Message));
                    return Refresh();
                }

                ToastOnTempData(new Toast(ToastType.Error, response.Message));
                return Refresh();
            }
            else
            {
                ViewData["Categories"] = (await _CategoryService.GetCombos()).Data;
            }
            return View();
        }



        [HttpGet("Admin/Category/Edit/{Id}")]
        public async Task<IActionResult> Edit(int Id = 0)
        {
            var response = await _CategoryService.Get(Id);
            var model = response.Data;
            await Console.Out.WriteLineAsync(Id.ToString());
            await Console.Out.WriteLineAsync(response.Result.ToString());
            if (model != null)
            {
                ViewData["Categories"] = (await _CategoryService.GetCombos()).Data;
                return View(model);
            }

            if (response.Result == ResponseResult.NotFound) return NotFound();
            
            if(response.Result == ResponseResult.NoAccess) return Forbid();

            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(UpdateCategoryDto update)
        {
            var response = await _CategoryService.Update(update);
            if (response.Result == ResponseResult.Success)
            {
                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, "Index", new Toast(ToastType.Success, response.Message), true);
            }
            return _ClientHandleResult.Toast(HttpContext,new Toast(ToastType.Error,response.Message));
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _CategoryService.Delete(Id);
            if (response.Result == ResponseResult.Success)
            {
                var model = (await _CategoryService.GetAll()).Data;
                return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("_Table", model), new Toast(ToastType.Success, response.Message));
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }






    }
}
