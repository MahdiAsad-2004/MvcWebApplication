using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Enums;

namespace OrganicShop.BLL.Extensions
{
    public static class PictureExtensions
    {

        public static string GetPictureUrl(this Picture picture)
        {
            switch (picture.Type)
            {
                case PictureType.Product:
                    return $"/media/images/product/{picture.Name}";

                case PictureType.Category:
                    return $"/media/images/category/{picture.Name}";

                case PictureType.User:
                    return $"/media/images/user/{picture.Name}";

                case PictureType.Article:
                    return $"/media/images/article/{picture.Name}";

                default: throw new Exception("Invalid enum");
            }
        }


        public static string GetPictureUrl(this PictureListDto picture)
        {
            switch (picture.Type)
            {
                case PictureType.Product:
                    return $"/media/images/product/{picture.Name}";

                case PictureType.Category:
                    return $"/media/images/category/{picture.Name}";

                case PictureType.User:
                    return $"/media/images/userr/{picture.Name}";

                case PictureType.Article:
                    return $"/media/images/article/{picture.Name}";

                default: throw new Exception("Invalid picture type");
            }
            throw new Exception("Picture url not found");
        }


        public static string? GetMainPictureName(this ICollection<Picture> pictures)
        {
            Picture? mainPicture = pictures.FirstOrDefault(a => a.IsMain && a.BaseEntity.IsActive);
            
            if(mainPicture != null)
                return mainPicture.Name;
            
            return null;
        }

        public static string GetPictureFilePath(this Picture picture)
        {
            switch (picture.Type)
            {
                case PictureType.Product:
                    return Path.Combine(PathExtensions.ProductImages, picture.Name);

                case PictureType.Category:
                    return Path.Combine(PathExtensions.CategoryImages, picture.Name);

                case PictureType.User:
                    return Path.Combine(PathExtensions.UserImages, picture.Name);
                
                case PictureType.Article:
                    return Path.Combine(PathExtensions.UserImages, picture.Name);

                default:
                    throw new Exception("Picture file path not found");
            }
        }

    }
}
