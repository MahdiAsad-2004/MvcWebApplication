using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.TrackingStatusDtos
{
    public class UpdateTrackingStatusDto : BaseListDto<long>
    {
        public DoneStatus DoneStatus { get; set; }
        public DateTime? DoneDate { get; set; }
    }





}
