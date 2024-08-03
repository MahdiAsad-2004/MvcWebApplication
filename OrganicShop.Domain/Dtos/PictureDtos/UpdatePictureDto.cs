using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.PictureDtos
{
    public class UpdatePictureDto : BaseListDto<long>
    {
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? ArticleId { get; set; }
        public int? SellerId { get; set; }
        public IFormFile? ImageFIle { get; set; }
        public bool IsMain { get; set; }


    }


}
