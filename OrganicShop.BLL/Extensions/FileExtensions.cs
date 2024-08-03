using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Extensions
{
    public static class FileExtensions
    {
        public static async Task<string> SaveFile(this IFormFile file, PathKey pathKey)
        {
            
            var fileName = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1,16)}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(pathKey.GetPath(), fileName);

            using (var stream = new FileStream(filePath, FileMode.CreateNew))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }



        public static async Task<Picture> SavePictureAsync(this IFormFile file, PathKey pathKey , PictureType pictureType)
        {

            var fileName = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 16)}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(pathKey.GetPath(), fileName);

            using (var stream = new FileStream(filePath, FileMode.CreateNew))
            {
                await file.CopyToAsync(stream);
            }

            return new Picture
            {
                Name = fileName,
                SizeMB = (float)file.Length / 1024 / 1000,
                Type = pictureType,
                BaseEntity = new BaseEntity(true),
            };
        }

        public static async Task<Picture> SavePictureAsync(this IFormFile file,Picture picture,PathKey pathKey)
        {
            var fileName = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 16)}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(pathKey.GetPath(), fileName);

            using (var stream = new FileStream(filePath, FileMode.CreateNew))
            {
                await file.CopyToAsync(stream);
            }
            picture.Name = fileName;
            picture.SizeMB = (float)file.Length / 1024 / 1000;
            picture.BaseEntity.LastModified = DateTime.Now;
            //picture.Type = pathKey.GetPictureType();
            return picture;
        }

        //public static async Task<List<Picture>> SavePicturesAsync(this IEnumerable<IFormFile> files, string path)
        //{
        //    string fileName = string.Empty;
        //    string filePath = path;
        //    List<Picture> pictures = new List<Picture>();

        //    using (var stream = new FileStream(filePath, FileMode.CreateNew))
        //    {
        //        foreach (var file in files)
        //        {
        //            fileName = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 16)}{Path.GetExtension(file.FileName)}";


        //            filePath = Path.Combine(path, fileName);
        //            await file.CopyToAsync(stream);
        //            pictures.Add(new Picture
        //            {
        //                Name = fileName,
        //                SizeMB = file.Length / 1024 / 1000,
        //                BaseEntity = new BaseEntity(true),
        //            });
        //        }
        //    }

        //    return pictures;
        //}


        //public static async Task<List<Picture>> SaveAndUpdateMainPictureAsync(this List<Picture> pictures, IFormFile file, PathKey pathKey)
        //{

        //    var fileName = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 16)}{Path.GetExtension(file.FileName)}";

        //    string filePath = Path.Combine(pathKey.GetPath(), fileName);

        //    using (var stream = new FileStream(filePath, FileMode.CreateNew))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    var mainPicture = pictures.First(a => a.IsMain);

        //    mainPicture.Name = fileName;
        //    mainPicture.SizeMB = (float)file.Length / 1024 / 1000;
        //    //mainPicture.Type = pathKey.GetPictureType();
        //    mainPicture.BaseEntity.LastModified = DateTime.Now;
        //    return pictures;
        //}


        public static async Task<bool> DeletePictureFile(this Picture picture)
        {
            string filePath = picture.GetPictureFilePath();

            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }



        public static string GenerateFileName(this IFormFile file)
        {
            return $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 16)}{Path.GetExtension(file.FileName)}";
        }


        public static float GetSizeMB(this IFormFile file)
        {
            return (float)file.Length / 1024 / 1000;
        }
    }
}
