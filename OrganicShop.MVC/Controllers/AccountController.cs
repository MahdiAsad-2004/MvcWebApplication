using AutoMapper;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Dtos.WishItemDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using OrganicShop.Ioc;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class AccountController : BaseController<AccountController>
    {
        #region ctor

        private readonly IUserService _UserService;
        private readonly IWishItemService _WishItemService;
        public AccountController(IUserService userService, IWishItemService wishItemService)
        {
            _UserService = userService;
            _WishItemService = wishItemService;
        }

        #endregion


        [HttpGet("/account/sign-up")]
        public async Task<IActionResult> SignUp()
        {
            return View(new CreateUserDto());
        }


        [HttpPost("/account/sign-up")]
        public async Task<IActionResult> SignUp_Post(CreateUserDto createUser)
        {
            var response = await _UserService.Create(createUser);
            if(response.Result == ResponseResult.Success)
            {
                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, "/Home", new Toast(ToastType.Success, response.Message), true, responseResult: true);
            }

            if(response.Result == ResponseResult.ValidationError)
            {
                foreach (var item in response.ValidationErrors)
                {
                    ModelState.AddModelError(item.Key , item.Value);
                }
                return _ClientHandleResult.Partial(HttpContext, PartialView("SignUp", createUser), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        
        }





    }
}
