
using AutoMapper;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.BankCardDtos;
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
using System.Security.Claims;

namespace OrganicShop.Mvc.Controllers
{
    public class UserController : BaseController<UserController>
    {
        #region ctor

        private readonly IUserService _UserService;
        private readonly IProductService _ProductService;
        private readonly IAddressService _AddressService;
        private readonly IWishItemService _WishItemService;
        private readonly IBankCardService _BankCardService;
        private readonly INewsLetterMemberService _NewsLetterMemberService;
        public UserController(IUserService userService, IWishItemService wishItemService, IProductService productService,
            IAddressService adressService, IBankCardService bankCardService, INewsLetterMemberService newsLetterMemberService)
        {
            _UserService = userService;
            _WishItemService = wishItemService;
            _ProductService = productService;
            _AddressService = adressService;
            _BankCardService = bankCardService;
            _NewsLetterMemberService = newsLetterMemberService;
        }

        #endregion



        [HttpGet("/profile")]
        [AuthorizeRole(Role.Customer, Role.Seller, Role.Admin, Role.Manager)]
        public async Task<IActionResult> Profile()
        {
            var response = await _UserService.GetProfileDto();

            if (response.Result != ResponseResult.Success)
                return Redirect("/error/403");

            var wishProductIds = (await _WishItemService.GetUserWishProductIds()).Data;
            ViewData["WishProducts"] = (await _ProductService.GetAllSummary(new FilterProductDto { Ids = wishProductIds })).Data?.List;
            ViewData["IsMemberOfNewsLetter"] = await _NewsLetterMemberService.IsMemberOfNewsLetter(AppUser.Id);


            return View(response.Data);
        }




        [HttpPost]
        public async Task<IActionResult> EditProductWishList(long productId, bool isDelete)
        {
            Console.WriteLine($"--------- product id: {productId} ------------ is delete: {isDelete} -----------------");
            
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






        [HttpPost("/profile/setting")]
        public async Task<IActionResult> UpdateUserPrivacy(UpdateUserPrivacyDto updateUserPrivacy)
        {
            updateUserPrivacy.UserId = AppUser.Id;

            var response = await _UserService.UpdatePrivacy(updateUserPrivacy);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "تنظیمات حساب شما با موفقیت ویرایش شد"));

