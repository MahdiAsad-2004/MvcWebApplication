using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.NewsLetterDtos
{
    public class NewsLetterListDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public PersianDateTime SendDate { get; set; }
        public bool IsSent { get; set; }




    }





}
