
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.DAL.SeedDatas
{
    public class PictureSeed
    {

        public readonly Picture BasicGoods = new Picture
        {
            Id = 1,
            IsMain = true,
            Name = "BasicGoods.png",
            SizeMB = (float)0.645,
            BaseEntity = new BaseEntity(true),
            Type = PictureType.Category,
            CategoryId = CategorySeed.BasicGoods.Id,
        };






    }
}
