using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PictureDtos;
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
    public class PictureController : BaseAdminController<PictureController>
    {
        #region ctor

        private readonly IPictureService _PictureService;

        public PictureController(IPictureService PictureService)
        {
            _PictureService = PictureService;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index(FilterPictureDto filter, PagingDto paging)
        {
            var response = await _PictureService.GetAll(filter, paging);
            if (response.Result == ResponseResult.Success)
            {
                return View(response.Data);
            }
            return ResolveNoSuccessResult(ResponseResult.Success);
        }



        public async Task<IActionResult> Table(FilterPictureDto filter, PagingDto paging)
        {
            var response = await _PictureService.GetAll(filter, paging);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Table", response.Data));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }



        
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _PictureService.Delete(Id);
            if (response.Result == ResponseResult.Success)
            {
                var model = (await _PictureService.GetAll(new FilterPictureDto())).Data;
                return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("_Table", model), new Toast(ToastType.Success, response.Message));
                //return _ClientHandleResult.PartialThenToast(HttpContext, PartialView(model), new Toast(ToastType.Success, response.Message));
                //return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, "Index", new Toast(ToastType.Success, response.Message), true);
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }

    }
}
