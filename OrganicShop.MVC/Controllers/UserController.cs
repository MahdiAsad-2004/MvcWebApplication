
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
    public class UserController : BaseController<UserController>
    {
        #region ctor

        private readonly IUserService _UserService;
        private readonly IWishItemService _WishItemService;
        public UserController(IUserService userService, IWishItemService wishItemService)
        {
            _UserService = userService;
            _WishItemService = wishItemService;
        }

        #endregion





        public async Task<IActionResult> AddToWishList(long productId)
        {
            var response = await _WishItemService.Create(new CreateWishItemDto { ProductId = productId});
            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Empty(HttpContext);

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }


    }
}
