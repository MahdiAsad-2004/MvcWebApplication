using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.NewsLetterMemberDtos
{
    public class NewsLetterMemberListDto : BaseListDto<int>
    {
        public string Email { get; set; }
        public long? UserId { get; set; }
        public string? UserName { get; set; }
        public PersianDateTime SubscribeDate { get; set; }

    }





}
