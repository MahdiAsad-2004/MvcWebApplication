using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.DAL.SeedDatas
{
    public class PropertyTypeSeed
    {

        public static readonly PropertyType a = new PropertyType
        {
            Title = "",
            Priority = 1,
            BaseEntity = new BaseEntity(true),
        };

        

        public static readonly PropertyType Weight = new PropertyType
        {
            Title = "وزن",
            Priority = 1,
            BaseEntity = new BaseEntity(true),
        };




        public static readonly PropertyType PackagingDimensions = new PropertyType
        {
            Title = "ابعاد بسته‌بندی",
            Priority = 2,
            BaseEntity = new BaseEntity(true),
        };



        public static readonly PropertyType Ingredient = new PropertyType
        {
            Title = "مواد تشکیل‌دهنده",
            Priority = 4,
            BaseEntity = new BaseEntity(true),
        };


        public static readonly PropertyType HealthLicenseNumber = new PropertyType
        {
            Title = "شماره پروانه بهداشت",
            Priority = 3,
            BaseEntity = new BaseEntity(true),
        };


        public static readonly PropertyType Volume = new PropertyType
        {
            Title = "حجم",
            Priority = 1,
            BaseEntity = new BaseEntity(true),
        };



        public static readonly PropertyType PackageType = new PropertyType
        {
            Title = "نوع بسته‌بندی",
            Priority = 1,
            BaseEntity = new BaseEntity(true),
        };


        public static readonly PropertyType RiceColor = new PropertyType
        {
            Title = "رنگ برنج",
            Priority = 1,
            BaseEntity = new BaseEntity(true),
        };

        public static readonly PropertyType GrainSize = new PropertyType
        {
            Title = "اندازه دانه",
            Priority = 1,
            BaseEntity = new BaseEntity(true),
        };

        public static readonly PropertyType IsOrganic = new PropertyType
        {
            Title = "ارگانیک",
            Priority = 1,
            BaseEntity = new BaseEntity(true),
        };


        public static readonly PropertyType Taste = new PropertyType
        {
            Title = "طعم",
            Priority = 5
            BaseEntity = new BaseEntity(true),
        };


        public static readonly PropertyType MaintenanceMethod = new PropertyType
        {
            Title = "روش نگهداری",
            Priority = 6,
            BaseEntity = new BaseEntity(true),
        };

        










































    }
}