            if (response.Result == ResponseResult.ValidationError)
            {
                AddErrorsToModelState(ModelState, response.ValidationFailures);
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Profile-SettingTab", updateUserPrivacy), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }



        [HttpPost("/profile/change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePassword)
        {
            changePassword.UserId = AppUser.Id;

            var response = await _UserService.ChangePassword(changePassword);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "رمز عبور شما با موفقیت ویرایش شد"));

            if (response.Result == ResponseResult.ValidationError)
            {
                AddErrorsToModelState(ModelState, response.ValidationFailures);
                return _ClientHandleResult.Partial(HttpContext, PartialView("_ChangePasswordModal", changePassword), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }



        [HttpPost("/profile/delete")]
        public async Task<IActionResult> DeleteUser()
        {
            var response = await _UserService.Delete(AppUser.Id);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.RedirectThenToast(HttpContext, TempData ,"/home", new Toast(ToastType.Success, "حساب کاربری شما با موفقیت حذف شد"),true );

            return _ClientHandleResult.Toast(HttpContext , new Toast(ToastType.Error,response.Message) , responseResult:false);
        }

        

        [HttpPost("/profile/subscire-newsLetter")]
        public async Task<IActionResult> SubscribeNewsLetter(CreateNewsLetterMemberDto createNewsLetter)
        {
            createNewsLetter.UserId = AppUser.Id;
            createNewsLetter.Email = AppUser.Email;

            var response = await _NewsLetterMemberService.Create(createNewsLetter);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "عضویت شما در خبرنامه با موفقیت انجام شد"));

            if(response.Result == ResponseResult.ValidationError)
            {
                AddErrorsToModelState(ModelState , response.ValidationFailures);
                return _ClientHandleResult.Partial(HttpContext, PartialView("_SubscribeUserNewsLetter", createNewsLetter), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext , new Toast(ToastType.Error,response.Message) , responseResult:false);
        }









        #region profile => info tab


        [HttpGet("/profile/info")]
        public async Task<IActionResult> UserInfo()
        {
            var model = (await _UserService.GetUpdateDto(AppUser.Id)).Data;
            return _ClientHandleResult.Partial(HttpContext, PartialView("_Profile-InfoTab", model));
        }



        [HttpPost("/profile/info")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUser)
        {

            if (AppUser.Id != updateUser.Id)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, "شما به این بخش دسترسی ندارید "), responseResult: false);

            updateUser.LogAsync();

            return Empty;

            var response = await _UserService.Update(updateUser);

            if (response.Result == ResponseResult.Success)
            {
                #region edit user identity


                var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier,updateUser.Id.ToString()),
                    new(ClaimTypes.Name,updateUser.Name),
                    new(ClaimTypes.MobilePhone,updateUser.PhoneNumber_readonly),
                    //new(ClaimTypes.Role , updateUser.rol.ToString()),
                    new(ClaimTypes.Email , updateUser.Email),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                User.AddIdentity(identity);


                #endregion

                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "اطلاعات شما با موفقیت ویرایش شد"));
            }

            if (response.Result == ResponseResult.ValidationError)
            {
                foreach (var item in response.ValidationFailures)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return _ClientHandleResult.Partial(HttpContext, PartialView("_EditUserInfoModal", updateUser), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }


        #endregion



        #region profile => address tab

        [HttpPost("/profile/address/add")]
        public async Task<IActionResult> AddAddress(CreateAddressDto createAddress)
        {
            if (createAddress != null)
            {
                createAddress.UserId = AppUser.Id;
            }

            var response = await _AddressService.Create(createAddress);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "آدرس جدید با موفقیت افزوده شد"));

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


        [HttpPost("/profile/address/edit")]
        public async Task<IActionResult> EditAddress(UpdateAddressDto updateAddress)
        {
            var response = await _AddressService.Update(updateAddress);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "آدرس با موفقیت ویرایش شد"));

            //var model = (await _AddressService.GetAll(new FilterAddressDto { UserId = AppUser.Id })).Data.List;

            if (response.Result == ResponseResult.ValidationError)
            {
                foreach (var item in response.ValidationFailures)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return _ClientHandleResult.Partial(HttpContext, PartialView("_EditAddressModal", updateAddress), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }


        [HttpPost("/profile/address/delete")]
        public async Task<IActionResult> DeleteAddress(long Id)
        {
            var response = await _AddressService.Delete(Id);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "آدرس با موفقیت حذف شد"));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }


        [HttpGet("/profile/address")]
        public async Task<IActionResult> AddressTab()
        {
            var model = (await _AddressService.GetAll(new FilterAddressDto { UserId = AppUser.Id })).Data.List;

            return _ClientHandleResult.Partial(HttpContext, PartialView("_Profile-AddressTab", model));
        }


        [HttpGet("/profile/address/{Id:long}")]
        public async Task<IActionResult> AddressEditModal(long Id)
        {
            var response = await _AddressService.Get(Id);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("_EditAddressModal", response.Data));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }


        #endregion



        #region profile => bankCard tab


        [HttpPost("/profile/bankCard/add")]
        public async Task<IActionResult> AddBankCard(CreateBankCardDto createBankCard)
        {
            if (createBankCard != null)
            {
                createBankCard.UserId = AppUser.Id;
            }

            var response = await _BankCardService.Create(createBankCard);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "کارت بانکی جدید با موفقیت افزوده شد"));

            if (response.Result == ResponseResult.ValidationError)
            {
                foreach (var item in response.ValidationFailures)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return _ClientHandleResult.Partial(HttpContext, PartialView("_AddBankCardModal", createBankCard), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }


        [HttpPost("/profile/bankCard/edit")]
        public async Task<IActionResult> EditBankCard(UpdateBankCardDto updateBankCard)
        {
            var response = await _BankCardService.Update(updateBankCard);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "کارت بانکی با موفقیت ویرایش شد"));

            if (response.Result == ResponseResult.ValidationError)
            {
                foreach (var item in response.ValidationFailures)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return _ClientHandleResult.Partial(HttpContext, PartialView("_EditBankCardModal", updateBankCard), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }


        [HttpPost("/profile/bankCard/delete")]
        public async Task<IActionResult> DeleteBankCard(long Id)
        {
            var response = await _BankCardService.Delete(Id);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "کارت بانکی با موفقیت حذف شد"));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }


        [HttpGet("/profile/bankCard")]
        public async Task<IActionResult> BankCardTab()
        {
            var model = (await _BankCardService.GetAll(new FilterBankCardDto { UserId = AppUser.Id })).Data.List;

            return _ClientHandleResult.Partial(HttpContext, PartialView("_Profile-BankCardTab", model));
        }


        [HttpGet("/profile/bankCard/{Id:long}")]
        public async Task<IActionResult> BankCardEditModal(long Id)
        {
            var response = await _BankCardService.Get(Id);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("_EditBankCardModal", response.Data));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }

        #endregion












    }
}
