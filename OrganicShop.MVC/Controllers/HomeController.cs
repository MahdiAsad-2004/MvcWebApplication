using AutoMapper;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using OrganicShop.Ioc;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        #region ctor

        private readonly INewsLetterMemberService _NewsLetterMemberService;
        public HomeController(INewsLetterMemberService newsLetterMemberService)
        {
            _NewsLetterMemberService = newsLetterMemberService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {

            return View("Index");
        }




        [HttpPost]
        public async Task<IActionResult> SubscribeNewsLetter(CreateNewsLetterMemberDto create)
        {
            var response = await _NewsLetterMemberService.Create(create);
            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("_NewsLetterSection" , new CreateNewsLetterMemberDto())
                    ,new Toast(ToastType.Success, response.Message));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Warning, response.Message));
        }







        [HttpGet("qwe")]
        public IActionResult test()
        {
            return PartialView("_Error404");
        }
    }
}
