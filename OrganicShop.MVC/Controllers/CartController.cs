using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OrganicShop.BLL.Extensions;
using OrganicShop.BLL.Providers;
using OrganicShop.BLL.Utils;
using OrganicShop.Domain.Dtos.CartDtos;
using OrganicShop.Domain.Dtos.CouponDtos;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Response;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Extensions;
using OrganicShop.Mvc.Models.Toast;
using System.Text.Json;

namespace OrganicShop.Mvc.Controllers
{
    public class CartController : BaseController<ProductController>
    {
        #region ctor

        private readonly AesKeys _AesKeys;
        private readonly ICartService _CartService;
        private readonly IOrderService _OrderService;
        private readonly IAddressService _AddressService;
        private readonly IShippingMethodService _ShippingMethodService;
        private readonly IProductItemService _ProductItemService;
        public CartController(IProductItemService productItemService, IOptions<AesKeys> options, ICartService cartService,
            IAddressService addressService, IShippingMethodService deliveryService, IOrderService orderService)
        {
            _ProductItemService = productItemService;
            _AesKeys = options.Value;
            _CartService = cartService;
            _AddressService = addressService;
            _ShippingMethodService = deliveryService;
            _OrderService = orderService;
        }

        #endregion



        private List<ProductItemCookieDto> GetCookieProductItems()
        {
            List<ProductItemCookieDto> previousProductItems = new();
            var CookieCartItemsStrCoded = Request.Cookies[AppCookies.UnknownUserCartItems.Key];
            if (string.IsNullOrEmpty(CookieCartItemsStrCoded) == false)
            {
                var CookieCartItemsStr = AesOperation.Decrypt(CookieCartItemsStrCoded, _AesKeys.Cookie);
                if (string.IsNullOrEmpty(CookieCartItemsStr) == false)
                {
                    previousProductItems = JsonSerializer.Deserialize<List<ProductItemCookieDto>>(CookieCartItemsStr) ?? new List<ProductItemCookieDto>();
                }
            }
            return previousProductItems;
        }


        private async Task<List<ProductItemListDto>> GetProductItemListDtos()
        {
            List<ProductItemListDto> model = new();
            if (User.Identity.IsAuthenticated)
            {
                var userId = HttpContext.GetAppUser().Id;
                if (userId > 0)
                {
                    model = (await _ProductItemService.GetAll(new FilterProductItemDto { CartUserId = userId }))?.Data ?? new List<ProductItemListDto>();
                }
            }
            else
            {
                List<ProductItemCookieDto> previousCreates = GetCookieProductItems();

                if (previousCreates.Any())
                {
                    model = (await _ProductItemService.GetAll(previousCreates))?.Data ?? new List<ProductItemListDto>();
                }
            }
            return model;
        }





