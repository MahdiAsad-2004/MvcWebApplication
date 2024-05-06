using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Extensions
{
    public static class PathExtensions
    {

        public static readonly string CurrentDirectory = Directory.GetCurrentDirectory();
                      
        public static readonly string CategoryImages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\category\\");

        public static readonly string UserImages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\user\\");
                      
        public static readonly string UserImageDefault = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\user\\user.png");

        public static readonly string ProductImages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\product\\");

        public static readonly string ArticleImages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\article\\");

        
        


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
        ProductImages , CategoryImages , UserImages , ArticleImages

    }



}
