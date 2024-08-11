using MD.PersianDateTime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OrganicShop.BLL.Extensions;
using OrganicShop.BLL.Providers;
using OrganicShop.BLL.Services;
using OrganicShop.BLL.Utils;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.ArticleDtos;
using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Dtos.OrderDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Dtos.UserMessageDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Enums.SortTypes;
using OrganicShop.Domain.IServices;
using OrganicShop.Ioc;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Extensions;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class OrderController : BaseController<OrderController>
    {
        #region ctor

        private readonly AesKeys _AesKeys;
        private readonly IOrderService _OrderService;
        private readonly ICartService _CartService;
        private readonly IAddressService _AddressService;
        private readonly IProductItemService _ProductItemService;
        private readonly IShippingMethodService _ShippingMethodService;
        public OrderController(IOrderService orderService, IAddressService addressService, IProductItemService productItemService,
            IShippingMethodService deliveryService, IOptions<AesKeys> aesKeys, ICartService cartService)
        {
            _AesKeys = aesKeys.Value;
            _OrderService = orderService;
            _AddressService = addressService;
            _ProductItemService = productItemService;
            _ShippingMethodService = deliveryService;
            _CartService = cartService;
        }

        #endregion


        [Authorize]
        [HttpGet("/Checkout")]
        public async Task<IActionResult> Checkout(string couponCode)
        {
            long userId = AppUser.Id;

            if (userId < 1)
                return Redirect("/Error/404");

            var cartDetailDto = (await _CartService.GetDetail(userId, couponCode)).Data;

            if(cartDetailDto == null)
                return Redirect("/Error/404");

            ViewData["ProductItems"] = cartDetailDto.ProductItems.ToList();
            var cartId = cartDetailDto.ProductItems.FirstOrDefault()?.CartId;

            if (cartId == null)
                return Redirect("/Error/404");

            var userAddresses = (await _AddressService.GetAll(new FilterAddressDto { UserId = userId })).Data?.List ?? new List<AddressListDto>(); ;
            ViewData["UserAddresses"] = userAddresses;

            long addressId = userAddresses.FirstOrDefault()?.Id ?? 0;

            var shippingMethods = (await _ShippingMethodService.GetAll()).Data;
            var shippingMethod = shippingMethods.First(a => a.Id == 1);
            ViewData["ShippingMethods"] = shippingMethods;

            CreateOrderDto createOrder = new CreateOrderDto()
            {
                AddressId = addressId,
                CartId = cartId.Value,
                OrderStatus = OrderStatus.AwaitingPayment,
                PaymentMethod = PaymentMethod.PaymentGeteway,
                SendDate = PersianDateTime.Now.AddDays(3).ToString("yyyy/MM/dd"),
                ShippingMethodName = shippingMethod.Name,
                ShippingPrice = shippingMethod.Price,
                TotalPrice = cartDetailDto.Bill.TotalPrice,
                UserId = userId,
                ShippingMethodId = 1,
                CouponAmount = cartDetailDto.Bill.CouponAmount,
                CouponId = cartDetailDto.Bill.CouponId,
                ProductItemIdAndPrice = cartDetailDto.ProductItems
                    .ToDictionary(a => a.Id , a => a.ProductDiscountedPrice != null ? a.ProductDiscountedPrice.Value : a.ProductPrice),
                DiscountIdAndProductCount = cartDetailDto.ProductItems
                    .Where(a => a.ProductDiscounteId != null)
                    .ToDictionary(a => a.ProductDiscounteId.Value, b => b.Count),
            };
            createOrder.FinalPrice = createOrder.TotalPrice - createOrder.CouponAmount + createOrder.ShippingPrice;

            Response.Cookies.Append(AppCookies.CreateOrder.Key,
                AesOperation.Encrypt(AppCookies.CreateOrder.GenerateJsonValue(createOrder), _AesKeys.Checkout),
                AppCookies.CreateOrder.Options);

            return View("Checkout", createOrder);
        }


        [Authorize]
        [HttpPut("/Checkout")]
        public async Task<IActionResult> Checkout_Put(int shippingMethodId)
        {
            CreateOrderDto? createOrder = AppCookies.CreateOrder.GetModel(AesOperation.Decrypt(Request.Cookies[AppCookies.CreateOrder.Key], _AesKeys.Checkout));

            if (createOrder == null)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, "سفارش شما یافت نشد"), responseResult: false);

            shippingMethodId = shippingMethodId < 1 ? 1 : shippingMethodId;

            var shippingMethods = (await _ShippingMethodService.GetAll()).Data;
            var shippingMehod = shippingMethods.First(a => a.Id == shippingMethodId);
            ViewData["ShippingMethods"] = shippingMethods;

            createOrder.ShippingMethodName = shippingMehod.Name;
            createOrder.ShippingPrice = shippingMehod.Price;
            createOrder.ShippingMethodId = (byte)shippingMethodId;

            createOrder.FinalPrice = createOrder.TotalPrice + createOrder.ShippingPrice - createOrder.CouponAmount;

            Response.Cookies.Append(AppCookies.CreateOrder.Key,
                            AesOperation.Encrypt(AppCookies.CreateOrder.GenerateJsonValue(createOrder), _AesKeys.Checkout),
                            AppCookies.CreateOrder.Options);

            return _ClientHandleResult.Partial(HttpContext, PartialView("_Checkout-Summary", createOrder));
        }





        [Authorize]
        [HttpPost("/Checkout")]
        public async Task<IActionResult> Checkout_Post(CreateOrderDto create)
        {
            CreateOrderDto? createOrder = AppCookies.CreateOrder.GetModel(AesOperation.Decrypt(Request.Cookies[AppCookies.CreateOrder.Key], _AesKeys.Checkout));

            if (createOrder == null)
                _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, "سفارش شما ثبت نشد !"), responseResult: false);

            createOrder.AddressId = create.AddressId;
            createOrder.SendDate = create.SendDate;
            createOrder.PaymentMethod = create.PaymentMethod;
            createOrder.OrderStatus = create.PaymentMethod != PaymentMethod.CartToCart ? OrderStatus.Success : OrderStatus.AwaitingPayment;

            var response = await _OrderService.Create(createOrder);

            if (response.Result == ResponseResult.Success)
            {
                Response.Cookies.Delete(AppCookies.CreateOrder.Key);
                return _ClientHandleResult.ToastThenRedirect(HttpContext, $"/order/success/{response.Data}", new Toast(ToastType.Success, response.Message,3000), true);
            }

            if(response.Result == ResponseResult.ValidationError)
            {
                ViewData["UserAddresses"] = (await _AddressService.GetAll(new FilterAddressDto { UserId = AppUser.Id })).Data?.List ?? new List<AddressListDto>();
                ViewData["ShippingMethods"] = (await _ShippingMethodService.GetAll()).Data;
                AddErrorsToModelState(ModelState,response.ValidationErrors);
                return _ClientHandleResult.Partial(HttpContext, PartialView("_Checkout-CreateOrderForm", createOrder));
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult:false);
        }






        [Authorize]
        [HttpGet("/Checkout/Addresses")]
        public async Task<IActionResult> CheckoutAddresses()
        {
            var model = (await _AddressService.GetAll(new FilterAddressDto { UserId = AppUser.Id })).Data?.List ?? new List<AddressListDto>(); ;
            return _ClientHandleResult.Partial(HttpContext, PartialView("_Checkout-Addresses", model));
        }





        [HttpGet("/order/success/{trackingCode}")]
        public async Task<IActionResult> Success(string trackingCode)
        {
            var model = (await _OrderService.GetDetail(trackingCode)).Data;
            return View("Success", model);
        }







        public async Task<IActionResult> Tracking(string trackingCode)
        {
            return View("Tracking");
        }





    }
}