        [HttpGet("/Cart")]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                CartDetailDto model = (await _CartService.GetDetail(AppUser.Id)).Data;
                return View("Cart", model);
            }
            return View("Cart", new CartDetailDto { ProductItems = (await GetProductItemListDtos()).ToArray() });
        }
        


        [HttpGet("/CartSummary")]
        public async Task<IActionResult> Indexx()
        {
            List<ProductItemListDto> model = await GetProductItemListDtos();
            return PartialView("_CartSummary", model);
        }




        [HttpPost("/Cart/AddProduct")]
        public async Task<IActionResult> AddProductItem(CreateProductItemDto createProductItem)
        {
            var successToast = new Toast(ToastType.Success, "محصول با موفقیت به سبد خربد افزوده شد", 3000);
            if (User.Identity.IsAuthenticated)
            {
                var response = await _ProductItemService.Create(createProductItem);
                if (response.Result == ResponseResult.Success)
                {
                    return _ClientHandleResult.Toast(HttpContext, successToast);
                }
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
            }
            else
            {
                List<ProductItemCookieDto> previousProductItems = GetCookieProductItems();

                var response = await _ProductItemService.CreateForCookie(createProductItem, previousProductItems);

                Response.Cookies.Append(AppCookies.UnknownUserCartItems.Key,
                    AesOperation.Encrypt(AppCookies.UnknownUserCartItems.GenerateJsonValue(response.Data), _AesKeys.Cookie), AppCookies.UnknownUserCartItems.Options);
                return _ClientHandleResult.Toast(HttpContext, successToast);
            }
        }


        public async Task<IActionResult> EditProductItemCount(long productItemId, int count)
        {
            if (User.Identity.IsAuthenticated)
            {
                var response = await _ProductItemService.Update(new UpdateProductItemDto { Id = productItemId, Count = count });
                if (response.Result == ResponseResult.Success)
                {
                    var model = (await _CartService.GetDetail(AppUser.Id)).Data;
                    return _ClientHandleResult.Partial(HttpContext, PartialView("Cart", model));
                }
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
            }
            else
            {
                var response = await _ProductItemService.UpdateForCookie(productItemId, count, GetCookieProductItems());
                if (response.Result == ResponseResult.Success)
                {
                    var newProductItemCookieDtos = response.Data;
                    Response.Cookies.Append(
                            AppCookies.UnknownUserCartItems.Key,
                            AesOperation.Encrypt(AppCookies.UnknownUserCartItems.GenerateJsonValue(newProductItemCookieDtos), _AesKeys.Cookie),
                            AppCookies.UnknownUserCartItems.Options);

                    var model = (await _CartService.GetDetail(GetCookieProductItems())).Data;
                    return _ClientHandleResult.Partial(HttpContext, PartialView("Cart", model));
                }
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
            }
        }


        public async Task<IActionResult> RemoveProductItem(long productItemId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var response = await _ProductItemService.Delete(productItemId);
                if (response.Result == ResponseResult.Success)
                {
                    var model = (await _CartService.GetDetail(AppUser.Id)).Data;    
                    return _ClientHandleResult.Partial(HttpContext, PartialView("Cart", model));
                }
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
            }
            else
            {
                var productItemCookieDtos = GetCookieProductItems();
                var removeItem = productItemCookieDtos.FirstOrDefault(a => a.ProductId == productItemId);
                if (removeItem != null)
                {
                    if (productItemCookieDtos.Remove(removeItem))
                    {
                        Response.Cookies.Append(
                            AppCookies.UnknownUserCartItems.Key,
                            AesOperation.Encrypt(AppCookies.UnknownUserCartItems.GenerateJsonValue(productItemCookieDtos), _AesKeys.Cookie),
                            AppCookies.UnknownUserCartItems.Options);
                        var model = (await _CartService.GetDetail(GetCookieProductItems())).Data;
                        return _ClientHandleResult.Partial(HttpContext, PartialView("Cart", model));
                    }
                }
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, "محصول در سبد خرید وجود نداشت !"), responseResult: false);
            }
        }


        [HttpPost("/CartSummary/RemoveProductItem")]
        public async Task<IActionResult> RemoveProductItem_1(long productItemId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var response = await _ProductItemService.Delete(productItemId);
                if (response.Result == ResponseResult.Success)
                {
                    var model = await GetProductItemListDtos();
                    return _ClientHandleResult.Partial(HttpContext, PartialView("_CartSummary", model));
                }
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
            }
            else
            {
                var productItemCookieDtos = GetCookieProductItems();
                var removeItem = productItemCookieDtos.FirstOrDefault(a => a.ProductId == productItemId);
                if (removeItem != null)
                {
                    if (productItemCookieDtos.Remove(removeItem))
                    {
                        Response.Cookies.Append(
                            AppCookies.UnknownUserCartItems.Key,
                            AesOperation.Encrypt(AppCookies.UnknownUserCartItems.GenerateJsonValue(productItemCookieDtos), _AesKeys.Cookie),
                            AppCookies.UnknownUserCartItems.Options);
                        var model = (await _ProductItemService.GetAll(productItemCookieDtos))?.Data ?? new List<ProductItemListDto>();
                        return _ClientHandleResult.Partial(HttpContext, PartialView("_CartSummary", model));
                    }
                }
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, "محصول در سبد خرید وجود نداشت !"), responseResult: false);
            }
        }


        [Authorize]
        [HttpPost("/cart/productItem/add-to-next-cart")]
        public async Task<IActionResult> AddToNextCart(long productItemId)
        {
            var response = await _ProductItemService.AddToNextCart(productItemId);

            if (response.Result == ResponseResult.Success)
            {
                var model = (await _CartService.GetDetail(AppUser.Id)).Data;
                return _ClientHandleResult.Partial(HttpContext, PartialView("Cart", model));
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }




        [HttpPost("/cart/apply-coupon")]
        public async Task<IActionResult> ApplyCoupon(CouponApplyingDto couponApplyingDto)
        {
            ServiceResponse<CartDetailDto>? response = null;
            if (User.Identity.IsAuthenticated)
            {
                couponApplyingDto.UserId = AppUser.Id;
                response = await _CartService.ApplyCoupon(couponApplyingDto);
            }
            else
            {
                response = await _CartService.ApplyCoupon(GetCookieProductItems(), couponApplyingDto);
            }

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Cart-Bill", response.Data.Bill));
            
            if (response.Result == ResponseResult.ValidationError)
            {
                AddErrorsToModelState(ModelState, response.ValidationErrors);
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Cart-ApplyCoupon", couponApplyingDto), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);

        }


        
        [HttpGet("/cart-bill")]
        public async Task<IActionResult> CartBill()
        {
            ServiceResponse<BillDto>? response = null;
            if (User.Identity.IsAuthenticated)
            {
                response = await _CartService.GetBill(AppUser.Id);
            }
            else
            {
                response = await _CartService.GetBill(GetCookieProductItems());
            }

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Cart-Bill", response.Data));
            
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);

        }












    }
}
