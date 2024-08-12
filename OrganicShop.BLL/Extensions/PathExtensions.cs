using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Dtos.PictureDtos;

namespace OrganicShop.BLL.Extensions
{
    public static class PathExtensions
    {
        public static readonly string CurrentDirectory = Directory.GetCurrentDirectory();
                      
        public static readonly string CategoryImages = Path.Combine(CurrentDirectory, "wwwroot\\media\\images\\category\\");

        public static readonly string UserImages = Path.Combine(CurrentDirectory, "wwwroot\\media\\images\\user\\");
                      
        public static readonly string UserDefaultImagePath = Path.Combine(CurrentDirectory, "wwwroot\\media\\images\\user\\user.png");
        
        public static readonly string UserDefaultImageName = "user.png";

        public static readonly string ProductImages = Path.Combine(CurrentDirectory, "wwwroot\\media\\images\\product\\");
        
        public static readonly string ProductDefaultImagePath = Path.Combine(CurrentDirectory, "wwwroot\\media\\images\\product\\product-icon.png");
        
        public static readonly string ProductDefaultImageName = "product-icon.png";

        public static readonly string ArticleImages = Path.Combine(CurrentDirectory, "wwwroot\\media\\images\\article\\");
        
        public static readonly string ArticleDefaultImagePath = Path.Combine(CurrentDirectory, "wwwroot\\media\\images\\article\\article-icon.png");

        public static readonly string ArticleDefaultImageName = "article-icon.png";
        
        public static readonly string SellerImages = Path.Combine(CurrentDirectory, "wwwroot\\media\\images\\seller\\");

        public static readonly string SellerDefaultImagePath = Path.Combine(CurrentDirectory, "wwwroot\\media\\images\\seller\\seller-icon.png");
        
        public static readonly string SellerDefaultImageName = "seller-icon.png";
        
        


        public static string GetPath(this PathKey pathKey)
        {
            switch (pathKey)
            {
                case PathKey.ProductImages:
                    return PathExtensions.ProductImages;

                case PathKey.CategoryImages:
                    return PathExtensions.CategoryImages;

                case PathKey.UserImages:
                    return PathExtensions.UserImages;

                case PathKey.ArticleImages:
                    return PathExtensions.ArticleImages;

                case PathKey.SellerImages:
                    return PathExtensions.SellerImages;

                default: throw new Exception("Invalid enum");
            }
        }
        //public static PictureType GetPictureType(this PathKey pathKey)
        //{
        //    switch (pathKey)
        //    {
        //        case PathKey.ProductImages:
        //            return PictureType.Product;

        //        case PathKey.CateGoryImages:
        //            return PictureType.Category;

        //        case PathKey.UserImages:
        //            return PictureType.User;

        //        default: throw new Exception("Invalid Path Key");
        //    }
        //}
       

    }


    public enum PathKey
    {
        ProductImages , CategoryImages , UserImages , ArticleImages , SellerImages

    }



}
