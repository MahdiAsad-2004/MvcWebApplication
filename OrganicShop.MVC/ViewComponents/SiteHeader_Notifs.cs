using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.NotificationDtos;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;


namespace OrganicShop.Mvc.ViewComponents
{
    public class SiteHeader_Notifs : ViewComponent
    {
        #region ctor

        private readonly INotificationService _NotificationService;
        public SiteHeader_Notifs(INotificationService notificationService)
        {
            _NotificationService = notificationService;
        }

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _NotificationService.GetAll(new FilterNotificationDto { ActiveFilter = IsActiveFilter.Active });
            if (response.Result == ResponseResult.Success)
            {
                return View("SiteHeader_Notifs", response.Data.List);
            }
            return View("SiteHeader_Notifs", new List<NotificationListDto>());
        }


    }



}
