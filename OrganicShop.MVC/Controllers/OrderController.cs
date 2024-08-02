using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.BLL.Services;
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

        private readonly IOrderService _OrderService;
        private readonly IAddressService _AddressService;
        private readonly IShippingMethodService _ShippingMethodService;
        private readonly IProductItemService _ProductItemService;
        public OrderController(IOrderService orderService, IAddressService addressService, IProductItemService productItemService, IShippingMethodService deliveryService)
        {
            _OrderService = orderService;
            _AddressService = addressService;
            _ProductItemService = productItemService;
            _ShippingMethodService = deliveryService;
        }

        #endregion




        [HttpGet("/Checkout")]
        [Authorize]
        public async Task<IActionResult> Checkout(int discountPrice, byte deliveryId, bool freeDelivery)
        {
            long userId = User.GetAppUser().Id;

            if (userId < 1)
                return Redirect("/Error/404");

            var productItems = (await _ProductItemService.GetAll(new FilterProductItemDto { UserId = userId }))?.Data ?? new List<ProductItemListDto>();
            ViewData["ProductItems"] = productItems;
            var cartId = productItems.FirstOrDefault()?.CartId;

            if (cartId == null)
            {
                return Redirect("/Error/404");
            }

            ViewData["UserAddresses"] = (await _AddressService.GetAll(new FilterAddressDto { UserId = userId })).Data?.List ?? new List<AddressListDto>();
            var shippingMethod = (await _ShippingMethodService.Get(deliveryId)).Data;
            ViewBag.FreeDelivery = freeDelivery;

            var create = new CreateOrderDto
            {
                ShippingMethodName = shippingMethod.Type,
                ShippingPrice = shippingMethod.Price,
                DiscountPrice = discountPrice,
                CartId = cartId.Value,
                UserId = userId,
                PaymentMethod = PaymentMethod.Cash,
            };

            return View("Checkout", create);

        }




        [HttpPost("/order/create")]
        public async Task<IActionResult> Create(CreateOrderDto create)
        {
            var response = await _OrderService.Create(create);
            if (response.Result == ResponseResult.Success)
            {
                var trackingCode = response.Data;
                return _ClientHandleResult.ToastThenRedirect(HttpContext, $"/OrderSuccess/{trackingCode}", new Toast(ToastType.Success, response.Message), false);
            }
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
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
