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
        public string Name { get; set; }



    }


}
