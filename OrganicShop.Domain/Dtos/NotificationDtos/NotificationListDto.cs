using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.NotificationDtos
{
    public class NotificationListDto : BaseListDto<int>
    {
        public string TextHtml { get; set; }

        public bool IsActive { get; set; }

    }





}
