
using AutoMapper;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Dtos.WishItemDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using OrganicShop.Ioc;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Extensions;
using OrganicShop.Mvc.Models.Toast;
using OrganicShop.MVC.Attributes;

namespace OrganicShop.Mvc.Controllers
{
    public class UserController : BaseController<UserController>
    {
        #region ctor

        private readonly IUserService _UserService;
        private readonly IProductService _ProductService;
        private readonly IAddressService _AdressService;
        private readonly IWishItemService _WishItemService;
        public UserController(IUserService userService, IWishItemService wishItemService, IProductService productService, IAddressService adressService)
        {
            _UserService = userService;
            _WishItemService = wishItemService;
            _ProductService = productService;
            _AdressService = adressService;
        }

        #endregion



        [HttpGet("/profile")]
        [AuthorizeRole(Role.Customer, Role.Seller, Role.Admin, Role.Manager)]
        public async Task<IActionResult> Profile()
        {
            var wishProductIds = (await _WishItemService.GetUserWishProductIds()).Data;
            ViewData["WishProducts"] = (await _ProductService.GetAllSummary(new FilterProductDto { Ids = wishProductIds })).Data?.List;




            return View();
        }

















        [HttpPost]
        public async Task<IActionResult> EditProductWishList(long productId, bool isDelete)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return _ClientHandleResult.Redirect(HttpContext, "Login", "Account", false);
            }
            if (isDelete)
            {
                var response = await _WishItemService.Delete(productId);
                if (response.Result == ResponseResult.Success)
                    return _ClientHandleResult.Empty(HttpContext);

                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
            }
            else
            {
                var response = await _WishItemService.Create(new CreateWishItemDto { ProductId = productId });
                if (response.Result == ResponseResult.Success)
                    return _ClientHandleResult.Empty(HttpContext);

                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
            }
        }



        [HttpPost("/profile/address/add")]
        public async Task<IActionResult> AddAddress(CreateAddressDto createAddress)
        {
            if (createAddress != null)
            {
                createAddress.UserId = AppUser.Id;
            }

            var response = await _AdressService.Create(createAddress);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "آدرس جدید با موفقیت افزوده شد"));

            //var model = (await _AdressService.GetAll(new FilterAddressDto { UserId = AppUser.Id })).Data.List;

            if (response.Result == ResponseResult.ValidationError)
            {
                foreach (var item in response.ValidationFailures)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return _ClientHandleResult.Partial(HttpContext, PartialView("_AddAddressModal", createAddress), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }


        [HttpGet("/profile/address")]
        public async Task<IActionResult> AddressTab()
        {
            var model = (await _AdressService.GetAll(new FilterAddressDto { UserId = AppUser.Id })).Data.List;

            return _ClientHandleResult.Partial(HttpContext, PartialView("_Profile-AddressTab", model));
        }







    }
}
