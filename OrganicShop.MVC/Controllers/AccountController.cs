using AutoMapper;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Dtos.WishItemDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using OrganicShop.Ioc;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;
using System.Security.Claims;

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
            createUser.Role = Role.Customer;

            var response = await _UserService.Create(createUser);
            if (response.Result == ResponseResult.Success)
            {
                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, "/Home", new Toast(ToastType.Success, "شما با موفقیت ثبت نام شدید"), true, responseResult: true);
            }

            if (response.Result == ResponseResult.ValidationError)
            {
                foreach (var item in response.ValidationFailures)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return _ClientHandleResult.Partial(HttpContext, PartialView("SignUp", createUser), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);

        }



        [HttpGet("/account/sign-in")]
        public async Task<IActionResult> SignIn()
        {
            return View(new SignInUserDto());
        }


        [HttpPost("/account/sign-in")]
        public async Task<IActionResult> SignIn_Post(SignInUserDto signInUser)
        {
            var response = await _UserService.SignIn(signInUser);
            if (response.Result == ResponseResult.Success)
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier,response.Data.Id.ToString()),
                    new(ClaimTypes.Name,response.Data.Name),
                    new(ClaimTypes.MobilePhone,signInUser.PhoneNumber),
                    new(ClaimTypes.Role , response.Data.Role.ToString()),
                    new(ClaimTypes.Email , response.Data.Email),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = signInUser.RememberMe,
                    ExpiresUtc = DateTimeOffset.Now.AddHours(1),
                };
                await HttpContext.SignInAsync(principal, properties);

                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData, "/home", new Toast(ToastType.Success, response.Message), true);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, response.Message), responseResult: false);

        }



        [HttpGet("/account/log-out")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }










    }
}
