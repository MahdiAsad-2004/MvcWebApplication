using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PropertyDtos;
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

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class PropertyController : BaseAdminController<PropertyController>
    {
        #region ctor

        private readonly IPropertyService _PropertyService;

        public PropertyController(IPropertyService PropertyService)
        {
            _PropertyService = PropertyService;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index(FilterPropertyDto filter, PagingDto paging)
        {
            filter.IsBase = true;
            var response = await _PropertyService.GetAll(filter, paging);
            if (response.Result == ResponseResult.Success)
            {
                return View(response.Data);
            }
            return ResolveNoSuccessResult(ResponseResult.Success);
        }



        public async Task<IActionResult> Table(FilterPropertyDto filter, PagingDto paging)
        {
            filter.IsBase = true;
            var response = await _PropertyService.GetAll(filter, paging);

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
        public async Task<IActionResult> Create(CreatePropertyDto? createProperty)
        {
            var response = await _PropertyService.Create(createProperty);
            if (response.Result == ResponseResult.Success)
            {
                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, nameof(Create), new Toast(ToastType.Success, response.Message), true);
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));

            //if (!ModelState.IsValid)
            //{
            //    foreach (var item in ModelState)
            //    {
            //        await Console.Out.WriteLineAsync($"{item.Key} ----- {item.Value.Errors.First().ErrorMessage}");
            //    }
            //    return _ClientHandleResult.Partial(HttpContext, PartialView(createProperty), new Toast(ToastType.Error, "EEEEEE"));
            //}

        }



        [HttpGet("/Admin/Property/Edit/{id}")]
        public async Task<IActionResult> Edit(int Id)
        {
            var response = await _PropertyService.Get(Id);

            if (response.Result == ResponseResult.Success)
                return View(response.Data);

            return ResolveNoSuccessResult(response.Result, response.Message);
        }


        [HttpPut]
        public async Task<IActionResult> Edit(UpdatePropertyDto update)
        {
            var response = await _PropertyService.Update(update);

            if (response.Result == ResponseResult.Success) 
            {
                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, nameof(Index),new Toast(ToastType.Success, response.Message), true);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }







        //[HttpPost]
        //public async Task<IActionResult> Delete(int Id)
        //{
        //    var response = await _PropertyService.Delete(Id);
        //    switch (response.Result)
        //    {
        //        case EntityResult.Success:
        //            return Partial("Index" , new Toast(ToastType.Success , response.Message , 5000));

        //        case EntityResult.NotFound:
        //            return Toast(new Toast(ToastType.Error, response.Message));

        //        default:
        //            throw new Exception("Unhandled Entity Result .");
        //    }
        //}

        [HttpDelete]
        //[HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _PropertyService.Delete(Id);
            if (response.Result == ResponseResult.Success)
            {
                var model = (await _PropertyService.GetAll(new FilterPropertyDto() { IsBase = true })).Data;
                return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("_Table", model), new Toast(ToastType.Success, response.Message));
                //return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, "Index", new Toast(ToastType.Success, response.Message), true);
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }
    }
}
