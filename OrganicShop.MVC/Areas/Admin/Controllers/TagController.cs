using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TagDtos;
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
using Azure;
using OrganicShop.Domain.Dtos.NotificationDtos;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class TagController : BaseAdminController<TagController>
    {
        #region ctor

        private readonly ITagService _TagService;

        public TagController(ITagService TagService)
        {
            _TagService = TagService;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index(FilterNewsLetterDto filter, PagingDto paging)
        {
            var response = await _TagService.GetAll(filter, paging);
            if (response.Result == ResponseResult.Success)
            {
                return View(response.Data);
            }
            return ResolveNoSuccessResult(ResponseResult.Success);
        }



        public async Task<IActionResult> Table(FilterNewsLetterDto filter, PagingDto paging)
        {
            var response = await _TagService.GetAll(filter, paging);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Table", response.Data));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }




        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsLetterDto? create)
        {
            var response = await _TagService.Create(create);
            if (response.Result == ResponseResult.Success)
            {
                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, nameof(Index), new Toast(ToastType.Success, response.Message), true);
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }



        [HttpGet("/Admin/Tag/Edit/{id}")]
        public async Task<IActionResult> Edit(int Id)
        {
            var response = await _TagService.Get(Id);

            if (response.Result == ResponseResult.Success)
                return View(response.Data);

            return ResolveNoSuccessResult(response.Result, response.Message);
        }


        [HttpPut]
        public async Task<IActionResult> Edit(UpdateTagDto update)
        {
            var response = await _TagService.Update(update);

            if (response.Result == ResponseResult.Success) 
            {
                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, nameof(Index),new Toast(ToastType.Success, response.Message), true);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }





        
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _TagService.Delete(Id);
            if (response.Result == ResponseResult.Success)
            {
                var model = (await _TagService.GetAll(new FilterNewsLetterDto())).Data;
                return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("_Table", model), new Toast(ToastType.Success, response.Message));
                //return _ClientHandleResult.PartialThenToast(HttpContext, PartialView(model), new Toast(ToastType.Success, response.Message));
                //return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, "Index", new Toast(ToastType.Success, response.Message), true);
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }

    }
}
