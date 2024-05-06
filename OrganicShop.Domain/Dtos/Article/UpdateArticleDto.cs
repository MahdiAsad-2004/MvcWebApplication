using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.ArticleDtos
{
    public class UpdateArticleDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int[] TagIds { get; set; }
        public IFormFile? MainPictureFile { get; set; }
        public string MainPictureName { get; set; }
    }

}
