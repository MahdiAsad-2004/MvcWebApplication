
using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.CommentDtos;

namespace OrganicShop.Domain.Dtos.ArticleDtos
{
    public class ArticleDetailDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string MainImageName { get; set; }
        public string AuthorName { get; set; }
        public PersianDateTime CreateDate { get; set; }
        public string CategoryTitle { get; set; }


        public List<CommentListDto> Comments { get; set; }
        public int[] TagIds { get; set; }


    }




}
