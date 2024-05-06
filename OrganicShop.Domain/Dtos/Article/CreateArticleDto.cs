using MD.PersianDateTime;
using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ArticleDtos
{
    public class CreateArticleDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int[] TagIds { get; set; }
        public IFormFile MainPictureFile { get; set; }
    }




}
