using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ContactUsDtos;
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
    public class ContactUsController : BaseAdminController<ContactUsController>
    {
        #region ctor

        private readonly IContactUsService _ContactUsService;

        public ContactUsController(IContactUsService ContactUsService)
        {
            _ContactUsService = ContactUsService;
        }

        #endregion



        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> Get()
        {
            var response = await _ContactUsService.Get();
            if (response.Result == ResponseResult.Success)
            {
                return View("Edit",response.Data);
            }
            return ResolveNoSuccessResult(response.Result);
        }


        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> Get(UpdateContactUsDto update)
        {
            //return _ClientHandleResult.Json(HttpContext,update);
            //return Json(update);
            var response = await _ContactUsService.Update(update);
            if (response.Result == ResponseResult.Success)
            {
                return _ClientHandleResult.RedirectThenToast(HttpContext,TempData ,"", new Toast(ToastType.Success, response.Message),true);
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));

        }
    }
}
