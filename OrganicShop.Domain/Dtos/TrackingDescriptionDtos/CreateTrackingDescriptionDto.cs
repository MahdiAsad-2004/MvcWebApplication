using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.TrackingDescriptionDtos
{
    public class CreateTrackingDescriptionDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public long OrderId { get; set; }

    }





}
