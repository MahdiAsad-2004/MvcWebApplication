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




        //[Authorize]
        //[HttpGet("/Checkout")]
        //public async Task<IActionResult> Checkout(string discount , int shippingMethod)
        //{
        //    string? discountPriceStr = string.IsNullOrWhiteSpace(discount) ? null : AesOperation.Decrypt(discount, _AesKeys.CheckoutUrl);
        //    bool freeDelivery = false;
        //    int discountPrice = 0;
        //    if(discountPriceStr != null)
        //    {
        //        freeDelivery = discountPriceStr.Equals("freeDelivery" , StringComparison.OrdinalIgnoreCase);
        //        int.TryParse(discountPriceStr, out discountPrice);
        //        ViewBag.Discount = discount;
        //    }
        //    shippingMethod = shippingMethod < 1 ? 1 : shippingMethod;

        //    long userId = User.GetAppUser().Id;

        //    if (userId < 1)
        //        return Redirect("/Error/404");

        //    var productItems = (await _ProductItemService.GetAll(new FilterProductItemDto { UserId = userId }))?.Data ?? new List<ProductItemListDto>();
        //    ViewData["ProductItems"] = productItems;
        //    var cartId = productItems.FirstOrDefault()?.CartId;

        //    if (cartId == null)
        //    {
        //        return Redirect("/Error/404");
        //    }

        //    ViewData["UserAddresses"] = (await _AddressService.GetAll(new FilterAddressDto { UserId = userId })).Data?.List ?? new List<AddressListDto>();

        //    var shippingMethods = (await _ShippingMethodService.GetAll()).Data; 
        //    ViewBag.FreeDelivery = freeDelivery;

        //    var create = new CreateOrderDto
        //    {
        //        DiscountPrice = discountPrice,
        //        CartId = cartId.Value,
        //        UserId = userId,
        //        PaymentMethod = PaymentMethod.Cash,
        //    };

        //    return View("Checkout", create);
        //}




        [Authorize]
        [HttpGet("/Checkout")]
        public async Task<IActionResult> Checkout(string discount)
        {
            string? discountPriceStr = string.IsNullOrWhiteSpace(discount) ? null : AesOperation.Decrypt(discount, _AesKeys.Checkout);
            bool freeDelivery = false;
            int discountPrice = 0;
            if (discountPriceStr != null)
            {
                freeDelivery = discountPriceStr.Equals("freeDelivery", StringComparison.OrdinalIgnoreCase);
                int.TryParse(discountPriceStr, out discountPrice);
                ViewBag.Discount = discount;
            }

            long userId = User.GetAppUser().Id;

            if (userId < 1)
                return Redirect("/Error/404");

            var productItems = (await _ProductItemService.GetAll(new FilterProductItemDto { CartUserId = userId }))?.Data ?? new List<ProductItemListDto>();
            ViewData["ProductItems"] = productItems;
            var cartId = productItems.FirstOrDefault()?.CartId;

            if (cartId == null)
            {
                return Redirect("/Error/404");
            }

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
                PaymentMethod = PaymentMethod.PaymentGeteway,
                //SendDate = DateTime.Now.AddDays(3),
                ShippingMethodName = shippingMethod.Name,
                ShippingPrice = shippingMethod.Price,
                TotalPrice = productItems.Sum(a => (a.DiscountedPrice != null ? a.DiscountedPrice.Value : a.Price) * a.Count),
                UserId = userId,
                IsFreeDelivery = freeDelivery,
                ShippingMethodId = 1
            };
            createOrder.DiscountPrice = freeDelivery ? shippingMethod.Price : discountPrice;
            createOrder.FinalPrice = createOrder.TotalPrice - createOrder.DiscountPrice + createOrder.ShippingPrice;

            Response.Cookies.Append(AppCookies.CreateOrder.Key, AesOperation.Encrypt(AppCookies.CreateOrder.GenerateJsonValue(createOrder), _AesKeys.Checkout));

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

            createOrder.FinalPrice = createOrder.TotalPrice + createOrder.ShippingPrice - createOrder.DiscountPrice;

            Response.Cookies.Append(AppCookies.CreateOrder.Key, AesOperation.Encrypt(AppCookies.CreateOrder.GenerateJsonValue(createOrder), _AesKeys.Checkout));

            return _ClientHandleResult.Partial(HttpContext, PartialView("_Checkout-Summary", createOrder));
        }





        [Authorize]
        [HttpPost("/Checkout")]
        public async Task<IActionResult> Checkout_Post(CreateOrderDto create)
        {
            create.LogAsync();

            CreateOrderDto? createOrder = AppCookies.CreateOrder.GetModel(AesOperation.Decrypt(Request.Cookies[AppCookies.CreateOrder.Key], _AesKeys.Checkout));

            if (createOrder == null)
                _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, "سفارش شما ثبت نشد !"), responseResult: false);

            createOrder.LogAsync();

            createOrder.AddressId = create.AddressId;
            createOrder.SendDate = create.SendDate;
            createOrder.PaymentMethod = create.PaymentMethod;

            //return _ClientHandleResult.Empty(HttpContext);

            var response = await _OrderService.Create(createOrder);

            if (response.Result == ResponseResult.Success)
            {
                Response.Cookies.Delete(AppCookies.CreateOrder.Key);
                return _ClientHandleResult.ToastThenRedirect(HttpContext, $"/order/success/{response.Data}", new Toast(ToastType.Success, response.Message), true);
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





        //    [HttpPost("/order/create")]
        //public async Task<IActionResult> Create(CreateOrderDto create)
        //{
        //    var response = await _OrderService.Create(create);
        //    if (response.Result == ResponseResult.Success)
        //    {
        //        var trackingCode = response.Data;
        //        return _ClientHandleResult.ToastThenRedirect(HttpContext, $"/OrderSuccess/{trackingCode}", new Toast(ToastType.Success, response.Message), false);
        //    }
        //    return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        //}



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
