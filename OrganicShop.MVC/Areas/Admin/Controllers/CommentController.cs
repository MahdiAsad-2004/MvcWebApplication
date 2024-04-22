using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.CommentDtos;
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

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class CommentController : BaseAdminController<CommentController>
    {
        #region ctor

        private readonly ICommentService _CommentService;

        public CommentController(ICommentService CommentService)
        {
            _CommentService = CommentService;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index(FilterCommentDto filter, PagingDto paging)
        {
            var response = await _CommentService.GetAll(filter, paging);
            if (response.Result == ResponseResult.Success)
            {
                return View(response.Data);
            }
            return ResolveNoSuccessResult(ResponseResult.Success);
        }



        public async Task<IActionResult> Table(FilterCommentDto filter, PagingDto paging)
        {
            var response = await _CommentService.GetAll(filter, paging);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Table", response.Data));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }


        [HttpGet("/Admin/Comment/Edit/{id}")]
        public async Task<IActionResult> Edit(long Id)
        {
            var response = await _CommentService.Get(Id);
            if(response.Result == ResponseResult.Success)
            {
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Edit", response.Data));
            }
            return _ClientHandleResult.Partial(HttpContext, PartialView("_Error404"));
        }


        [HttpPut]
        public async Task<IActionResult> Edit(UpdateCommentDto update)
        {
            return Json(update);
            var response = await _CommentService.Update(update);

            if (response.Result == ResponseResult.Success) 
            {
                var model = (await _CommentService.GetAll()).Data;
                return _ClientHandleResult.PartialThenToast(HttpContext,PartialView("_Table",model) ,new Toast(ToastType.Success, response.Message));
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }





        
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _CommentService.Delete(Id);
            if (response.Result == ResponseResult.Success)
            {
                var model = (await _CommentService.GetAll()).Data;
                return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("_Table", model), new Toast(ToastType.Success, response.Message));
                //return _ClientHandleResult.PartialThenToast(HttpContext, PartialView(model), new Toast(ToastType.Success, response.Message));
                //return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, "Index", new Toast(ToastType.Success, response.Message), true);
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }

    }
}
