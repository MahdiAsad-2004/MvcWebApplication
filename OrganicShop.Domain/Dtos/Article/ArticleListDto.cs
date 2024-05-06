using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ArticleDtos
{
    public class ArticleListDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string MainImageName { get; set; }
        public string AuthorName { get; set; }
        public PersianDateTime CreateDate { get; set; }
        public string CategoryTitle { get; set; }
    }




}
